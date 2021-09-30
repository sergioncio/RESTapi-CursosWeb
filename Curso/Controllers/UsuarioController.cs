using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Curso.Entities;
using Curso.Repository;
using Curso.Services;

namespace Curso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        protected IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return usuarioService.GetAll();
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = usuarioService.GetById(id);

            if (usuario is null)
            {
                return NotFound();
            }
            else
            { return usuario; }

        }

        [HttpPost]
        public ActionResult<Usuario> CreateUsuario(Usuario usuario)
        {
            return usuarioService.AddUsuario(usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromQuery] int id)
        {
            if (usuarioService.Delete(id))
            {
                return NoContent();
            }
            else
            { return NotFound(); }

        }

        [HttpGet("Authenticate/{nombreusuario, contraseña}")]
        public Boolean Authenticate ([FromQuery] String nombreusuario, [FromQuery] String contraseña)
        {
            if (usuarioService.Authenticate(nombreusuario, contraseña))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
