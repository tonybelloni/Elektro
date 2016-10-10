using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLFalhasEventosProcessos
    {
        public DALFalhasEventosProcessos dalFalha;

        public BLLFalhasEventosProcessos()
        {
            dalFalha = new DALFalhasEventosProcessos();
        }

        public List<FALHAS_EVENTOS_PROCESSOS> GetFalhasEventos(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalFalha.GetFalhasEventos();
                }
                else
                {
                    return dalFalha.GetFalhasEventos(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FALHAS_EVENTOS_PROCESSOS GetFalhaEvento(int codigo)
        {
            try
            {
                return dalFalha.GetFalhaEvento(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertFalhaEvento(FALHAS_EVENTOS_PROCESSOS falha)
        {
            try
            {
                dalFalha.InsertFalhaEvento(falha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateFalhaEvento(FALHAS_EVENTOS_PROCESSOS falha)
        {
            try
            {
                dalFalha.UpdateFalhaEvento(falha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
