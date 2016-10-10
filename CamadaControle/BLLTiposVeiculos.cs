using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLTiposVeiculos
    {
        DALTiposVeiculos dalTipoVeiculo = new DALTiposVeiculos();

        public List<TIPOS_VEICULOS> GetTiposVeiculos(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalTipoVeiculo.GetTiposVeiculos();
                }
                else
                {
                    return dalTipoVeiculo.GetTiposVeiculos(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TIPOS_VEICULOS GetTipoVeiculo(int codigo)
        {
            try
            {
                return dalTipoVeiculo.GetTipoVeiculo(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertTipoVeiculo(TIPOS_VEICULOS tipo)
        {
            try
            {
                dalTipoVeiculo.InsertTipoVeiculo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateTipoVeiculo(TIPOS_VEICULOS tipo)
        {
            try
            {
                dalTipoVeiculo.UpdateTipoVeiculo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
