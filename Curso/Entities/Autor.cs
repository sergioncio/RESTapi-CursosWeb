using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Entities
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public string DNI { get; set; }
        public string nombre { get; set; }
        public int calificacion { get; set; }
    }
}
