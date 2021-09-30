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
    public class AutorController : ControllerBase
    {
        protected IAutorService autorService;

        public AutorController(IAutorService autorService)
        {
            this.autorService = autorService;
        }

        [HttpGet]
        public IEnumerable<Autor> GetAutores()
        {
            return autorService.GetAll();
        }

        [HttpGet("GetById/{DNI}")]
        public ActionResult<Autor> GetAutor(String DNI)
        {
            var autor = autorService.GetById(DNI);

            if (autor is null)
            {
                return NotFound();
            }
            else
            { return autor; }

        }

        [HttpPost]
        public ActionResult<Autor> CreateAutor(Autor autor)
        {
            return autorService.AddAutor(autor);
        }

        [HttpDelete("{DNI}")]
        public ActionResult DeleteAutor([FromQuery] String DNI)
        {
            if (autorService.Delete(DNI))
            {
                return NoContent();
            }
            else
            { return NotFound(); }

        }
    }
}
