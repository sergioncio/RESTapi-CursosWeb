using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Entities;

namespace Curso.Services
{
    public interface ICursoService
    {
        public IEnumerable<Cursos> GetAll();
        public Cursos GetById(int id);
        public Cursos AddCurso(Cursos curso);

        public Boolean Delete(int id);
    }
}
