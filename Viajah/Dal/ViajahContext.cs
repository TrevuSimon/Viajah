using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Viajah.Models
{
    public partial class ViajahContext : DbContext
    {
        public ViajahContext()
        {
        }

        public ViajahContext(DbContextOptions<ViajahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PontoTuristicoFoto> PontoTuristicoFoto { get; set; }
        public virtual DbSet<Regiao> Regiao { get; set; }
        public virtual DbSet<RegiaoComentario> RegiaoComentario { get; set; }
        public virtual DbSet<RegiaoFoto> RegiaoFoto { get; set; }
        public virtual DbSet<RegiaoHistoria> RegiaoHistoria { get; set; }
        public virtual DbSet<RegiaoPontoTuristico> RegiaoPontoTuristico { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioDetalhe> UsuarioDetalhe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Viajah;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PontoTuristicoFoto>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.HasOne(d => d.IdPontoTuristicoNavigation)
                    .WithMany(p => p.PontoTuristicoFoto)
                    .HasForeignKey(d => d.IdPontoTuristico)
                    .HasConstraintName("FKPontoTuristicoFotoRegiaoPontoTuristico");
            });

            modelBuilder.Entity<RegiaoComentario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RegiaoComentario)
                    .HasForeignKey<RegiaoComentario>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRegiaoComentarioRegiao");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.RegiaoComentario)
                    .HasForeignKey<RegiaoComentario>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRegiaoComentarioUsuario");
            });

            modelBuilder.Entity<RegiaoFoto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RegiaoFoto)
                    .HasForeignKey<RegiaoFoto>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRegiaoFotoRegiao");
            });

            modelBuilder.Entity<RegiaoHistoria>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DataPostagem).HasColumnType("datetime");

                entity.HasOne(d => d.IdRegiaoNavigation)
                    .WithMany(p => p.RegiaoHistoria)
                    .HasForeignKey(d => d.IdRegiao)
                    .HasConstraintName("FKRegiaoHistoriaRegiao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RegiaoHistoria)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FKRegiaoHistoriaUsuario");
            });

            modelBuilder.Entity<RegiaoPontoTuristico>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RegiaoPontoTuristico)
                    .HasForeignKey<RegiaoPontoTuristico>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRegiaoPontoTuristicoRegiao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Login).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioDetalhe>(entity =>
            {
                entity.Property(e => e.Celular).HasMaxLength(10);

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Nome).HasMaxLength(10);

                entity.Property(e => e.Pais).HasMaxLength(10);

                entity.Property(e => e.Sexo).HasMaxLength(10);

                entity.Property(e => e.Sobrenome).HasMaxLength(10);

                entity.Property(e => e.Telefone).HasMaxLength(10);

                entity.HasOne(d => d.IdRegiaoNavigation)
                    .WithMany(p => p.UsuarioDetalhe)
                    .HasForeignKey(d => d.IdRegiao)
                    .HasConstraintName("FK_UsuarioDetalhe_Regiao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioDetalhe)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_UsuarioDetalhe_Usuario");
            });
        }
    }
}
