using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Camera
    {
        private string codigocamera;
        private string bpmcamera;
        private string codigobarracamera;
        private int ativo;
        private string status;
        private DateTime dataBaixa;
        private string motivoBaixa;
        private string usuarioBaixa;
        private DateTime dataAquisicao;
        private int codigoEmpresa;

        public string CodigoCamera
        {
            get { return codigocamera; }
            set { codigocamera = value; }
        }

        public string BpmCamera
        {
            get { return bpmcamera; }
            set { bpmcamera = value; }
        }

        public string CodigoBarraCamera
        {
            get { return codigobarracamera; }
            set { codigobarracamera = value; }
        }

        public int Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime DataBaixa
        {
            get { return dataBaixa; }
            set { dataBaixa = value; }
        }

        public string MotivoBaixa
        {
            get { return motivoBaixa; }
            set { motivoBaixa = value; }
        }

        public string UsuarioBaixa
        {
            get { return usuarioBaixa; }
            set { usuarioBaixa = value; }
        }

        public DateTime DataAquisicao
        {
            get { return dataAquisicao; }
            set { dataAquisicao = value; }
        }

        public int CodigoEmpresa
        {
            get { return codigoEmpresa; }
            set { codigoEmpresa = value; }
        }
    }
}
