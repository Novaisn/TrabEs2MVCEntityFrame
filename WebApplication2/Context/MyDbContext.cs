using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication2.Entities;

namespace WebApplication2.Context
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ativofinanceiro> Ativofinanceiros { get; set; } = null!;
        public virtual DbSet<Codpostal> Codpostals { get; set; } = null!;
        public virtual DbSet<Deposito> Depositos { get; set; } = null!;
        public virtual DbSet<Fundo> Fundos { get; set; } = null!;
        public virtual DbSet<Imovel> Imovels { get; set; } = null!;
        public virtual DbSet<Utilizador> Utilizadors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Database=postgres;Port=5432;User Id=es2;Password=es2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ativofinanceiro>(entity =>
            {
                entity.HasKey(e => e.Idativo)
                    .HasName("ativofinanceiro_pkey");

                entity.ToTable("ativofinanceiro");

                entity.Property(e => e.Idativo).HasColumnName("idativo");

                entity.Property(e => e.Datainicio).HasColumnName("datainicio");

                entity.Property(e => e.Durancao).HasColumnName("durancao");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Taxaimposto)
                    .HasPrecision(5, 5)
                    .HasColumnName("taxaimposto");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Ativofinanceiros)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("ativofinanceiro_idcliente_fkey");
            });

            modelBuilder.Entity<Codpostal>(entity =>
            {
                entity.HasKey(e => e.Codpostal1)
                    .HasName("codpostal_pkey");

                entity.ToTable("codpostal");

                entity.Property(e => e.Codpostal1)
                    .HasMaxLength(20)
                    .HasColumnName("codpostal");

                entity.Property(e => e.Localidade)
                    .HasMaxLength(50)
                    .HasColumnName("localidade");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.HasKey(e => e.Iddeposito)
                    .HasName("deposito_pkey");

                entity.ToTable("deposito");

                entity.Property(e => e.Iddeposito).HasColumnName("iddeposito");

                entity.Property(e => e.Banco)
                    .HasMaxLength(50)
                    .HasColumnName("banco");

                entity.Property(e => e.Idativo).HasColumnName("idativo");

                entity.Property(e => e.Nconta)
                    .HasMaxLength(20)
                    .HasColumnName("nconta");

                entity.Property(e => e.Taxajuro)
                    .HasPrecision(4, 4)
                    .HasColumnName("taxajuro");

                entity.Property(e => e.Titulares)
                    .HasMaxLength(100)
                    .HasColumnName("titulares");

                entity.Property(e => e.Valor)
                    .HasPrecision(14, 4)
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdativoNavigation)
                    .WithMany(p => p.Depositos)
                    .HasForeignKey(d => d.Idativo)
                    .HasConstraintName("deposito_idativo_fkey");
            });

            modelBuilder.Entity<Fundo>(entity =>
            {
                entity.HasKey(e => e.Idfundo)
                    .HasName("fundo_pkey");

                entity.ToTable("fundo");

                entity.Property(e => e.Idfundo).HasColumnName("idfundo");

                entity.Property(e => e.Idativo).HasColumnName("idativo");

                entity.Property(e => e.Montante)
                    .HasPrecision(15, 4)
                    .HasColumnName("montante");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Taxajuro)
                    .HasPrecision(4, 4)
                    .HasColumnName("taxajuro");

                entity.HasOne(d => d.IdativoNavigation)
                    .WithMany(p => p.Fundos)
                    .HasForeignKey(d => d.Idativo)
                    .HasConstraintName("fundo_idativo_fkey");
            });

            modelBuilder.Entity<Imovel>(entity =>
            {
                entity.HasKey(e => e.Idimovel)
                    .HasName("imovel_pkey");

                entity.ToTable("imovel");

                entity.Property(e => e.Idimovel).HasColumnName("idimovel");

                entity.Property(e => e.Codpostal)
                    .HasMaxLength(20)
                    .HasColumnName("codpostal");

                entity.Property(e => e.Idativo).HasColumnName("idativo");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Nporta)
                    .HasMaxLength(10)
                    .HasColumnName("nporta");

                entity.Property(e => e.Rua)
                    .HasMaxLength(50)
                    .HasColumnName("rua");

                entity.Property(e => e.Valorcondo)
                    .HasPrecision(10, 4)
                    .HasColumnName("valorcondo");

                entity.Property(e => e.Valoresti)
                    .HasPrecision(10, 4)
                    .HasColumnName("valoresti");

                entity.Property(e => e.Valorrenda)
                    .HasPrecision(10, 4)
                    .HasColumnName("valorrenda");

                entity.HasOne(d => d.CodpostalNavigation)
                    .WithMany(p => p.Imovels)
                    .HasForeignKey(d => d.Codpostal)
                    .HasConstraintName("imovel_codpostal_fkey");

                entity.HasOne(d => d.IdativoNavigation)
                    .WithMany(p => p.Imovels)
                    .HasForeignKey(d => d.Idativo)
                    .HasConstraintName("imovel_idativo_fkey");
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.Idutilizador)
                    .HasName("utilizador_pkey");

                entity.ToTable("utilizador");

                entity.Property(e => e.Idutilizador).HasColumnName("idutilizador");

                entity.Property(e => e.Codpostal)
                    .HasMaxLength(20)
                    .HasColumnName("codpostal");

                entity.Property(e => e.Ncc)
                    .HasMaxLength(20)
                    .HasColumnName("ncc");

                entity.Property(e => e.Nif)
                    .HasMaxLength(20)
                    .HasColumnName("nif");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Nporta)
                    .HasMaxLength(10)
                    .HasColumnName("nporta");

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .HasColumnName("pass");

                entity.Property(e => e.Rua)
                    .HasMaxLength(50)
                    .HasColumnName("rua");

                entity.Property(e => e.Tipouser).HasColumnName("tipouser");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.CodpostalNavigation)
                    .WithMany(p => p.Utilizadors)
                    .HasForeignKey(d => d.Codpostal)
                    .HasConstraintName("utilizador_codpostal_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
