using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaDados
{
    public class DALEscalaCOD
    {
        private elektroEntities db;

        public DALEscalaCOD()
        {
            db = new elektroEntities();
        }

        public List<ESCALA_COD> GetEscalas()
        {
            try
            {
                return db.ESCALA_COD.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEscalaCOD - 001 - Erro ao recuperar escalas - " + ex.Message);
            }
        }

        public List<ESCALA_COD> GetEscalas(string valor)
        {
            try
            {
                return db.ESCALA_COD.Where(l => l.PRONTUARIO.Contains(valor) || l.SIGLA_EQUIPE.Contains(valor)).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEscalaCOD - 002 - Erro ao recuperar escalas - " + ex.Message);
            }
        }

        public List<ESCALA_COD> GetEscalas(string equipe, string datainicial, string datafinal, int processo)
        {
            try
            {
                DateTime dtinicio = Convert.ToDateTime(datainicial);
                DateTime dtfim = Convert.ToDateTime(datafinal);
                return db.ESCALA_COD.Where(l => l.SIGLA_EQUIPE.Contains(equipe) && l.DATA_INICIO >= dtinicio && l.DATA_FIM <= dtfim).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEscalaCOD - 002 - Erro ao recuperar escalas - " + ex.Message);
            }
        }

        public List<ESCALA_COD> GetEscalas(string equipe, string datainicial, string datafinal)
        {
            try
            {
                DateTime dtinicio = Convert.ToDateTime(datainicial);
                DateTime dtfim = Convert.ToDateTime(datafinal);
                return db.ESCALA_COD.Where(l => l.SIGLA_EQUIPE.Contains(equipe) && l.DATA_INICIO <= dtinicio && l.DATA_FIM >= dtfim).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEscalaCOD - 002 - Erro ao recuperar escalas - " + ex.Message);
            }
        }

        public void InsertEscala(ESCALA_COD escala)
        {
            try
            {
                db.ESCALA_COD.Add(escala);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALEscalaCOD - 003 - Erro ao incluir escala - " + ex.Message);
            }
        }
    }
}
