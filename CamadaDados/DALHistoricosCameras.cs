using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALHistoricosCameras
    {
        private elektroEntities db;

        public DALHistoricosCameras()
        {
            db = new elektroEntities();
        }

        public List<HISTORICOS_CAMERAS> GetHistoricosCameras(string codigoCamera)
        {
            try
            {
                return db.HISTORICOS_CAMERAS.Where(l => l.CODIGO_CAMERA == codigoCamera).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHistoricosCameras - 001 - Erro ao recuperar históricos de câmeras - " + ex.Message);
            }
        }

        public void InserirHistoricoCamera(HISTORICOS_CAMERAS historico)
        {
            try
            {
                db.HISTORICOS_CAMERAS.Add(historico);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHistoricosCameras - 002 - Erro ao registrar histórico para câmera - " + ex.Message);
            }
        }
    }
}
