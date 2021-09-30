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
    public class AutorService : IAutorService
    {
        protected CursoDbContext cursoDbContext;
        protected IMapper autoMapper;
        public AutorService(CursoDbContext dbContext, IMapper autoMapper)
        {
            this.cursoDbContext = dbContext;
            this.autoMapper = autoMapper;
        }
        public Autor AddAutor(Autor autor)
        {
            Autor profesor = autoMapper.Map<Autor>(autor);
            cursoDbContext.Autor.Add(profesor);
            cursoDbContext.SaveChanges();
            return profesor;
        }

        public Boolean Delete(string DNI)
        {
            Autor autor = cursoDbContext.Autor.FirstOrDefault(autor => autor.DNI == DNI);
            if (autor is null)
            {
                return false;
            }
            else
            {
                cursoDbContext.Remove(autor);
                cursoDbContext.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Autor> GetAll()
        {
            return autoMapper.Map<IEnumerable<Autor>>(cursoDbContext.Autor);
        }

        public Autor GetById(String DNI)
        {
            var autor = cursoDbContext.Autor.FirstOrDefault(autor => autor.DNI == DNI);

            if (autor is null)
            {
                return null;
            }
            else
            { return autor; }
        }
    }
}
