using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace CamadaDados
{
    public class DALTiposVeiculos
    {
        private elektroEntities db;

        public DALTiposVeiculos()
        {
            db = new elektroEntities();
        }

        public List<TIPOS_VEICULOS> GetTiposVeiculos()
        {
            try
            {
                return db.TIPOS_VEICULOS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposVeiculos - 001 - Erro ao recuperar tipos de veículos - " + ex.Message);
            }
        }

        public List<TIPOS_VEICULOS> GetTiposVeiculos(string valor)
        {
            try
            {
                return db.TIPOS_VEICULOS.Where(l => l.DESCRICAO.Contains(valor)).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposVeiculos - 002 - Erro ao recuperar tipos de veículos - " + ex.Message);
            }
        }

        public void InsertTipoVeiculo(TIPOS_VEICULOS tipo)
        {
            try
            {
                db.TIPOS_VEICULOS.Add(tipo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposVeiculos - 003 - Erro ao incluir tipo de veículo - " + ex.Message);
            }
        }

        public void UpdateTipoVeiculo(TIPOS_VEICULOS tipo)
        {
            try
            {
                TIPOS_VEICULOS tipoU = db.TIPOS_VEICULOS.Where(l => l.COD_TIPO_VEICULO == tipo.COD_TIPO_VEICULO).AsQueryable().FirstOrDefault();
                tipoU.DESCRICAO = tipo.DESCRICAO;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposVeiculos - 004 - Erro ao alterar tipo de veículo - " + ex.Message);
            }
        }

        public TIPOS_VEICULOS GetTipoVeiculo(int codigo)
        {
            try
            {

                return db.TIPOS_VEICULOS.Where(l => l.COD_TIPO_VEICULO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALTiposVeiculos - 005 - Erro ao recuperar tipo de veículo - " + ex.Message);
            }
        }
    }
}
