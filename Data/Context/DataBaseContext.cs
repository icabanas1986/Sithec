using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sithec.Data.Models;

namespace Sithec.Data.Context
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Humano> Humanos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=wisDevs.mssql.somee.com;Initial Catalog=wisDevs;User ID=wisDev_SQLLogin_1;Password=lckq93n6ag");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Humano>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Altura).HasColumnName("altura");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sexo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
