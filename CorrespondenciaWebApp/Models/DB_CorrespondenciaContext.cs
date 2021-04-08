using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CorrespondenciaWebApp.Models
{
    public partial class DB_CorrespondenciaContext : DbContext
    {
        public DB_CorrespondenciaContext(DbContextOptions<DB_CorrespondenciaContext> options) : base(options)
        {
        }

        public virtual DbSet<Auditorium> Auditoria { get; set; }
        public virtual DbSet<Comunicacion> Comunicacions { get; set; }
        public virtual DbSet<ContactoPersona> ContactoPersonas { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Operacion> Operacions { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolUsuario> RolUsuarios { get; set; }
        public virtual DbSet<TipoComunicacion> TipoComunicacions { get; set; }
        public virtual DbSet<TipoContacto> TipoContactos { get; set; }
        public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }
        public virtual DbSet<TipoOperacion> TipoOperacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=DB_Correspondencia;Integrated Security=True");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Auditorium>(entity =>
            {
                entity.HasKey(e => e.AuditoriaId)
                    .HasName("pk_AuditoriaId");

                entity.Property(e => e.OperacionId).HasColumnName("OperacionId@");

                entity.Property(e => e.Tabla)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioId@");

                entity.HasOne(d => d.Operacion)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.OperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AudOperacionId@");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AudUsuarioId@");
            });

            modelBuilder.Entity<Comunicacion>(entity =>
            {
                entity.ToTable("Comunicacion");

                entity.Property(e => e.Consecutivo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.NombreArchivo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonaIdDestino).HasColumnName("PersonaIdDestino@");

                entity.Property(e => e.PersonaIdRemite).HasColumnName("PersonaIdRemite@");

                entity.Property(e => e.TipoComunicacionId).HasColumnName("TipoComunicacionId@");

                entity.Property(e => e.UsuarioIdRegistra).HasColumnName("UsuarioIdRegistra@");

                entity.HasOne(d => d.PersonaIdDestinoNavigation)
                    .WithMany(p => p.ComunicacionPersonaIdDestinoNavigations)
                    .HasForeignKey(d => d.PersonaIdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ComPersonaIdDestino@");

                entity.HasOne(d => d.PersonaIdRemiteNavigation)
                    .WithMany(p => p.ComunicacionPersonaIdRemiteNavigations)
                    .HasForeignKey(d => d.PersonaIdRemite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ComPersonaIdRemite@");

                entity.HasOne(d => d.TipoComunicacion)
                    .WithMany(p => p.Comunicacions)
                    .HasForeignKey(d => d.TipoComunicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ComTipoComunicacionId@");

                entity.HasOne(d => d.UsuarioIdRegistraNavigation)
                    .WithMany(p => p.Comunicacions)
                    .HasForeignKey(d => d.UsuarioIdRegistra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ComUsuarioIdRegistra@");
            });

            modelBuilder.Entity<ContactoPersona>(entity =>
            {
                entity.HasKey(e => e.ContactoId)
                    .HasName("pk_ContactoId");

                entity.ToTable("ContactoPersona");

                entity.Property(e => e.Contacto)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PersonaId).HasColumnName("PersonaId@");

                entity.Property(e => e.TipoContactoId).HasColumnName("TipoContactoId@");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.ContactoPersonas)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ConPersonaId@");

                entity.HasOne(d => d.TipoContacto)
                    .WithMany(p => p.ContactoPersonas)
                    .HasForeignKey(d => d.TipoContactoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ConTipoContactoId@");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("Modulo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreModulo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.ToTable("Operacion");

                entity.Property(e => e.ModuloId).HasColumnName("ModuloId@");

                entity.Property(e => e.RolId).HasColumnName("RolId@");

                entity.Property(e => e.TipoOperacionId).HasColumnName("TipoOperacionId@");

                entity.HasOne(d => d.Modulo)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.ModuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OpeModuloId@");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OpeRolId@");

                entity.HasOne(d => d.TipoOperacion)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.TipoOperacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OpeTipoOperacionId@");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdenticacionId).HasColumnName("TipoIdenticacionId@");

                entity.HasOne(d => d.TipoIdenticacion)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.TipoIdenticacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TipoIdenticacionId@");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.ToTable("RolUsuario");

                entity.Property(e => e.RolId).HasColumnName("RolId@");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioId@");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RolId@");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RolUsuarioId@");
            });

            modelBuilder.Entity<TipoComunicacion>(entity =>
            {
                entity.ToTable("TipoComunicacion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prefijo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoContacto>(entity =>
            {
                entity.ToTable("TipoContacto");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoIdentificacion>(entity =>
            {
                entity.HasKey(e => e.TipoIdenticacionId)
                    .HasName("pk_TipoIdenticacion");

                entity.ToTable("TipoIdentificacion");

                entity.HasComment("Tipos de Identificación");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoOperacion>(entity =>
            {
                entity.ToTable("TipoOperacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
