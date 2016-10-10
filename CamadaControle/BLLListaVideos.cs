using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLListaVideos
    {
        private DALListaVideos dalListaVideos = new DALListaVideos();

        public LISTA_VIDEOS GetListaVideos(int codigo)
        {
            try
            {
                return dalListaVideos.GetListaVideos(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InserirListaVideos(LISTA_VIDEOS lista)
        {
            try
            {
                dalListaVideos.InserirListaVideos(lista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LISTA_VIDEOS GetListaVideosOcorrencia(int codigo)
        {
            try
            {
                return dalListaVideos.GetListaVideosOcorrencia(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
