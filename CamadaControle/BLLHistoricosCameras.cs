using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using Modelo;

namespace CamadaControle
{
    public class BLLHistoricosCameras
    {
        private DALHistoricosCameras dalHistorico = new DALHistoricosCameras();

        public List<HISTORICOS_CAMERAS> GetHistoricosCameras(string codCamera)
        {
            try
            {
                var lista = dalHistorico.GetHistoricosCameras(codCamera);
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InserirHistoricoCamera(HISTORICOS_CAMERAS historico)
        {
            try
            {
                dalHistorico.InserirHistoricoCamera(historico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
