using Microsoft.EntityFrameworkCore;
using WSEvaluacion01.Entidades.Modelo;

namespace WSEvaluacion01.Repositorio.Contexto
{

    public partial class BddEjercicioContext : DbContext
{
    public BddEjercicioContext()
    {
    }

    public BddEjercicioContext(DbContextOptions<BddEjercicioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblPersona> TblPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BT361492L\\SQLEXPRESS;Database=BDD_EJERCICIO; User ID=SA;Password=Pichincha1;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblPersona>(entity =>
        {
            entity.HasKey(e => e.PrsId).HasName("PK__TBL_PERS__218D9B389E39557D");

            entity.ToTable("TBL_PERSONA");

            entity.HasIndex(e => e.Identificacion, "UQ__TBL_PERS__6F9F6A3A97D9C6E2").IsUnique();

            entity.Property(e => e.PrsId).HasColumnName("PRS_ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.FechaNacimiento)
                .HasDefaultValueSql("('1999/01/01')")
                .HasColumnType("date")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(15)
                .HasColumnName("IDENTIFICACION");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("NOMBRES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

}