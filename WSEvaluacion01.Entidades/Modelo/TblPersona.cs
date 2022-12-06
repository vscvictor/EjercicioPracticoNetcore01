namespace WSEvaluacion01.Entidades.Modelo
{
    public partial class TblPersona
    {
        public int PrsId { get; set; }

        public string Identificacion { get; set; } = null!;

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public DateTime? FechaNacimiento { get; set; }
    }
}