using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLSorteio
    {
        private DALSorteio dalSorteio = new DALSorteio();

        public List<SORTEIOS> GetSorteios()
        {
            try
            {
                return dalSorteio.GetSorteios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SORTEIOS GetSorteio(int codigo)
        {
            try
            {
                return dalSorteio.GetSorteio(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsereSorteio(SORTEIOS sorteio)
        {
            try
            {
                dalSorteio.InsereSorteio(sorteio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SORTEIOS> GetSorteios(int codigoSorteio, string numeroHD, string equipe, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                return dalSorteio.GetSorteios(codigoSorteio, numeroHD, equipe, dataInicial, dataFinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
