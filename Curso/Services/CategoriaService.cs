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
    public class CategoriaService : ICategoriaService
    {
        protected CursoDbContext cursoDbContext;
        protected IMapper autoMapper;
        public CategoriaService(CursoDbContext dbContext, IMapper autoMapper)
        {
            this.cursoDbContext = dbContext;
            this.autoMapper = autoMapper;
        }
        public Categoria AddCategoria(Categoria categoria)
        {
            Categoria category = autoMapper.Map<Categoria>(categoria);
            cursoDbContext.Categoria.Add(category);
            cursoDbContext.SaveChanges();
            return category;
        }

        public bool Delete(int id)
        {
            Categoria categoria = cursoDbContext.Categoria.Find(id);
            if (categoria is null)
            {
                return false;
            }
            else
            {
                cursoDbContext.Remove(categoria);
                cursoDbContext.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Categoria> GetAll()
        {
            return autoMapper.Map<IEnumerable<Categoria>>(cursoDbContext.Categoria);
        }

        public Categoria GetById(int id)
        {
            var categoria = autoMapper.Map<Categoria>(cursoDbContext.Categoria.Find(id));

            if (categoria is null)
            {
                return null;
            }
            else
            { return categoria; }
        }
    }
}
