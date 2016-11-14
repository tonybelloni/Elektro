using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALCameras
    {
        private elektroEntities db;

        public DALCameras()
        {
            db = new elektroEntities();
        }

        public List<CAMERAS> GetCameras()
        {
            try
            {
                return db.CAMERAS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 001 - Erro ao recuperar câmeras - " + ex.Message);
            }
        }
    
        public List<CAMERAS> GetCameras(string valor)
        {
            try
            {
                return db.CAMERAS.Where(c => c.codigo_camera.Contains(valor) || c.codigo_barra_camera.Contains(valor)).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 002 - Erro ao recuperar câmeras - " + ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasPorFuncionario(string prontuario)
        {
            try
            {
                return db.CAMERAS.Where(c => c.PRONTUARIO.Contains(prontuario)).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 002 - Erro ao recuperar câmeras - " + ex.Message);
            }
        }

        public void InsertCamera(CAMERAS camera)
        {
            try
            {
                db.CAMERAS.Add(camera);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 003 - Erro ao incluir câmera - " + ex.Message);
            }
        }

        public void UpdateCamera(CAMERAS camera)
        {
            try
            {
                CAMERAS cameraUpd = db.CAMERAS.Where(c => c.codigo_camera == camera.codigo_camera).AsQueryable().FirstOrDefault();
                cameraUpd.bpm_camera = camera.bpm_camera;
                cameraUpd.codigo_barra_camera = camera.codigo_barra_camera;
                cameraUpd.CODIGO_EMPRESA = camera.CODIGO_EMPRESA;
                cameraUpd.DATA_AQUISICAO = camera.DATA_AQUISICAO;
                cameraUpd.ativo = camera.ativo;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 004 - Erro ao alterar câmera - " + ex.Message);
            }
        }

        public CAMERAS GetCamera(string numeroCamera)
        {
            try
            {

                return db.CAMERAS.Where(c => c.codigo_camera == numeroCamera).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 005 - Erro ao recuperar câmera - " + ex.Message);
            }
        }

        public void UpdateStatusCamera(string numeroCamera, string status, string prontuario)
        {
            try
            {
                CAMERAS camera = db.CAMERAS.Where(c => c.codigo_camera == numeroCamera).AsQueryable().FirstOrDefault();
                camera.STATUS = status;

                if (status == "MANUTENÇÃO")
                    camera.ativo = 0;
                else if (status == "MANUTENÇÃO LOCAL")
                {
                    camera.ativo = 0;
                }
                else if (status == "INUTILIZADA")
                    camera.ativo = 0;
                else if (status == "EM ESTOQUE")
                {
                    camera.ativo = 1;
                }
                else
                    camera.ativo = 1;

                if (!String.IsNullOrEmpty(prontuario))
                    camera.PRONTUARIO = prontuario;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 006 - Erro ao atualizar status da câmera - " + ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasDesalocadas()
        {
            try
            {
                return db.CAMERAS.Where(c => c.ativo == 1 && (c.STATUS == null || c.STATUS == "DISPONÍVEL")).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 007 - Erro ao recuperar câmeras desalocadas - " + ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasAlocadas()
        {
            try
            {
                return db.CAMERAS.Where(c => c.ativo == 1 && c.STATUS == "ALOCADA").AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 008 - Erro ao recuperar câmeras alocadas - " + ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasParaManutencao()
        {
            try
            {
                return db.CAMERAS.Where(c => c.ativo == 1 && (c.STATUS == null || c.STATUS == "DISPONÍVEL")).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 009 - Erro ao recuperar câmeras para manutenção - " + ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasEmManutencao()
        {
            try
            {
                return db.CAMERAS.Where(c => c.ativo == 0 && c.STATUS == "MANUTENÇÃO").AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 009 - Erro ao recuperar câmeras para manutenção - " + ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasEmManutencaoLocal()
        {
            try
            {
                return db.CAMERAS.Where(c => c.ativo == 0 && c.STATUS == "MANUTENÇÃO LOCAL").AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 010 - Erro ao recuperar câmeras para manutenção - " + ex.Message);
            }
        }

        public List<CAMERAS> GetCamerasInutilizadas()
        {
            try
            {
                return db.CAMERAS.Where(c => c.ativo == 0 && c.STATUS == "INUTILIZADO").AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 011 - Erro ao recuperar câmeras inutilizadas - " + ex.Message);
            }
        }

        public void RealizarBaixaCamera(string numeroCamera, string status, DateTime dataBaixa, string motivo)
        {
            try
            {
                CAMERAS camera = db.CAMERAS.Where(c => c.codigo_camera == numeroCamera).AsQueryable().FirstOrDefault();
                camera.STATUS = status;
                camera.ativo = 0;
                camera.MOTIVO_BAIXA = motivo;
                camera.DATA_BAIXA = dataBaixa;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 011 - Erro ao realizar baixa de câmera - " + ex.Message);
            }
        }

        public void AlocarCameraFuncionario(CAMERAS camera, USUARIOS usuario)
        {
            try
            {
                CAMERAS cameraU = db.CAMERAS.Where(c => c.codigo_camera == camera.codigo_camera).AsQueryable().FirstOrDefault();
                cameraU.PRONTUARIO = usuario.PRONTUARIO;
                
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 012 - Erro ao enviar câmera para funcionário - " + ex.Message);
            }
        }

        public void AlocarCameraFuncionario(CAMERAS camera, string prontuario)
        {
            try
            {
                CAMERAS cameraU = db.CAMERAS.Where(c => c.codigo_camera == camera.codigo_camera).AsQueryable().FirstOrDefault();
                cameraU.PRONTUARIO = prontuario;
                
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 012 - Erro ao enviar câmera para funcionário - " + ex.Message);
            }
        }

        public void DesalocarCameraFuncionario(CAMERAS camera)
        {
            try
            {
                CAMERAS cameraU = db.CAMERAS.Where(c => c.codigo_camera == camera.codigo_camera).AsQueryable().FirstOrDefault();
                cameraU.PRONTUARIO = null;
                cameraU.STATUS = "DISPONÍVEL";

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALCameras - 013 - Erro ao tirar câmera do funcionário - " + ex.Message);
            }
        }
    }
}
