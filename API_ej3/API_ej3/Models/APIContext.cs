using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_ej3.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public DbSet<Almacenes> Almacenes { get; set; }
        public DbSet<Cajas> Cajas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacenes>()
                .HasKey(p => p.Codigo);
            modelBuilder.Entity<Almacenes>(entity =>
            {
                entity.Property(e => e.Codigo).UseIdentityColumn();
                entity.Property(e => e.Lugar).HasMaxLength(100);
            });

            modelBuilder.Entity<Cajas>()
                .HasKey(p => p.NumReferencia);
            modelBuilder.Entity<Cajas>(entity =>
            {
                entity.Property(p => p.NumReferencia).HasMaxLength(5);
                entity.Property(p => p.Contenido).HasMaxLength(100);
                entity.Property(p => p.IdAlmacen).IsRequired();

                entity.HasOne(d => d.Almacenes)
                .WithMany(d => d.Cajas)
                .HasForeignKey(d => d.IdAlmacen)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }

    }
}
