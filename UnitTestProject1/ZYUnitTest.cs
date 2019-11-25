using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class ZYUnitTest
    {
        ZYSampleFood zYSampleFood = new ZYSampleFood("samplefood.png");
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
        public void TestPlayerImage()
        {
            ZYPlayer.Image = "male.png";
            Assert.AreEqual("male.png", ZYPlayer.Image);
        }
    }
}
