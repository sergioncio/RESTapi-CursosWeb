using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Entities;

namespace Curso.Repository
{
    public class CursoDbContext : DbContext
    {

        public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cursos> Curso { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Categoria>().ToTable("CATEGORIA");
            modelBuilder.Entity<Cursos>().ToTable("CURSOS");
            modelBuilder.Entity<Autor>().ToTable("AUTOR");
        }
    }
}