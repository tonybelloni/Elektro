using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLSorteados
    {
        public DALSorteados dalSorteados;

        public BLLSorteados()
        {
            dalSorteados = new DALSorteados();
        }

        public List<SORTEADOS> GetSorteados(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalSorteados.GetSorteados();
                }
                else
                {
                    return dalSorteados.GetSorteados(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SORTEADOS GetSorteado(int codigo)
        {
            try
            {
                return dalSorteados.GetSorteado(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertSorteado(SORTEADOS sorteado)
        {
            try
            {
                dalSorteados.InsertSorteado(sorteado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateSorteado(SORTEADOS sorteado)
        {
            try
            {
                dalSorteados.UpdateSorteado(sorteado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizaParaVisualizado(int codigo, string numeroHD, string usuario)
        {
            try
            {
                dalSorteados.AtualizaParaVisualizado(codigo, numeroHD, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
