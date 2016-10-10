using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaControle
{
    public class BLLVeiculos
    {
        DALVeiculos dalVeiculo = new DALVeiculos();

        public List<VEICULOS> GetVeiculos(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalVeiculo.GetVeiculos();
                }
                else
                {
                    return dalVeiculo.GetVeiculos(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
   
        public void InsertVeiculo(VEICULOS veiculo)
        {
            try
            {
                DALVeiculos veiculos = new DALVeiculos();
                veiculos.InsertVeiculo(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateVeiculo(VEICULOS veiculo)
        {
            try
            {
                DALVeiculos veiculos = new DALVeiculos();
                veiculos.UpdateVeiculo(veiculo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public VEICULOS GetVeiculo(string placa)
        {
            try
            {
                DALVeiculos veiculos = new DALVeiculos();
                return veiculos.GetVeiculo(placa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<VEICULOS> GetVeiculosSemEquipes()
        {
            try
            {
                DALVeiculos veiculos = new DALVeiculos();
                return veiculos.GetVeiculosSemEquipes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<VEICULOS> GetVeiculosComEquipes()
        {
            try
            {
                DALVeiculos veiculos = new DALVeiculos();
                return veiculos.GetVeiculosComEquipes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateEquipeVeiculo(string placa, string equipe)
        {
            try
            {
                DALVeiculos veiculos = new DALVeiculos();
                veiculos.UpdateEquipeVeiculo(placa, equipe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
