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
    public class DALHD
    {
        private elektroEntities db;

        public DALHD()
        {
            db = new elektroEntities();
        }

        public List<HD> GetHDs()
        {
            try
            {
                return db.HD.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHDs - 001 - Erro ao recuperar HDs - " + ex.Message);
            }
        }

        public List<HD> GetHDs(string valor)
        {
            try
            {
                return db.HD.Where(d => d.NUMERO_HD == valor || d.NUMERO_SERIE == valor).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHDs - 002 - Erro ao recuperar HDs - " + ex.Message);
            }
        }

        public void InsertHD(HD hd)
        {
            try
            {
                db.HD.Add(hd);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHDs - 003 - Erro ao incluir HD - " + ex.Message);
            }
        }

        public void UpdateHD(HD hd)
        {
            try
            {
                HD hdU = db.HD.Where(d => d.NUMERO_HD == hd.NUMERO_HD).AsQueryable().FirstOrDefault();
                hdU.NUMERO_SERIE = hd.NUMERO_SERIE;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHDs - 004 - Erro ao alterar HD - " + ex.Message);
            }
        }

        public void UpdateStatusHD(string numeroHD, string status)
        {
            try
            {
                HD hdU = db.HD.Where(d => d.NUMERO_HD == numeroHD).AsQueryable().FirstOrDefault();
                hdU.STATUS = status;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHDs - 005 - Erro ao atualizar status do HD - " + ex.Message);
            }
        }

        public HD GetHD(string numeroHD)
        {
            try
            {
                return db.HD.Where(d => d.NUMERO_HD == numeroHD).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHDs - 006 - Erro ao recuperar HD - " + ex.Message);
            }
        }

        public void UpdateLocalidadeHD(string numeroHD, int codigo)
        {
            try
            {
                HD hdU = db.HD.Where(d => d.NUMERO_HD == numeroHD).AsQueryable().FirstOrDefault();
                hdU.LOCAL = codigo;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHDs - 007 - Erro ao atualizar localidade do HD - " + ex.Message);
            }
        }

        public List<HD> GetHDsDisponiveis()
        {
            try
            {
                return db.HD.Where(l => l.STATUS != "MANUTENÇÃO").AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALHDs - 008 - Erro ao recuperar HDs disponíveis - " + ex.Message);
            }
        }
    }
}
