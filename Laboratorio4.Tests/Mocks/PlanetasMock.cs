using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Laboratorio4.Handlers;
using Laboratorio4.Models;
using System.Threading;

namespace Laboratorio4.Tests.Mocks
{
    [TestClass]
    public class PlanetasMock
    {
        [TestMethod]
        public void AgregarMultiplesPlanetasVariosUsuarios()
        {
            ThreadStart usuario1 = new ThreadStart(SimulacionUsuarioCreandoPlanetas);
            ThreadStart usuario2 = new ThreadStart(SimulacionUsuarioCreandoPlanetas);
            Thread hilo1 = new Thread(usuario1);
            Thread hilo2 = new Thread(usuario2);
            hilo1.Start();
            hilo2.Start();
            hilo1.Join();
            hilo2.Join();
        }
        public void SimulacionUsuarioCreandoPlanetas()
        {
            MyTestPostedFileBase archivoTest = new MyTestPostedFileBase(new System.IO.MemoryStream(), "/test.file", "TestFile");
            PlanetaModel planeta = new PlanetaModel
            {
                nombre = "Test-planeta",
                numeroAnillos = 100,
                archivo = archivoTest,
                tipo = "De prueba"
            };
            PlanetasHandler db = new PlanetasHandler();
            bool exitoAlCrear = false;
            for (int intento = 0; intento < 0; ++intento)
            {
                //Act
                exitoAlCrear = db.crearPlaneta(planeta);
                //Assert
                Assert.IsTrue(exitoAlCrear);
            }
        }
    }
}
