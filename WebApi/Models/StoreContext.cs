using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi.Models
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductoCategorium> ProductoCategoria { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Store;user=sa1;password=D3s4rr0ll0;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.ImgBack)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ImgFront)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ProductoCategorium>(entity =>
            {
                entity.ToTable("Producto_Categoria");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
