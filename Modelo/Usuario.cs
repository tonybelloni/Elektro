using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        private string prontuariousuario;
        private string nomeusuario;
        private string senhausuario;
        private string emailusuario;
        private int idtipousuario;
        private string descricaotipousuario;
        private int ativo;
        private int prontuarioFuncionario;

        public string ProntuarioUsuario
        {
            get { return prontuariousuario; }
            set { prontuariousuario = value; }
        }

        public string NomeUsuario
        {
            get { return nomeusuario; }
            set { nomeusuario = value; }
        }

        public string SenhaUsuario
        {
            get { return senhausuario; }
            set { senhausuario = value; }
        }

        public string EmailUsuario
        {
            get { return emailusuario; }
            set { emailusuario = value; }
        }

        public int IdTipoUsuario
        {
            get { return idtipousuario; }
            set { idtipousuario = value; }
        }

        public string DescricaoTipoUsuario
        {
            get { return descricaotipousuario; }
            set { descricaotipousuario = value; }
        }

        public int Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        public int ProntuarioFuncionario
        {
            get { return prontuarioFuncionario; }
            set { prontuarioFuncionario = value; }
        }
    }
}
