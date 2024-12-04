using CCVProyecto2P2.Models;
using CCVProyecto2P2.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.DataAccess
{
    public class DbbContext : DbContext
    {
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDB = $"Filename ={ConexionDB.DevolverRuta("proyectooo.db")}";
            Console.WriteLine($"Ruta de la base de datos: {ConexionDB.DevolverRuta("proyectooo.db")}");

            optionsBuilder.UseSqlite(conexionDB);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Grado).HasMaxLength(50);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.Property(p => p.Materia).HasMaxLength(100);
            });
        }
    }
}
