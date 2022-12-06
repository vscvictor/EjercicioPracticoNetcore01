using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace WSEvaluacion01.Tests.Infraestructura
{
    //[TestClass()]
    internal class PersonaInfraestructuraTest
    {

        SPersona spersona = new Spersona();

        [SetUp]
        public void Setup()
        {
            //_mockIPropiedadesApi = new Mock<IPropiedadesApi>();
            SPersona spersona = new Spersona(); 

        }

        [Test]
        public void ObtenerPersonaAsync_DadaUnaConsultaGetSinBody_CuandoExistaDatos_RetornarTodosLosRegistros() 
        {

        }

    }
}
