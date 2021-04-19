using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CEPAPI5.Models;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace CEPAPI5.Models
{
    public partial class CEPContext : DbContext
    {
        public CEPContext()
        {
        }

        public CEPContext(DbContextOptions<CEPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bairro> Bairros { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }

        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.ToTable("bairro");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(95);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(95)
                    .HasColumnName("slug");

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.Bairros)
                    .HasForeignKey(d => d.CdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bairro_Tocidade");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("cidade");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(95);

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(95);

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.CdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cidade_Toestado");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CdPostal).HasMaxLength(15);

                entity.Property(e => e.Ddd).HasColumnName("DDD");

                entity.Property(e => e.Endereco1)
                    .HasMaxLength(255)
                    .HasColumnName("Endereco");

                entity.Property(e => e.Latitude).HasMaxLength(20);

                entity.Property(e => e.Longitude).HasMaxLength(20);

                entity.HasOne(d => d.Bairro)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.CdBairro)
                    .HasConstraintName("FK_endereco_Tobairro");

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.CdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_endereco_Tocidade");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("estado");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(95);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<CEPAPI5.Models.EnderecoToAPI> EnderecoToAPI { get; set; }
    }
}
