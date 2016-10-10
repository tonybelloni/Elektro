using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;
using Modelo;

namespace CamadaControle
{
    public class BLLCameras
    {
        public List<CAMERAS> GetCameras(string valor)
        {
            try
            {
                DALCameras dalCamera = new DALCameras();

                if (valor == "")
                {
                    return dalCamera.GetCameras();
                }
                else
                {
                    return dalCamera.GetCameras(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CAMERAS GetCamera(string numeroCamera)
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                return dalCamera.GetCamera(numeroCamera);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasAlocadas()
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                return dalCamera.GetCamerasAlocadas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasDesalocadas()
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                return dalCamera.GetCamerasDesalocadas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertCamera(CAMERAS camera)
        {
            try
            {
                DALCameras cameras = new DALCameras();
                cameras.InsertCamera(camera);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCamera(CAMERAS camera)
        {
            try
            {
                DALCameras cameras = new DALCameras();
                cameras.UpdateCamera(camera);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStatusCamera(string numeroCamera, string status, string prontuario)
        {
            try
            {
                DALCameras cameras = new DALCameras();
                cameras.UpdateStatusCamera(numeroCamera, status, prontuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasParaManutencao()
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                return dalCamera.GetCamerasParaManutencao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasEmManutencao()
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                return dalCamera.GetCamerasEmManutencao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasEmManutencaoLocal()
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                return dalCamera.GetCamerasEmManutencaoLocal();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasInutilizadas()
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                return dalCamera.GetCamerasInutilizadas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RealizarBaixaCamera(string numeroCamera, string status, DateTime dataBaixa, string motivo)
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                dalCamera.RealizarBaixaCamera(numeroCamera, status, dataBaixa, motivo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlocarCameraFuncionario(CAMERAS camera, USUARIOS usuario)
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                dalCamera.AlocarCameraFuncionario(camera, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DesalocarCameraFuncionario(CAMERAS camera)
        {
            try
            {
                DALCameras dalCamera = new DALCameras();
                dalCamera.DesalocarCameraFuncionario(camera);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
