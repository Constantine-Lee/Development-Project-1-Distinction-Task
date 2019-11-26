using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using SwinGameSDK;

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

        [TestMethod]
        public void TestPlayerImageSpriteExist()
        {
            SwinGame.LoadBitmapNamed("Player", "female.png");
            Assert.IsNotNull(SwinGame.BitmapNamed("Player"));
        }

        [TestMethod]
        public void TestCharacterInterface()
        {
            ZYCharacterInterface zYCharacterInterface = new ZYCharacterInterface();
            Assert.IsNotNull(zYCharacterInterface);
        }

        [TestMethod]
        public void TestCharacterInterfaceBackground()
        {
            SwinGame.LoadBitmapNamed("CIBackground", "characterSelectionBackground.jpg");
            Assert.IsNotNull(SwinGame.BitmapNamed("CIBackground"));
        }

        [TestMethod]
        public void TestStartDifficultyModeBackground()
        {
            SwinGame.LoadBitmapNamed("SDBackground", "hell.png");
            Assert.IsNotNull(SwinGame.BitmapNamed("SDBackground"));
        }

        [TestMethod]
        public void TestHardDifficultyModeDoomBackground()
        {
            SwinGame.LoadBitmapNamed("HDDBackground", "doom.jpg");
            Assert.IsNotNull(SwinGame.BitmapNamed("HDDBackground"));
        }
    }
}
