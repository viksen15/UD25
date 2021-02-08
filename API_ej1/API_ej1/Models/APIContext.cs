using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_ej1.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Fabricantes> Fabricantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fabricantes>()
                .HasKey(p => p.Codigo);
                
            modelBuilder.Entity<Fabricantes>(entity =>
            {
                entity.Property(e => e.Codigo).HasColumnName("Fabricante")
                .UseIdentityColumn();

                entity.Property(e => e.Nombre)
                .HasMaxLength(100);               
            });



            modelBuilder.Entity<Articulos>()
                .HasKey(p => p.Codigo);
                
            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.Property(e => e.Codigo).HasColumnName("Articulo")
                .UseIdentityColumn();

                entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Precio)
                .IsRequired();

                entity.HasOne(d => d.Fabricante)
                .WithMany(p => p.Articulos)
                .HasForeignKey(d => d.IdFabricante)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
