using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_ej4.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Salas> Salas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peliculas>()
                .HasKey(p => p.Codigo);
            modelBuilder.Entity<Peliculas>(entity =>
            {
                entity.Property(p => p.Codigo).UseIdentityColumn();
                entity.Property(p => p.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Salas>()
                .HasKey(p => p.Codigo);
            modelBuilder.Entity<Salas>(entity =>
            {
                entity.Property(p => p.Codigo).UseIdentityColumn();
                entity.Property(p => p.Nombre).HasMaxLength(100);
                entity.Property(p => p.IdPelicula).IsRequired();
                
                entity.HasMany(d => d.Peliculas)
                .WithOne(d => d.Salas)
                .HasForeignKey(d => d.Codigo)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }

    }
}
