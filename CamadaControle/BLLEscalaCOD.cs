using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaControle;
using CamadaDados;

namespace CamadaControle
{
    public class BLLEscalaCOD
    {
        public DALEscalaCOD dalEscala;

        public BLLEscalaCOD()
        {
            dalEscala = new DALEscalaCOD();
        }

        public List<ESCALA_COD> GetEscalas(string valor)
        {
            try
            {
                if (valor == "")
                {
                    return dalEscala.GetEscalas();
                }
                else
                {
                    return dalEscala.GetEscalas(valor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ESCALA_COD> GetEscalas(string equipe, string datainicial, string datafinal)
        {
            try
            {
                return dalEscala.GetEscalas(equipe, datainicial, datafinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ESCALA_COD> GetEscalas(string equipe, string datainicial, string datafinal, int processo)
        {
            try
            {
                return dalEscala.GetEscalas(equipe, datainicial, datafinal, processo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void InsertEscala(ESCALA_COD escala)
        {
            try
            {
                dalEscala.InsertEscala(escala);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
