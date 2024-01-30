using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Models;

public partial class DbAa4919Valencarballo1Context : DbContext
{
    public DbAa4919Valencarballo1Context()
    {
    }

    public DbAa4919Valencarballo1Context(DbContextOptions<DbAa4919Valencarballo1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5112.site4now.net;Initial Catalog=db_aa4919_valencarballo1;User Id=db_aa4919_valencarballo1_admin;Password=valenboca1999");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Perfil__3214EC073F24994C");

            entity.ToTable("Perfil");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Perfils)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Perfil__IdUsuari__3C69FB99");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC072DAAF9E0");

            entity.ToTable("Usuario");

            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
