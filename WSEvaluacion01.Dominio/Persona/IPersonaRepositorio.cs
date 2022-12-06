using WSEvaluacion01.Entidades.DTOs.Salida;
using WSEvaluacion01.Entidades.Modelo;

namespace WSEvaluacion01.Dominio.Persona
{
    public interface IPersonaRepositorio
    {
        Task<List<TblPersona>> ObtenerPersonasAsync();
        Task<TblPersona> ObtenerPersonaAsync(string identificacion);
        Task<TblPersona> ActualizarPersona(string identificacion, TblPersona tblPersona);
        Task<TblPersona> GuardarPersona(TblPersona tblPersona);
        Task<SResultado> EliminarPersona(string identificacion);
    }
}