using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLVideo
    {
        private DALVideo dalVideo = new DALVideo();

        public VIDEOS GetVideo(int codigo)
        {
            try
            {
                return dalVideo.GetVideo(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InserirVideo(VIDEOS video)
        {
            try
            {
                dalVideo.InserirVideo(video);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
