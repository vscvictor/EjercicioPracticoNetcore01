using WSEvaluacion01.Dominio.Persona;
using WSEvaluacion01.Entidades.DTOs;
using WSEvaluacion01.Entidades.DTOs.Entrada;
using WSEvaluacion01.Entidades.DTOs.Salida;
using WSEvaluacion01.Entidades.Modelo;

namespace WSEvaluacion01.Infraestructura
{
    public class PersonaInfraestructura : IPersonaInfraestructura
    {
        private readonly IPersonaRepositorio _iPersonaRepositorio;
        public PersonaInfraestructura(IPersonaRepositorio iPersonaRepositorio)
        {
            _iPersonaRepositorio = iPersonaRepositorio;
        }

        public async Task<List<SPersona>> ObtenerPersonasAsync()
        {
            List<SPersona> personasResultado = new List<SPersona>();
            var personas = await _iPersonaRepositorio.ObtenerPersonasAsync();
            foreach (var persona in personas)
            {
                personasResultado.Add(new SPersona
                {
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    FechaNacimiento = persona.FechaNacimiento,
                    Identificacion = persona.Identificacion
                });
            }
            return personasResultado;
        }

        public async Task<SPersona> ObtenerPersonaAsync(string identificacion)
        {
            var persona = await _iPersonaRepositorio.ObtenerPersonaAsync(identificacion);
            return new SPersona
            {
                Nombres = persona.Nombres,
                Apellidos = persona.Apellidos,
                FechaNacimiento = persona.FechaNacimiento,
                Identificacion = persona.Identificacion
            };
        }

        public async Task<SPersona> ActualizarPersona(string Identificacion, EPersona ePersona)
        {
            TblPersona persona = new TblPersona
            {
                Nombres = ePersona.Nombres,
                Apellidos = ePersona.Apellidos,
                FechaNacimiento = ePersona.FechaNacimiento,
                Identificacion = ePersona.Identificacion
            };
            var personaResultado = await _iPersonaRepositorio.ActualizarPersona(Identificacion, persona);
            return new SPersona
            {
                Apellidos = personaResultado.Apellidos,
                FechaNacimiento = personaResultado.FechaNacimiento,
                Identificacion = personaResultado.Identificacion,
                Nombres = personaResultado.Nombres
            };
        }

        public async Task<SPersona> GuardarPersona(EPersona ePersona)
        {
            TblPersona tblPersona = new TblPersona
            {
                Nombres = ePersona.Nombres,
                Apellidos = ePersona.Apellidos,
                FechaNacimiento = ePersona.FechaNacimiento,
                Identificacion = ePersona.Identificacion
            };
            var salidaTblPersona = await _iPersonaRepositorio.GuardarPersona(tblPersona);
            return new SPersona
            {
                Nombres = salidaTblPersona.Nombres,
                Apellidos = salidaTblPersona.Apellidos,
                FechaNacimiento = salidaTblPersona.FechaNacimiento,
                Identificacion = salidaTblPersona.Identificacion
            };
        }

        public async Task<SResultado> EliminarPersona(string identificacion)
        {
            return await _iPersonaRepositorio.EliminarPersona(identificacion);
        }

    }
}