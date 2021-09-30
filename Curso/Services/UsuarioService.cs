using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Entities;
using Curso.Repository;
using Curso.Services;
using AutoMapper;

namespace Curso.Services
{
    public class UsuarioService : IUsuarioService
    {

        protected CursoDbContext cursoDbContext;
        protected IMapper autoMapper;
        public UsuarioService(CursoDbContext dbContext, IMapper autoMapper)
        {
            this.cursoDbContext = dbContext;
            this.autoMapper = autoMapper;
        }

        public Usuario AddUsuario(Usuario user)
        {
            Usuario usuario = autoMapper.Map<Usuario>(user);
            cursoDbContext.Usuarios.Add(usuario);
            cursoDbContext.SaveChanges();
            return usuario;
        }

        public bool Authenticate(string nombreusuario, string contraseña)
        {
            Usuario usuario = cursoDbContext.Usuarios.FirstOrDefault(user => user.NombreUsuario == nombreusuario && user.Contraseña == contraseña);
            if (usuario is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            return autoMapper.Map<IEnumerable<Usuario>>(cursoDbContext.Usuarios);
        }

        public Usuario GetById(int id)
        {
            var usuario = autoMapper.Map<Usuario>(cursoDbContext.Usuarios.Find(id));

            if (usuario is null)
            {
                return null;
            }
            else
            { return usuario; }
        }

        public bool Delete(int id)
        {
            Usuario usuario = cursoDbContext.Usuarios.Find(id);
            if (usuario is null)
            {
                return false;
            }
            else
            {
                cursoDbContext.Remove(usuario);
                cursoDbContext.SaveChanges();
                return true;
            }
        }
    }
}
