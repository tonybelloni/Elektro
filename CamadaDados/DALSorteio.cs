using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class DALSorteio
    {
        private elektroEntities db;

        public DALSorteio()
        {
            db = new elektroEntities();
        }

        public List<SORTEIOS> GetSorteios()
        {
            try
            {
                return db.SORTEIOS.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteio - 001 - Erro ao recuperar sorteios de vídeos - " + ex.Message);
            }
        }

        public SORTEIOS GetSorteio(int codigo)
        {
            try
            {
                return db.SORTEIOS.Where(l => l.COD_SORTEIO == codigo).AsQueryable().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteio - 002 - Erro ao recuperar sorteio de vídeos - " + ex.Message);
            }
        }

        public void InsereSorteio(SORTEIOS sorteio)
        {
            try
            {
                db.SORTEIOS.Add(sorteio);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteio - 003 - Erro ao inserir sorteio de vídeos - " + ex.Message);
            }
        }

        public List<SORTEIOS> GetSorteios(int codigoSorteio, string numeroHD, string equipe, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                var sorteios = db.SORTEIOS.AsQueryable().ToList();

                if (codigoSorteio != 0)
                    sorteios = sorteios.Where(l => l.COD_SORTEIO == codigoSorteio).AsQueryable().ToList();

                if (numeroHD != "")
                    sorteios = sorteios.Where(l => l.SORTEADOS.Where(d => d.NUMERO_HD == numeroHD).Count() > 0).AsQueryable().ToList();

                if (equipe != "")
                    sorteios = sorteios.Where(l => l.SORTEADOS.Where(d => d.SIGLA_EQUIPE == equipe).Count() > 0).AsQueryable().ToList();

                if (dataInicial != null)
                    sorteios = sorteios.Where(l => l.DATA_REGISTRO >= dataInicial).AsQueryable().ToList();

                if (dataFinal != null)
                    sorteios = sorteios.Where(l => l.DATA_REGISTRO <= dataFinal).AsQueryable().ToList();

                return sorteios;
            }
            catch (Exception ex)
            {
                throw new Exception("DALSorteio - 004 - Erro ao recuperar sorteios de vídeos - " + ex.Message);
            }
        }
    }
}
