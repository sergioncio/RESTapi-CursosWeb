using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Entities;

namespace Curso.Services
{
    public interface ICategoriaService
    {
        public IEnumerable<Categoria> GetAll();
        public Categoria GetById(int id);
        public Categoria AddCategoria(Categoria categoria);

        public Boolean Delete(int id);
    }
}
