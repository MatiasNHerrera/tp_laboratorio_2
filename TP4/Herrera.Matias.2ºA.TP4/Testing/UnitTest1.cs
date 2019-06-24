using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerificacionListaPaquete()
        {
            Correo c = new Correo();

            if(c.Paquetes == null)
            {
                Assert.Fail("Error, la lista de paquetes no esta instanciada");
            }
        }

        [TestMethod]
        public void VerificacionPaqueteRepetido()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Madero", "5453534");
            Paquete p2 = new Paquete("Delia", "5453534");
            bool validacion = false;

            try
            {
                c += p1;
                c += p2;

                Assert.Fail("Error, no deberia agregar el paquete numero dos");
            }
            catch(Exception e)
            {
                if(e is TrackingIdRepetidoException)
                {
                    validacion = true;
                    Assert.IsTrue(validacion);
                }
                    
            }
        }
    }
}
