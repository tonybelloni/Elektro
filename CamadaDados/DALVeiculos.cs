using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace CamadaDados
{
    public class DALVeiculos
    {
        private elektroEntities db;

        public DALVeiculos()
        {
            db = new elektroEntities();
        }

        public List<VEICULOS> GetVeiculos()
        {
            try
            {
                return db.VEICULOS.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVeiculos - 001 - Erro ao recuperar veículos - " + ex.Message);
            }
        }
    
        public List<VEICULOS> GetVeiculos(string valor)
        {
            try
            {
                return db.VEICULOS.Where(l => l.PLACA.Contains(valor) || l.NUMERO.Contains(valor)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVeiculos - 002 - Erro ao recuperar veículos - " + ex.Message);
            }
        }

        public void InsertVeiculo(VEICULOS veiculo)
        {
            try
            {
                db.VEICULOS.Add(veiculo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVeiculos - 006 - Erro ao incluir veículo - " + ex.Message);
            }
        }

        public void UpdateVeiculo(VEICULOS veiculo)
        {
            try
            {
                VEICULOS veiculoU = db.VEICULOS.Where(l => l.PLACA == veiculo.PLACA).AsQueryable().FirstOrDefault();
                veiculoU.NUMERO = veiculo.NUMERO;
                veiculoU.observacao = veiculo.observacao;
                veiculoU.COD_TIPO = veiculo.COD_TIPO;
                veiculoU.ativo = veiculo.ativo;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVeiculos - 007 - Erro ao alterar veículo - " + ex.Message);
            }
        }

        public VEICULOS GetVeiculo(string placa)
        {
            try
            {
                return db.VEICULOS.Where(l => l.PLACA == placa).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVeiculos - 008 - Erro ao buscar veículo - " + ex.Message);
            }
        }

        public List<VEICULOS> GetVeiculosSemEquipes()
        {
            try
            {
                return db.VEICULOS.Where(l => l.SIGLA_EQUIPE == null).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVeiculos - 009 - Erro ao buscar veículos sem equipes - " + ex.Message);
            }
        }

        public List<VEICULOS> GetVeiculosComEquipes()
        {
            try
            {
                return db.VEICULOS.Where(l => l.SIGLA_EQUIPE != null).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVeiculos - 010 - Erro ao buscar veículos com equipes - " + ex.Message);
            }
        }

        public void UpdateEquipeVeiculo(string placa, string equipe)
        {
            try
            {
                VEICULOS veiculo = db.VEICULOS.Where(l => l.PLACA == placa).AsQueryable().FirstOrDefault();
                veiculo.SIGLA_EQUIPE = equipe;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALVeiculos - 011 - Erro ao atualizar status do veículo - " + ex.Message);
            }
        }
    }
}
