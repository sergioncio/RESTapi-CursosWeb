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
    public class CategoriaController : ControllerBase
    {
        protected ICategoriaService categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet]
        public IEnumerable<Categoria> GetCategorias()
        {
            return categoriaService.GetAll();
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Categoria> GetCategoria(int id)
        {
            var categoria = categoriaService.GetById(id);

            if (categoria is null)
            {
                return NotFound();
            }
            else
            { return categoria; }

        }

        [HttpPost]
        public ActionResult<Categoria> CreateCategoria(Categoria categoria)
        {
            return categoriaService.AddCategoria(categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCcategoria([FromQuery] int id)
        {
            if (categoriaService.Delete(id))
            {
                return NoContent();
            }
            else
            { return NotFound(); }

        }
    }
}
