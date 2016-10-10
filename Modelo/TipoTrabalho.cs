using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class TipoTrabalho
    {
        private int idtipotrabalho;
        private string descricaotipotrabalho;

        public int IdTipoTrabalho
        {
            get { return idtipotrabalho; }
            set { idtipotrabalho = value; }
        }

        public string DescricaoTipoTrabalho
        {
            get { return descricaotipotrabalho; }
            set { descricaotipotrabalho = value; }
        }
    }
}
