using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;

namespace Laboratorio4.Tests.MoqExamples
{

    public interface IAnimal
    {
        string nombre { get; set; }

        string tipo { get; set; }

        int edad { get; set; }
    }

    public class AnimalController : Controller
    {
        protected IAnimal animal;

        public AnimalController(IAnimal animal)
        {
            this.animal = animal;

        }

        public IAnimal CrearPerroQuemado(IAnimal animal)
        {
            animal.nombre = "Loki";
            animal.tipo = "Lobo";
            animal.edad = 5;

            return animal;
        }
    }

    [TestClass]
    public class EjemploPropio
    {
        [TestMethod]
        public void TestVerificarNombreTipo()
        {
            var animal = new Mock<IAnimal>();
            animal.SetupGet(x => x.nombre).Returns("Cronitos");
            animal.SetupGet(x => x.tipo).Returns("Leon");
            animal.SetupGet(x => x.edad).Returns(5);
            Assert.AreEqual("Cronitos", animal.Object.nombre);
            Assert.AreEqual("Leon", animal.Object.tipo);
        }

        [TestMethod]
        public void TestCrearAnimal()
        {
            var animal = new Mock<IAnimal>();
            var animalController = new AnimalController(animal.Object);
            Assert.IsNotNull(animalController.CrearPerroQuemado(animal.Object));
        }
    }
}
