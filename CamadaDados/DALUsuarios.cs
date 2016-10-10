using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Utilitarios;
using Modelo;

namespace CamadaDados
{
    public class DALUsuarios
    {
        private string _connectionString;
        private SqlCommand _comando;
        private SqlDataAdapter _dataAdapter;
        private DataSet _dset;
        private bool _retval;
        private SqlTransaction _transaction;
        private elektroEntities db;

        public DALUsuarios()
        {
            ClassesAuxiliares ca = new ClassesAuxiliares();
            _connectionString = ca.GetConnectionString();
            db = new elektroEntities();
        }

        public void InsertUsuario(USUARIOS usuario)
        {
            try
            {
                db.USUARIOS.Add(usuario);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALUsuarios - 001 - Erro ao inserir usuário - " + ex.Message);
            }
        }

        public List<USUARIOS> GetUsuarios()
        {
            try
            {
                return db.USUARIOS.AsQueryable().ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("DALUsuários - 002 - Erro ao recuperar usuários - " + ex.Message);
            }
        }

        public List<USUARIOS> GetUsuarios(string valor)
        {
            try
            {
                return db.USUARIOS.Where(u => u.prontuario_usuario.Contains(valor) || u.nome_usuario.Contains(valor)).AsQueryable().ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("DALUsuários - 003 - Erro ao recuperar usuários - " + ex.Message);
            }
        }

        public USUARIOS GetUsuario(string prontuario)
        {
            try
            {
                return db.USUARIOS.Where(u => u.prontuario_usuario == prontuario).AsQueryable().FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw new Exception("DALUsuários - 004 - Erro ao recuperar usuário - " + ex.Message);
            }
        }

        public void UpdateUsuario(USUARIOS usuario)
        {
            try
            {
                USUARIOS usuarioU = db.USUARIOS.Where(u => u.prontuario_usuario == usuario.prontuario_usuario).AsQueryable().FirstOrDefault();
                usuarioU.nome_usuario = usuario.nome_usuario;
                usuarioU.senha_usuario = usuario.senha_usuario;
                usuarioU.email_usuario = usuario.email_usuario;
                usuarioU.id_tipo_usuario = usuario.id_tipo_usuario;
                usuarioU.ativo = usuario.ativo;
                usuarioU.PRONTUARIO = usuario.PRONTUARIO;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("DALUsuarios - 005 - Erro ao alterar usuário - " + ex.Message);
            }
        }

        public void TrocarSenha(string prontuario, string senha)
        {
            try
            {
                USUARIOS usuario = db.USUARIOS.Where(u => u.prontuario_usuario == prontuario).AsQueryable().FirstOrDefault();
                usuario.senha_usuario = senha;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DALUsuarios - 006 - Erro ao trocar senha do usuário - " + ex.Message);
            }
        }
    }
}
