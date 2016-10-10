using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaControle
{
    public class BLLHD
    {
        private DALHD dalHD = new DALHD();

        public List<HD> GetHDs(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalHD.GetHDs();
                }
                else
                {
                    return dalHD.GetHDs(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertHD(HD hd)
        {
            try
            {
                DALHD dalHD = new DALHD();
                dalHD.InsertHD(hd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateHD(HD hd)
        {
            try
            {
                DALHD dalHD = new DALHD();
                dalHD.UpdateHD(hd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStatusHD(string numeroHD, string status)
        {
            try
            {
                DALHD dalHD = new DALHD();
                dalHD.UpdateStatusHD(numeroHD, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public HD GetHD(string numeroHD)
        {
            try
            {
                DALHD dalHD = new DALHD();
                return dalHD.GetHD(numeroHD);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateLocalidadeHD(string numeroHD, int codigo)
        {
            try
            {
                DALHD dalHD = new DALHD();
                dalHD.UpdateLocalidadeHD(numeroHD, codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HD> GetHDsDisponiveis()
        {
            try
            {
                return dalHD.GetHDsDisponiveis();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
