using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class TipoUsuario
    {
        private int idtipousuario;
        private string descricaotipousuario;

        public int IdTipoUsuario
        {
            get {return idtipousuario; }
            set { idtipousuario = value;  }
        }

        public string DescricaoTipoUsuario
        {
            get { return descricaotipousuario;  }
            set { descricaotipousuario = value; }
        }
    }
}
