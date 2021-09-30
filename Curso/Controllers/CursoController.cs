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
    public class CursoController : ControllerBase
    {
        protected ICursoService cursoService;

        public CursoController(ICursoService cursoService)
        {
            this.cursoService = cursoService;
        }

        [HttpGet]
        public IEnumerable<Cursos> GetCursos()
        {
            return cursoService.GetAll();
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Cursos> GetCurso(int id)
        {
            var curso = cursoService.GetById(id);

            if (curso is null)
            {
                return NotFound();
            }
            else
            { return curso; }

        }

        [HttpPost]
        public ActionResult<Cursos> CreateCurso(Cursos curso)
        {
            return cursoService.AddCurso(curso);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCurso([FromQuery] int id)
        {
            if (cursoService.Delete(id))
            {
                return NoContent();
            }
            else
            { return NotFound(); }

        }
    }
}
