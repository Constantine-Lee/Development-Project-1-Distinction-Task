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
            File.Exists("Resources/sounds/walking.ogg");
        }

        [TestMethod]
        public void LowHPSoundFilePresenceTest() {
            File.Exists("Resources/sounds/low_hp.wav");
        }
    }
}
