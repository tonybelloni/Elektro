using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using CamadaControle;
using CamadaDados;

namespace Elektro.Formularios
{
    public partial class frmMain : Form
    {
        private CamadaDados.USUARIOS _usuario;
        private string licenca = "";
 
        public CamadaDados.USUARIOS Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmusuarios = new frmUsuarios();
            frmusuarios.MdiParent = this;
            frmusuarios.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.EnableRaisingEvents = false;
            BloquearMenu();
            Utilitarios.ClassesAuxiliares aux = new Utilitarios.ClassesAuxiliares();
            licenca = aux.VerificaLicenca();
            try
            {
                DateTime validade = Convert.ToDateTime(licenca);
                if (validade.Date >= DateTime.Now.Date)
                {
                    toolStripStatusLabel1.Text = String.Format("Versão : {0} - Licença válida até: {1}", Application.ProductVersion, validade.ToShortDateString());
                    this.Text += " - Versão : " + Application.ProductVersion;
                }
                else
                {
                    MessageBox.Show("Licença expirada. Entre em contato com o desenvolvedor do sistema", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show(licenca, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTiposUsuarios frmtiposusuarios = new frmTiposUsuarios();
            frmtiposusuarios.MdiParent = this;
            frmtiposusuarios.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin(this);

            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loginToolStripMenuItem.Visible = false;
                sairToolStripMenuItem.Visible = true;

                VerificarPermissoes();

                trocarMinhaSenhaToolStripMenuItem.Visible = true;

                toolStripStatusLabel1.Text = String.Format("Versão : {0} - Licença válida até: {1} - Usuário : {2} - Perfil : {3}", Application.ProductVersion, licenca, _usuario.nome_usuario, _usuario.TIPOS_USUARIOS.descricao_tipo_usuario);

                /*BLLParametros bllParametro = new BLLParametros();
                PARAMETROS parametros = bllParametro.GetParametro();
                if (parametros != null)
                {
                    fileSystemWatcher1.Path = parametros.DIRETORIO_VIDEO;
                    fileSystemWatcher1.Filter = "*" + parametros.EXTENSAO_VIDEO + "*";
                    fileSystemWatcher1.EnableRaisingEvents = true;
                }*/
            }
        }

        private void camerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCameras cameras = new frmCameras();
            cameras.MdiParent = this;
            cameras.Show();
        }

        private void veiculosStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVeiculos veiculos = new frmVeiculos();
            veiculos.MdiParent = this;
            veiculos.Show();
        }

        private void escalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEscalasCOD escala = new frmEscalasCOD();
            escala.Usuario = _usuario;
            escala.MdiParent = this;
            escala.Show();
        }

        private void tipostrabalhosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposTrabalhos tipostrabalhos = new frmTiposTrabalhos();
            tipostrabalhos.MdiParent = this;
            tipostrabalhos.Show();
        }

        private void equipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEquipes equipes = new frmEquipes();
            equipes.MdiParent = this;
            equipes.Show();
        }

        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncionarios func = new frmFuncionarios();
            func.MdiParent = this;
            func.Show();
        }

        private void reconhecimentoPositivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecPositivo frm = new frmRecPositivo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void naoConformidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNaoConformidade frm = new frmNaoConformidade();
            frm.MdiParent = this;
            frm.Show();
        }

        private void downloadDeArquivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDownloadArquivos frm = new frmDownloadArquivos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void uploadDeArquivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUploadArquivos frm = new frmUploadArquivos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void analisarVídeosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnalisarVideos frm = new frmAnalisarVideos();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void analisarOcorrênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnalisarOcorrencias frm = new frmAnalisarOcorrencias();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void hDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHD frm = new frmHD();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gestãoDeDiscosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void câmerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestaoAlocacaoCameras frm = new frmGestaoAlocacaoCameras();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void copiarImagensParaHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCopiarImagensCamera frm = new frmCopiarImagensCamera();
            frm.MdiParent = this;
            frm.Show();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpresaManutencao frm = new frmEmpresaManutencao();
            frm.MdiParent = this;
            frm.Show();
        }

        private void regiõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegioes frm = new frmRegioes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gerênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerencias frm = new frmGerencias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void supervisõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupervisao frm = new frmSupervisao();
            frm.MdiParent = this;
            frm.Show();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalidades frm = new frmLocalidades();
            frm.MdiParent = this;
            frm.Show();
        }

        private void descarregamentoHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestaoHD frm = new frmGestaoHD();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void manutençãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestaoManutencaoCameras frm = new frmGestaoManutencaoCameras();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void veículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestaoEquipes frm = new frmGestaoEquipes();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente sair do sistema?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
                {
                    if (Application.OpenForms[intIndex] != this)
                        Application.OpenForms[intIndex].Close();
                }

                toolStripStatusLabel1.Text = String.Format("Versão : {0} - Licença válida até: {1}", Application.ProductVersion, licenca);
                loginToolStripMenuItem.Enabled = true;
                BloquearMenu();

                fileSystemWatcher1.EnableRaisingEvents = false;
            }
        }

        public void VerificarPermissoes()
        {
            BLLPermissoesUsuario bllPermissao = new BLLPermissoesUsuario();
            List<PERMISSOES_USUARIO> permissoes = bllPermissao.GetPermissoes(_usuario.TIPOS_USUARIOS.id_tipo_usuario);

            if (permissoes.Count() > 0)
            {
                if (permissoes.Where(l => l.ID_MENU == 1).Count() == 18)
                {
                    cadastrosToolStripMenuItem.Visible = true;
                    reconhecimentoPositivoToolStripMenuItem.Visible = true;
                    camerasToolStripMenuItem.Visible = true;
                    empresasToolStripMenuItem.Visible = true;
                    equipesToolStripMenuItem.Visible = true;
                    escalaToolStripMenuItem.Visible = true;
                    falhasDeEventosDeProcessosToolStripMenuItem.Visible = true;
                    funcionariosToolStripMenuItem.Visible = true;
                    gerênciasToolStripMenuItem.Visible = true;
                    hDToolStripMenuItem.Visible = true;
                    localidadesToolStripMenuItem.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    regiõesToolStripMenuItem.Visible = true;
                    supervisõesToolStripMenuItem.Visible = true;
                    naoConformidadesToolStripMenuItem.Visible = true;
                    tipostrabalhosToolStripMenuItem.Visible = true;
                    tiposDeVeículoToolStripMenuItem.Visible = true;
                    usuáriosToolStripMenuItem.Visible = true;
                    veiculosStripMenuItem.Visible = true;
                }
                else if (permissoes.Where(l => l.ID_MENU == 1).Count() > 0)
                {
                    cadastrosToolStripMenuItem.Visible = true;
                    List<PERMISSOES_USUARIO> cadastros = permissoes.Where(l => l.ID_MENU == 1).ToList();
                    foreach (PERMISSOES_USUARIO p in cadastros)
                    {
                        if (p.ID_SUBMENU == 1)
                            reconhecimentoPositivoToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 2)
                            camerasToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 3)
                            empresasToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 4)
                            equipesToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 5)
                            escalaToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 6)
                            falhasDeEventosDeProcessosToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 7)
                            funcionariosToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 8)
                            gerênciasToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 9)
                            hDToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 10)
                            localidadesToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 11)
                            toolStripMenuItem1.Visible = true;
                        else if (p.ID_SUBMENU == 12)
                            regiõesToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 13)
                            supervisõesToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 14)
                            naoConformidadesToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 15)
                            tipostrabalhosToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 16)
                            tiposDeVeículoToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 17)
                            usuáriosToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 18)
                            veiculosStripMenuItem.Visible = true;
                    }
                }
                else
                {
                    cadastrosToolStripMenuItem.Visible = false;
                }

                if (permissoes.Where(l => l.ID_MENU == 2).Count() == 3)
                {
                    operacionalToolStripMenuItem.Visible = true;
                    descarregamentoHDToolStripMenuItem.Visible = true;
                    registrarOcorrênciasToolStripMenuItem.Visible = true;
                    manutençãoDeCâmerasToolStripMenuItem.Visible = false;
                }
                else if (permissoes.Where(l => l.ID_MENU == 2).Count() > 0)
                {
                    operacionalToolStripMenuItem.Visible = true;
                    List<PERMISSOES_USUARIO> operacionais = permissoes.Where(l => l.ID_MENU == 2).ToList();
                    foreach (PERMISSOES_USUARIO p in operacionais)
                    {
                        if (p.ID_SUBMENU == 1)
                            descarregamentoHDToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 2)
                            registrarOcorrênciasToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 3)
                            manutençãoDeCâmerasToolStripMenuItem.Visible = false;
                    }
                }
                else
                {
                    operacionalToolStripMenuItem.Visible = false;
                }

                if (permissoes.Where(l => l.ID_MENU == 3).Count() == 5)
                {
                    gestãoToolStripMenuItem.Visible = true;
                    analisarOcorrênciasToolStripMenuItem.Visible = true;
                    gestãoDeEquipamentosToolStripMenuItem.Visible = true;
                    sorteiosToolStripMenuItem.Visible = true;
                    veículosToolStripMenuItem.Visible = true;
                    dashboardToolStripMenuItem1.Visible = true;

                    frmDashboard frm = new frmDashboard();
                    frm.MdiParent = this;
                    frm.Usuario = _usuario;
                    frm.Show();
                }
                else if (permissoes.Where(l => l.ID_MENU == 3).Count() > 0)
                {
                    gestãoToolStripMenuItem.Visible = true;
                    List<PERMISSOES_USUARIO> gerenciais = permissoes.Where(l => l.ID_MENU == 3).ToList();
                    foreach (PERMISSOES_USUARIO p in gerenciais)
                    {
                        if (p.ID_SUBMENU == 1)
                            analisarOcorrênciasToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 2)
                            gestãoDeEquipamentosToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 3)
                            veículosToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 4)
                            sorteiosToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 5)
                            dashboardToolStripMenuItem1.Visible = true;
                    }
                }
                else
                {
                    gestãoToolStripMenuItem.Visible = false;
                }

                if (permissoes.Where(l => l.ID_MENU == 4).Count() == 4)
                {
                    relatóriosToolStripMenuItem.Visible = true;
                    hDToolStripMenuItem1.Visible = true;
                    nãoConformidadesToolStripMenuItem.Visible = true;
                    vídeosAnalisadosToolStripMenuItem.Visible = true;
                    vídeosFilmadosToolStripMenuItem.Visible = true;
                }
                else if (permissoes.Where(l => l.ID_MENU == 4).Count() > 0)
                {
                    operacionalToolStripMenuItem.Visible = true;
                    List<PERMISSOES_USUARIO> operacionais = permissoes.Where(l => l.ID_MENU == 2).ToList();
                    foreach (PERMISSOES_USUARIO p in operacionais)
                    {
                        if (p.ID_SUBMENU == 1)
                            hDToolStripMenuItem1.Visible = true;
                        else if (p.ID_SUBMENU == 2)
                            nãoConformidadesToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 3)
                            vídeosAnalisadosToolStripMenuItem.Visible = true;
                        else if (p.ID_SUBMENU == 4)
                            vídeosFilmadosToolStripMenuItem.Visible = true;
                    }
                }
                else
                {
                    relatóriosToolStripMenuItem.Visible = false;
                }
            }
        }

        public void BloquearMenu()
        {
            loginToolStripMenuItem.Visible = true;

            cadastrosToolStripMenuItem.Visible = false;
            camerasToolStripMenuItem.Visible = false;
            equipesToolStripMenuItem.Visible = false;
            escalaToolStripMenuItem.Visible = false;
            falhasDeEventosDeProcessosToolStripMenuItem.Visible = false;
            funcionariosToolStripMenuItem.Visible = false;
            naoConformidadesToolStripMenuItem.Visible = false;
            toolStripMenuItem1.Visible = false;
            reconhecimentoPositivoToolStripMenuItem.Visible = false;
            tipostrabalhosToolStripMenuItem.Visible = false;
            usuáriosToolStripMenuItem.Visible = false;
            veiculosStripMenuItem.Visible = false;
            hDToolStripMenuItem.Visible = false;
            empresasToolStripMenuItem.Visible = false;
            regiõesToolStripMenuItem.Visible = false;
            gerênciasToolStripMenuItem.Visible = false;
            supervisõesToolStripMenuItem.Visible = false;
            localidadesToolStripMenuItem.Visible = false;
            tiposDeVeículoToolStripMenuItem.Visible = false;

            operacionalToolStripMenuItem.Visible = false;
            descarregamentoHDToolStripMenuItem.Visible = false;
            registrarOcorrênciasToolStripMenuItem.Visible = false;
            manutençãoDeCâmerasToolStripMenuItem.Visible = false;

            gestãoToolStripMenuItem.Visible = false;
            analisarOcorrênciasToolStripMenuItem.Visible = false;
            gestãoDeEquipamentosToolStripMenuItem.Visible = false;
            veículosToolStripMenuItem.Visible = false;
            sorteiosToolStripMenuItem.Visible = false;
            dashboardToolStripMenuItem1.Visible = false;

            relatóriosToolStripMenuItem.Visible = false;
            tempoDeTrabalhoCODToolStripMenuItem.Visible = false;
            vídeosComProblemasToolStripMenuItem.Visible = false;
            hDToolStripMenuItem1.Visible = false;
            nãoConformidadesToolStripMenuItem.Visible = false;
            vídeosAnalisadosToolStripMenuItem.Visible = false;
            vídeosFilmadosToolStripMenuItem.Visible = false;

            trocarMinhaSenhaToolStripMenuItem.Visible = false;

            sairToolStripMenuItem.Visible = false;
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            if (Application.OpenForms.OfType<frmCadastrarOcorrencias>().Count() == 0)
            {
                frmCadastrarOcorrencias frm = new frmCadastrarOcorrencias(fileSystemWatcher1.Path);
                frm.MdiParent = this;
                frm.Usuario = _usuario;
                frm.Show();
            }
        }

        private void históricosDeDescarregamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sorteiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSorteios frm = new frmSorteios();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void hDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Relatorios.frmBuscarHDReport frm = new Relatorios.frmBuscarHDReport();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void registrarOcorrênciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarOcorrencias frm = new frmCadastrarOcorrencias();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void nãoConformidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.frmBuscarNaoConformidades frm = new Relatorios.frmBuscarNaoConformidades();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void vídeosFilmadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.frmBuscarVideosFilmados frm = new Relatorios.frmBuscarVideosFilmados();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void vídeosAnalisadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.frmBuscarVideosAnalisados frm = new Relatorios.frmBuscarVideosAnalisados();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void trocarMinhaSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrocarSenha frm = new frmTrocarSenha(_usuario);
            frm.ShowDialog();
        }

        private void gestãoDeEquipamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestaoCameras frm = new frmGestaoCameras();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void tiposDeVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposVeiculos frm = new frmTiposVeiculos();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }

        private void falhasDeEventosDeProcessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFalhasEventosProcessos frm = new frmFalhasEventosProcessos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manutençãoDeCâmerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCamerasFuncionarioManutencao frm = new frmCamerasFuncionarioManutencao();
            frm.MdiParent = this;
            frm.Usuario = _usuario;
            frm.Show();
        }
    }
}
