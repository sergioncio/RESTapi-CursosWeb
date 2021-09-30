using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Entities;

namespace Curso.Services
{
    public interface IAutorService
    {
        public IEnumerable<Autor> GetAll();
        public Autor GetById(String DNI);
        public Autor AddAutor(Autor curso);
        public Boolean Delete(String DNI);
    }
}
