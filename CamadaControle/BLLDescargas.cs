using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLDescargas
    {
        private DALDescargas dalDescarga = new DALDescargas();

        public List<DESCARGAS> GetDescargas(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalDescarga.GetDescargas();
                }
                else
                {
                    return dalDescarga.GetDescargas(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DESCARGAS GetDescarga(int codigo)
        {
            try
            {
                return dalDescarga.GetDescarga(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InserirDescarga(DESCARGAS descarga)
        {
            try
            {
                dalDescarga.InserirDescarga(descarga);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
