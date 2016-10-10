using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALDescargas
    {
        private elektroEntities db;

        public DALDescargas()
        {
            db = new elektroEntities();
        }

        public List<DESCARGAS> GetDescargas()
        {
            try
            {
                return db.DESCARGAS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALDescargas - 001 - Erro ao recuperar descargas de vídeos do HD - " + ex.Message);
            }
        }

        public List<DESCARGAS> GetDescargas(string numeroHD)
        {
            try
            {
                return db.DESCARGAS.Where(l => l.NUMERO_HD == numeroHD).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALDescargas - 002 - Erro ao recuperar descargas de vídeos do HD - " + ex.Message);
            }
        }

        public void InserirDescarga(DESCARGAS descarga)
        {
            try
            {
                db.DESCARGAS.Add(descarga);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALDescargas - 003 - Erro ao inserir descargas de vídeos do HD - " + ex.Message);
            }
        }

        public DESCARGAS GetDescarga(int codigo)
        {
            try
            {
                return db.DESCARGAS.Where(l => l.CODIGO_DESCARGA == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALDescargas - 004 - Erro ao recuperar descarga de vídeos do HD - " + ex.Message);
            }
        }
    }
}
