using Microsoft.EntityFrameworkCore;
using WSEvaluacion01.Dominio.Persona;
using WSEvaluacion01.Entidades;
using WSEvaluacion01.Entidades.DTOs.Salida;
using WSEvaluacion01.Entidades.Excepciones;
using WSEvaluacion01.Entidades.Modelo;
using WSEvaluacion01.Repositorio.Contexto;

namespace WSEvaluacion01.Repositorio
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly BddEjercicioContext _context;
        public PersonaRepositorio(BddEjercicioContext context)
        {
            _context = context;
        }

        public async Task<List<TblPersona>> ObtenerPersonasAsync()
        {
            return await _context.TblPersonas.ToListAsync();
        }

        public async Task<TblPersona> ObtenerPersonaAsync(string identificacion)
        {
            try
            {
                var personaResultado = await _context.TblPersonas.SingleOrDefaultAsync(b => b.Identificacion == identificacion);
                if (personaResultado == null)
                {
                    throw new Error { CodigoError = EConstantes.CodigoErrorIdentificacionNoExiste, MensajeError = EConstantes.DescripcionErrorIdentificacionNoExiste };
                }
                return personaResultado;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }


        }

        public async Task<TblPersona> ActualizarPersona(string identificacion, TblPersona tblPersona)
        {
            if (identificacion != tblPersona.Identificacion)
            {
                throw new Error { CodigoError = EConstantes.CodigoErrorIdentificacionDiferenteConEntidad, MensajeError = EConstantes.DescripcionErrorIdentificacionDiferenteConEntidad };
            }
            try
            {
                var personaBdd = _context.TblPersonas.Where(x => x.Identificacion == identificacion).FirstOrDefault();
                if (personaBdd == null)
                {
                    throw new Error { CodigoError = EConstantes.CodigoErrorIdentificacionNoExiste, MensajeError = EConstantes.DescripcionErrorIdentificacionNoExiste };
                }
                personaBdd.Nombres = tblPersona.Nombres;
                personaBdd.Apellidos = tblPersona.Apellidos;
                personaBdd.FechaNacimiento = tblPersona.FechaNacimiento;
                _context.Entry(personaBdd).State = EntityState.Modified;
                int registrosAfectados = await _context.SaveChangesAsync();
                if (registrosAfectados < 1)
                {
                    throw new Error { CodigoError = EConstantes.CodigoErrorCambioNoRealizado, MensajeError = EConstantes.DescripcionErrorCambioNoRealizado };
                }

                return tblPersona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TblPersona> GuardarPersona(TblPersona tblPersona)
        {
            try
            {
                if (ExistePersonaPorIdentificacion(tblPersona.Identificacion))
                {
                    throw new Error { CodigoError = EConstantes.CodigoErrorIdentificacionNoExiste, MensajeError = EConstantes.DescripcionErrorIdentificacionNoExiste };
                }
                _context.TblPersonas.Add(tblPersona);
                await _context.SaveChangesAsync();
                return tblPersona;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public async Task<SResultado> EliminarPersona(string identificacion)
        {
            try
            {
                var tblPersona = _context.TblPersonas.Where(x => x.Identificacion == identificacion).FirstOrDefault();
                if (tblPersona == null)
                {
                    throw new Error { CodigoError = EConstantes.CodigoErrorIdentificacionNoExiste, MensajeError = EConstantes.DescripcionErrorIdentificacionNoExiste };
                }
                _context.TblPersonas.Remove(tblPersona);
                await _context.SaveChangesAsync();
                return new SResultado { Codigo = EConstantes.CodigoErrorOk, Mensaje = EConstantes.DescripcionErrorOk };
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private bool ExistePersona(int id)
        {
            return _context.TblPersonas.Any(e => e.PrsId == id);
        }

        private bool ExistePersonaPorIdentificacion(string identificacion)
        {
            return _context.TblPersonas.Any(e => e.Identificacion == identificacion.ToString());
        }

    }
}