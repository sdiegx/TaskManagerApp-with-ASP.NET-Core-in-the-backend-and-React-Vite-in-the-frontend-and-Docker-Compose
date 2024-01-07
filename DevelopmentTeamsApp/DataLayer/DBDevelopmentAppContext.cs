using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer
{
    public partial class DBDevelopmentAppContext : DbContext
    {
        public DBDevelopmentAppContext()
        {
        }

        public DBDevelopmentAppContext(DbContextOptions<DBDevelopmentAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<PersonasProyecto> PersonasProyectos { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<Tarea> Tareas { get; set; } = null!;
        public virtual DbSet<TareasProyecto> TareasProyectos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PK__Personas__E9916EC1BD8388FE");

                entity.Property(e => e.IdPersona)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonasProyecto>(entity =>
            {
                entity.HasKey(e => e.IdPersonaProyecto)
                    .HasName("PK__Personas__8C7794B668E55200");

                entity.ToTable("PersonasProyecto");

                entity.Property(e => e.IdPersonaProyecto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PersonaProyecto");

                entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");

                entity.Property(e => e.IdProyecto).HasColumnName("ID_Proyecto");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonasProyectos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__PersonasP__ID_Pe__4F7CD00D");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.PersonasProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK__PersonasP__ID_Pr__5070F446");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PK__Proyecto__F3BC07D2DEA91B11");

                entity.Property(e => e.IdProyecto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Proyecto");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreProyecto)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK__Tareas__0294B9E2F84EFC26");

                entity.Property(e => e.IdTarea)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Tarea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("ID_Persona");

                entity.Property(e => e.NombreTarea)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Tareas__ID_Perso__49C3F6B7");
            });

            modelBuilder.Entity<TareasProyecto>(entity =>
            {
                entity.HasKey(e => e.IdTareaProyecto)
                    .HasName("PK__TareasPr__9036959208989089");

                entity.ToTable("TareasProyecto");

                entity.Property(e => e.IdTareaProyecto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TareaProyecto");

                entity.Property(e => e.IdProyecto).HasColumnName("ID_Proyecto");

                entity.Property(e => e.IdTarea).HasColumnName("ID_Tarea");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.TareasProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK__TareasPro__ID_Pr__5441852A");

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.TareasProyectos)
                    .HasForeignKey(d => d.IdTarea)
                    .HasConstraintName("FK__TareasPro__ID_Ta__534D60F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
