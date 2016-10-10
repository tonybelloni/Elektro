using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CamadaDados;
using CamadaControle;

namespace CamadaControle
{
    public class BLLEquipes
    {
        private DALEquipes dalEquipe = new DALEquipes();

        public List<EQUIPES> GetEquipes(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalEquipe.GetEquipes();
                }
                else
                {
                    return dalEquipe.GetEquipes(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertEquipe(EQUIPES equipe)
        {
            try
            {
                if (dalEquipe.GetEquipesByNome(equipe.NOME_EQUIPE).Count() > 0)
                    throw new Exception("Já existe uma equipe com esse nome!");
                dalEquipe.InsertEquipe(equipe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateEquipe(EQUIPES equipe)
        {
            try
            {
                if (dalEquipe.GetEquipesByNome(equipe.NOME_EQUIPE).Count() > 1)
                    throw new Exception("Já existe uma equipe com esse nome!");
                dalEquipe.UpdateEquipe(equipe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesSemAlocacaoCamera()
        {
            try
            {
                DALEquipes dalEquipes = new DALEquipes();
                var equipes = dalEquipes.GetEquipesSemAlocacaoCamera();

                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesComAlocacaoCamera()
        {
            try
            {
                DALEquipes dalEquipes = new DALEquipes();
                var equipes = dalEquipes.GetEquipesComAlocacaoCamera();

                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStatusEquipe(string siglaEquipe, string codigoCamera)
        {
            try
            {
                DALEquipes dalEquipes = new DALEquipes();
                dalEquipes.UpdateStatusEquipe(siglaEquipe, codigoCamera);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public EQUIPES GetEquipeBySigla(string siglaEquipe)
        {
            try
            {
                DALEquipes dalEquipes = new DALEquipes();
                return dalEquipes.GetEquipeBySigla(siglaEquipe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesSemVeiculo()
        {
            try
            {
                DALEquipes dalEquipes = new DALEquipes();
                var equipes = dalEquipes.GetEquipesSemVeiculo();

                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesComVeiculo()
        {
            try
            {
                DALEquipes dalEquipes = new DALEquipes();
                var equipes = dalEquipes.GetEquipesComVeiculo();

                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStatusVeiculoEquipe(string siglaEquipe, string placa)
        {
            try
            {
                DALEquipes dalEquipes = new DALEquipes();
                dalEquipes.UpdateStatusVeiculoEquipe(siglaEquipe, placa);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EQUIPES> GetEquipesByLocalidade(int localidade)
        {
            try
            {
                DALEquipes dalEquipes = new DALEquipes();
                var equipes = dalEquipes.GetEquipesByLocalidade(localidade);

                return equipes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
