namespace WSEvaluacion01.Entidades.DTOs
{
    public class SPersona
    {

        public string Identificacion { get; set; } = null!;

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public DateTime? FechaNacimiento { get; set; }
        
    }
}