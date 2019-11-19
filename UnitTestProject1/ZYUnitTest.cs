using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class ZYUnitTest
    {
        ZYSampleFood zYSampleFood = new ZYSampleFood("samplefood.png");
        ViewManager viewManager = new ViewManager();
        [TestMethod]
        public void TestSampleFood()
        {
            Assert.AreEqual("samplefood.png", zYSampleFood.Image);
            Assert.AreNotEqual("false", zYSampleFood.Image);
        }

        [TestMethod]
        public void TestGameLife()
        {
            ZYGameLife zYGameLife = new ZYGameLife();
            Assert.AreEqual(100, zYGameLife.Width);
        }

        [TestMethod]
        public void TestPauseScreen()
        {
            Boolean result;
            try
            {
                PauseScreen pauseInterface = new PauseScreen(viewManager);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestSampleFood2()
        {
            Assert.AreEqual("notequal", zYSampleFood.Image);            
        }

    }
}
