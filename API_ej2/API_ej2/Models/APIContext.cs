using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_ej2.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamentos>()
                .HasKey(p => p.Codigo);

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.Property(e => e.Nombre)
                .HasMaxLength(100);
                entity.Property(e => e.Presupuesto);
            });


            modelBuilder.Entity<Empleados>()
                .HasKey(p => p.DNI);

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.Property(p => p.DNI)
                .IsRequired()
                .HasMaxLength(8);
                entity.Property(p => p.Nombre)
                .HasMaxLength(100);
                entity.Property(p => p.Apellidos)
                .HasMaxLength(255);
                entity.Property(p => p.IdDepartamentos)
                .IsRequired();

                entity.HasOne(d => d.Departamentos)
                .WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDepartamentos)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
            });
        }

    }
}
