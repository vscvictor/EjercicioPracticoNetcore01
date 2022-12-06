using Microsoft.AspNetCore.Mvc;
using WSEvaluacion01.Dominio.Persona;
using WSEvaluacion01.Entidades;
using WSEvaluacion01.Entidades.DTOs;
using WSEvaluacion01.Entidades.DTOs.Entrada;
using WSEvaluacion01.Entidades.DTOs.Salida;
using WSEvaluacion01.Entidades.Excepciones;

namespace WSEvaluacion01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaInfraestructura _iPersonaInfraestructura;

        public PersonaController(IPersonaInfraestructura iPersonaInfraestructura)
        {
            _iPersonaInfraestructura = iPersonaInfraestructura;
        }

        [HttpGet]
        //[Route(EConstantes.ConsultarEventosCliente01Async)]
        public async Task<ActionResult<IEnumerable<SPersona>>> ObtenerPersonas()
        {
            try
            {
                return await _iPersonaInfraestructura.ObtenerPersonasAsync();
            }
            catch (Error error)
            {
                return BadRequest(new SResultado{Codigo = error.CodigoError, Mensaje = error.MensajeError});
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Error { CodigoError = EConstantes.CodigoErrorGenerico, MensajeError = ex.Message });
            }
        }

        [HttpGet("{identificacion}")]
        public async Task<ActionResult<SPersona>> ObtenerPersonaAsync([FromRoute] string identificacion)
        {
            try
            {
                return await _iPersonaInfraestructura.ObtenerPersonaAsync(identificacion);
            }
            catch (Error error)
            {
                return NotFound(new SResultado{Codigo = error.CodigoError, Mensaje = error.MensajeError});
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Error { CodigoError = EConstantes.CodigoErrorGenerico, MensajeError = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<SPersona>> GuardarPersona([FromBody] EPersona ePersona)
        {
            try
            {
                return await _iPersonaInfraestructura.GuardarPersona(ePersona);
            }
            catch (Error error)
            {
                return NotFound(new SResultado{Codigo = error.CodigoError, Mensaje = error.MensajeError});
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Error { CodigoError = EConstantes.CodigoErrorGenerico, MensajeError = ex.Message });
            }
        }

        [HttpPut("{identificacion}")]
        public async Task<ActionResult<SPersona>> ActualizarPersona([FromRoute] string identificacion , [FromBody] EPersona ePersona)
        {
            try
            {
                return await _iPersonaInfraestructura.ActualizarPersona(identificacion, ePersona);
            }
            catch (Error error)
            {
                return NotFound(new SResultado{Codigo = error.CodigoError, Mensaje = error.MensajeError});
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Error { CodigoError = EConstantes.CodigoErrorGenerico, MensajeError = ex.Message });
            }
        }

        [HttpDelete("{identificacion}")]
        public async Task<ActionResult<SResultado>> EliminarPersona([FromRoute] string identificacion )
        {
            try
            {
                return await _iPersonaInfraestructura.EliminarPersona(identificacion);
            }
            catch (Error error)
            {
                return NotFound(new SResultado{Codigo = error.CodigoError, Mensaje = error.MensajeError});
            }
            catch (System.Exception ex)
            {
                return BadRequest(new Error { CodigoError = EConstantes.CodigoErrorGenerico, MensajeError = ex.Message });
            }
        }


    }
}