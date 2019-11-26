using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class BS_Test1
    {
       
        [TestMethod]
        public void WalkingSoundFilePresenceTest()
        {
           bool check = File.Exists("Resources/sounds/walking.ogg");
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void LowHPSoundFilePresenceTest() {
            bool check = File.Exists("Resources/sounds/low_hp.wav");
            Assert.IsTrue(check);
        }
    }
}
