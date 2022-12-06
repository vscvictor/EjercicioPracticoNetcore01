using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSEvaluacion01.Entidades.DTOs;
using WSEvaluacion01.Entidades.DTOs.Entrada;
using WSEvaluacion01.Entidades.DTOs.Salida;

namespace WSEvaluacion01.Dominio.Persona
{
    public interface IPersonaInfraestructura
    {
        Task<List<SPersona>> ObtenerPersonasAsync();
        Task<SPersona> ObtenerPersonaAsync(string identificacion);
        Task<SPersona> ActualizarPersona(string Identificacion, EPersona ePersona);
        Task<SPersona> GuardarPersona(EPersona ePersona);
        Task<SResultado> EliminarPersona(string identificacion);
    }
}