using System;
using Ciemtec_Api.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Ciemtec_Api.Entities
{
    public partial class CiemtecContext : DbContext
    {
        public CiemtecContext()
        {
        }

        public CiemtecContext(DbContextOptions<CiemtecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<RolPermiso> RolPermisos { get; set; }

        public virtual DbSet<PrivilegiosResult> PrivilegiosResult { get; set; }

        public virtual DbSet<PR_GET_PERMISO_VALUE> PR_GET_PERMISO_VALUE_Result { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseMySql(config.GetSection("ConnectionStrings:DefaultConnection").Value, ServerVersion.FromString(config.GetSection("ConnectionStrings:ServerVersion").Value));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrivilegiosResult>(e => e.HasNoKey());

            modelBuilder.Entity<PR_GET_PERMISO_VALUE>(e => e.HasNoKey());

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdentificadorEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleado");

                entity.HasIndex(e => e.CedulaEmpleado, "Cedula_Empleado")
                    .IsUnique();

                entity.HasIndex(e => e.IdentificadorRol, "FK_Empleado_Rol");

                entity.Property(e => e.IdentificadorEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("Identificador_Empleado");

                entity.Property(e => e.ApellidoMaternoEmpleado)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("Apellido_Materno_Empleado")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ApellidoPaternoEmpleado)
                    .HasColumnType("varchar(20)")
                    .HasColumnName("Apellido_Paterno_Empleado")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CedulaEmpleado)
                    .IsRequired()
                    .HasColumnType("varchar(12)")
                    .HasColumnName("Cedula_Empleado")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ContraseniaEmpleado)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    .HasColumnName("Contrasenia_Empleado")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CorreoEmpleado)
                    .HasColumnType("varchar(254)")
                    .HasColumnName("Correo_Empleado")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FechaRegistrado)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Registrado")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdentificadorRol)
                    .HasColumnType("int(11)")
                    .HasColumnName("Identificador_Rol");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("Nombre_Empleado")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UsuarioEmpleado)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasColumnName("Usuario_Empleado")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdentificadorRolNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdentificadorRol)
                    .HasConstraintName("FK_Empleado_Rol");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdentificadorModulo)
                    .HasName("PRIMARY");

                entity.ToTable("modulo");

                entity.Property(e => e.IdentificadorModulo)
                    .HasColumnType("int(11)")
                    .HasColumnName("Identificador_Modulo");

                entity.Property(e => e.NombreModulo)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("Nombre_Modulo")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UrlModulo)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasColumnName("Url_Modulo")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdentificadorPermiso)
                    .HasName("PRIMARY");

                entity.ToTable("permiso");

                entity.HasIndex(e => e.IdentificadorModulo, "FK_Permiso_Modulo");

                entity.Property(e => e.IdentificadorPermiso)
                    .HasColumnType("int(11)")
                    .HasColumnName("Identificador_Permiso");

                entity.Property(e => e.DetallePermiso)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("Detalle_Permiso")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdentificadorModulo)
                    .HasColumnType("int(11)")
                    .HasColumnName("Identificador_Modulo");

                entity.Property(e => e.VariablePermiso)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasColumnName("Variable_Permiso")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdentificadorModuloNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.IdentificadorModulo)
                    .HasConstraintName("FK_Permiso_Modulo");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdentificadorRol)
                    .HasName("PRIMARY");

                entity.ToTable("rol");

                entity.Property(e => e.IdentificadorRol)
                    .HasColumnType("int(11)")
                    .HasColumnName("Identificador_Rol");

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasColumnName("Nombre_Rol")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<RolPermiso>(entity =>
            {
                entity.HasKey(e => new { e.IdentificadorRol, e.IdentificadorPermiso })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("rol_permiso");

                entity.HasIndex(e => e.IdentificadorPermiso, "FK_Manejo_Rol_Permiso");

                entity.Property(e => e.IdentificadorRol)
                    .HasColumnType("int(11)")
                    .HasColumnName("Identificador_Rol");

                entity.Property(e => e.IdentificadorPermiso)
                    .HasColumnType("int(11)")
                    .HasColumnName("Identificador_Permiso");

                entity.Property(e => e.ValorRolPermiso).HasColumnName("Valor_Rol_Permiso");

                entity.HasOne(d => d.IdentificadorPermisoNavigation)
                    .WithMany(p => p.RolPermisos)
                    .HasForeignKey(d => d.IdentificadorPermiso)
                    .HasConstraintName("FK_Manejo_Rol_Permiso");

                entity.HasOne(d => d.IdentificadorRolNavigation)
                    .WithMany(p => p.RolPermisos)
                    .HasForeignKey(d => d.IdentificadorRol)
                    .HasConstraintName("FK_Manejo_Rol_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
