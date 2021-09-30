using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Entities
{
    public class Cursos
    {
        [Key]
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string url { get; set; }

    }
}
