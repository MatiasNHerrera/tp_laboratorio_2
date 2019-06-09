using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void validacionExceptionSinProfesor()
        {
            Universidad u = new Universidad();
            Profesor p = new Profesor(7, "Jose", "Hernandez", "23442114", Persona.ENacionalidad.Argentino);

            try
            {
                u += p;
                u += Universidad.EClases.Laboratorio;
                Assert.Fail("Error, si no se encuentra un profesor que de esa clase, no debe agregarse");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }

        }

        [TestMethod]
        public void validacionExceptionNacionalidadInvalida()
        {
            Universidad u = new Universidad();

            try
            {
                Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234454",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);

                Alumno a2 = new Alumno(3, "José", "Gutierrez", "12234456",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);

                Assert.Fail("Error, el DNI no condice con la nacionalidad");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

        }

        [TestMethod]
        public void validacionDni()
        {
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234454",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            Assert.IsInstanceOfType(i1.DNI, typeof(int));
            
        }

        [TestMethod]
        public void validacionAtributosNulos()
        {
            Alumno a = new Alumno(6, "Matias", "Herrera", "42038513", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsNotNull(a.Nombre);
            Assert.IsNotNull(a.Apellido);


        }

    }
}
