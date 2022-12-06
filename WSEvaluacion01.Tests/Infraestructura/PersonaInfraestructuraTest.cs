using Moq;
using WSEvaluacion01.Dominio.Persona;
using WSEvaluacion01.Entidades.DTOs;
using WSEvaluacion01.Entidades.Modelo;
using WSEvaluacion01.Infraestructura;

namespace WSEvaluacion01.Tests.Infraestructura
{
    internal class PersonaInfraestructuraTest
    {

        private IPersonaInfraestructura _iPersonaInfraestructura;
        private Mock<IPersonaRepositorio> _mockIPersonaRepositorio;

        private SPersona spersona;
        private TblPersona tblPersona;

        private List<TblPersona> lstTblPersona;
        private List<SPersona> lstSPersona;

        [SetUp]
        public void Setup()
        {


            _mockIPersonaRepositorio = new Mock<IPersonaRepositorio>();
            spersona = new SPersona
            {
                Identificacion = "1717720872",
                Nombres = "Victor",
                Apellidos = "Sosapanta",
                FechaNacimiento = DateTime.Now
            };
            tblPersona = new TblPersona
            {
                Identificacion = "1717720872",
                Nombres = "Victor",
                Apellidos = "Sosapanta",
                FechaNacimiento = DateTime.Now
            };

            lstTblPersona = new List<TblPersona>();
            lstTblPersona.Add(tblPersona);
            lstSPersona = new List<SPersona>();
            lstSPersona.Add(spersona);

        }

        [Test]
        public void ObtenerPersonaAsync_DadaUnaIdentificacion_CuandoExistePersona_RetornaPersonaBuscada()
        {
            _mockIPersonaRepositorio.Setup(x => x.ObtenerPersonaAsync(It.IsAny<string>())).ReturnsAsync(tblPersona);
            _iPersonaInfraestructura = new PersonaInfraestructura(_mockIPersonaRepositorio.Object);
            Assert.DoesNotThrowAsync(() => _iPersonaInfraestructura.ObtenerPersonaAsync("1717720872"));
        }

        [Test]
        public void ObtenerPersonasAsync_AlComsumirElMetodo_CuandoExistenRegistros_RetornaTodosLosRegistros()
        {
            _mockIPersonaRepositorio.Setup(x => x.ObtenerPersonasAsync()).ReturnsAsync(lstTblPersona);
            _iPersonaInfraestructura = new PersonaInfraestructura(_mockIPersonaRepositorio.Object);
            Assert.DoesNotThrowAsync(() => _iPersonaInfraestructura.ObtenerPersonasAsync());
        }

    }
}
