namespace WSEvaluacion01.Entidades.Excepciones
{
    public class Error : Exception
    {
        public string? CodigoError { get; set; }
        public string? MensajeError { get; set; }
    }
}