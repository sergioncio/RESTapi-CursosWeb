using Curso.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Services
{
    public interface IUsuarioService
    {
        public Boolean Authenticate(String usuario, String contraseña);
        public IEnumerable<Usuario> GetAll();
        public Usuario GetById(int id);
        public Usuario AddUsuario(Usuario user);

        public Boolean Delete(int id);
    }
}
