using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Security.Cryptography;

namespace Utilitarios
{
    public class ClassesAuxiliares
    {

        private bool invalid;
        private static string seed = "Rio Service Company Solucoes em Informatic";
        public string GetConnectionString()
        {
            try
            {
               char[] separador = {';'}; 
               string configurationFile = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\server.conf";
        
               if ( File.Exists(configurationFile) )
               {
                   StreamReader sr = new StreamReader(configurationFile);
                   string linha = sr.ReadLine();
                   string[] tokens;
                   if ( linha != null )
                   {
                       tokens = linha.Split(separador);
                       if ( tokens.Count<string>() < 4 || tokens.Count<string>() > 4)
                       {
                           throw new Exception("Formato inválido do arquivo de configuração");
                       }
                       else
                       {
                           return string.Format("Data Source={0};Initial Catalog={1};User id={2}; Password={3}", tokens[0], tokens[1], tokens[2], tokens[3]);
                           //return "Data Source=WIN-FJH7V0HPILC\\SQLEXPRESS;Initial Catalog=elektro;Trusted_Connection=True";
                        }
                   }
                   else
                   {
                       throw new Exception("Arquivo de configurãção está vazio");
                   }
               }
               else
               {
                   throw new Exception("Arquivo de configuração não existe");
               }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível recuperar string de conexão - " + ex.Message);
            }
        }

        public bool IsValidEmail(string strIn)
        {
            invalid = false;

            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool ValidaPlaca(string value)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{3}\-\d{4}$");

            if (regex.IsMatch(value))
            {
                return true;
            }

            return false;
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        public string Criptografar(string texto)
        {
            TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();

            TripleDES.Key = MD5Hash(seed);
            TripleDES.Mode = CipherMode.ECB;

            Byte[] buffer = ASCIIEncoding.ASCII.GetBytes(texto);
            return Convert.ToBase64String(TripleDES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        private Byte[] MD5Hash(string valor)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            Byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(valor);
            return MD5.ComputeHash(byteArray);
        }

        public string Descriptografar(string texto)
        {
            try
            {
                TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
                tripledes.Key = MD5Hash(seed);
                tripledes.Mode = CipherMode.ECB;

                Byte[] Buffer = Convert.FromBase64String(texto);
                return ASCIIEncoding.ASCII.GetString(tripledes.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch
            {
                return String.Empty;
            }
        }

        public List<string> getAvailableDriveLetters()
        {
            List<string> lista = new List<string>();
            lista.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady && drives[i].DriveType == DriveType.Removable)
                    lista.Add(drives[i].Name);
            }

            return lista;
        }

        public string VerificaLicenca()
        {
            string info = "";
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\elektro.lic";

            if (System.IO.File.Exists(path))
            {
                var informacao = File.ReadAllLines(path);
                string validade = Descriptografar(informacao[0]);
                try
                {
                    info = Convert.ToDateTime(validade).ToShortDateString();
                }
                catch
                {
                    info = "Não foi possível verificar validade da licença. Entre em contato com o desenvolvedor do sistema";
                }
            }
            else
            {
                info = "Não foi encontrado arquivo de licença de uso! Favor entrar em contato com o desenvolvedor do software";
            }

            return info;
        }
    }
}
