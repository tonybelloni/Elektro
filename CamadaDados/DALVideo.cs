using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALVideo
    {
        private elektroEntities db;

        public DALVideo()
        {
            db = new elektroEntities();
        }

        public VIDEOS GetVideo(int codigo)
        {
            try
            {
                return db.VIDEOS.Where(l => l.ID_VIDEO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVideo - 001 - Erro ao recuperar vídeo - " + ex.Message);
            }
        }

        public void InserirVideo(VIDEOS video)
        {
            try
            {
                db.VIDEOS.Add(video);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVideo - 002 - Erro ao inserir vídeo - " + ex.Message);
            }
        }
    }
}
