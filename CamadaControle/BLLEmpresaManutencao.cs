using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;

namespace CamadaControle
{
    public class BLLEmpresaManutencao
    {
        private DALEmpresaManutencao dalEmpresa = new DALEmpresaManutencao();

        public List<EMPRESAS> GetEmpresas(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalEmpresa.GetEmpresas();
                }
                else
                {
                    return dalEmpresa.GetEmpresas(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertEmpresa(EMPRESAS empresa)
        {
            try
            {
                dalEmpresa.InsertEmpresa(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateHD(EMPRESAS empresa)
        {
            try
            {
                dalEmpresa.UpdateEmpresa(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
