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
    public class CursoService : ICursoService
    {
        protected CursoDbContext cursoDbContext;
        protected IMapper autoMapper;
        public CursoService(CursoDbContext dbContext, IMapper autoMapper)
        {
            this.cursoDbContext = dbContext;
            this.autoMapper = autoMapper;
        }
        public Cursos AddCurso(Cursos curso)
        {
            Cursos curse = autoMapper.Map<Cursos>(curso);
            cursoDbContext.Curso.Add(curse);
            cursoDbContext.SaveChanges();
            return curse;
        }

        public bool Delete(int id)
        {
            Cursos curso = cursoDbContext.Curso.Find(id);
            if (curso is null)
            {
                return false;
            }
            else
            {
                cursoDbContext.Remove(curso);
                cursoDbContext.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Cursos> GetAll()
        {
            return autoMapper.Map<IEnumerable<Cursos>>(cursoDbContext.Curso);
        }

        public Cursos GetById(int id)
        {
            var curso = autoMapper.Map<Cursos>(cursoDbContext.Curso.Find(id));

            if (curso is null)
            {
                return null;
            }
            else
            { return curso; }
        }
    }
}
