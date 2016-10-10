using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALListaVideos
    {
        private elektroEntities db;

        public DALListaVideos()
        {
            db = new elektroEntities();
        }

        public LISTA_VIDEOS GetListaVideos(int codigo)
        {
            try
            {
                return db.LISTA_VIDEOS.Where(l => l.CODIGO_LISTA_VIDEOS == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALListaVideos - 001 - Erro ao recuperar lista de vídeos - " + ex.Message);
            }
        }

        public void InserirListaVideos(LISTA_VIDEOS lista)
        {
            try
            {
                db.LISTA_VIDEOS.Add(lista);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALListaVideos - 002 - Erro ao inserir lista de vídeos - " + ex.Message);
            }
        }

        public LISTA_VIDEOS GetListaVideosOcorrencia(int codigo)
        {
            try
            {
                return db.LISTA_VIDEOS.AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALListaVideos - 003 - Erro ao recuperar lista de vídeos - " + ex.Message);
            }
        }
    }
}
