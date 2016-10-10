using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;

namespace CamadaControle
{
    public class BLLFuncionarios
    {
        private DALFuncionarios dalFuncionario = new DALFuncionarios();

        public List<FUNCIONARIOS> GetFuncionarios(string valor)
        {
            try
            {
                List<FUNCIONARIOS> lista = new List<FUNCIONARIOS>();
                
                if (valor == "")
                {
                    return dalFuncionario.GetFuncionarios();
                }
                else
                {
                    return dalFuncionario.GetFuncionarios(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAllFuncionarios()
        {
            try
            {
                dalFuncionario.DeleteAllFuncionarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void InsertFuncionario(FUNCIONARIOS funcionario)
        {
            try
            {
                dalFuncionario.InsertFuncionario(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void UpdateFuncionario(FUNCIONARIOS funcionario)
        {
            try
            {
                dalFuncionario.UpdateFuncionario(funcionario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public FUNCIONARIOS GetFuncionario(string descricao)
        {
            try
            {
                return dalFuncionario.GetFuncionario(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
