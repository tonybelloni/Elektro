using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALTiposOcorrencia
    {
        private elektroEntities db;

        public DALTiposOcorrencia()
        {
            db = new elektroEntities();
        }

        public List<TIPOS_OCORRENCIAS> GetTiposOcorrencia()
        {
            try
            {
                return db.TIPOS_OCORRENCIAS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposOcorrencia - 001 - Erro ao recuperar tipos de ocorrência - " + ex.Message);
            }
        }

        public List<TIPOS_OCORRENCIAS> GetTiposOcorrencia(string descricao)
        {
            try
            {
                var lista = db.TIPOS_OCORRENCIAS.AsQueryable().ToList();
                if (descricao != "")
                    lista = lista.Where(l => l.DESCRICAO.Contains(descricao)).AsQueryable().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposOcorrencia - 002 - Erro ao recuperar tipos de ocorrência - " + ex.Message);
            }
        }

        public void InsertTipoOcorrencia(TIPOS_OCORRENCIAS tipo)
        {
            try
            {
                db.TIPOS_OCORRENCIAS.Add(tipo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposOcorrencia - 003 - Erro ao incluir tipo de ocorrência - " + ex.Message);
            }
        }

        public TIPOS_OCORRENCIAS GetTipoOcorrencia(int codigo)
        {
            try
            {
                return db.TIPOS_OCORRENCIAS.Where(l => l.ID_TIPO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposOcorrencia - 004 - Erro ao recuperar tipo de ocorrencia - " + ex.Message);
            }
        }

        public TIPOS_OCORRENCIAS GetTipoOcorrencia(string descricao)
        {
            try
            {
                return db.TIPOS_OCORRENCIAS.Where(l => l.DESCRICAO == descricao).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposOcorrencia - 005 - Erro ao recuperar tipo de ocorrencia - " + ex.Message);
            }
        }

        public void UpdateTipoOcorrencia(int codigo, int gravidade, string descricao)
        {
            try
            {
                TIPOS_OCORRENCIAS tipo = db.TIPOS_OCORRENCIAS.Where(l => l.ID_TIPO == codigo).AsQueryable().FirstOrDefault();
                tipo.DESCRICAO = descricao;
                tipo.GRAVIDADE = gravidade;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposOcorrencia - 006 - Erro ao atualizar tipo de ocorrência - " + ex.Message);
            }
        }
    }
}
