using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;

namespace Laboratorio4.Tests.MoqExamples
{
    public interface IDogsUpdate
    {
        bool Update(string breed);

        string nombre { get; set; }
    }

    public class HuskyController: Controller
    {
        protected IDogsUpdate updateDogsService;

        public HuskyController(IDogsUpdate updateDogsService)
        {
            this.updateDogsService = updateDogsService;
            
        }

        public ViewResult UpdateDog(string breed)
        {
            var result = this.updateDogsService.Update(breed);
            if (breed == "husky")
            {
                return View("PerritoHusky");
            }
            return View("PerritoNoHusky");
        }
    }

    [TestClass]
    public class Example2
    {
        [TestMethod]
        public void TestUpdateDogFromDogsController()
        {
            var huskyServiceMock = new Mock<IDogsUpdate>();
            huskyServiceMock.Setup(huskyService => huskyService.Update("husky")).Returns(true);
            var huskyController = new HuskyController(huskyServiceMock.Object);
            Assert.AreEqual("PerritoHusky", huskyController.UpdateDog("husky").ViewName);
        }

    }
}
