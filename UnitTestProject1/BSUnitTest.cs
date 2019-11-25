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
            File.Exists(SwinGameSDK.Resources.PathToResource("walking.ogg"));
        }

        [TestMethod]
        public void LowHPSoundFilePresenceTest() {
            File.Exists(SwinGameSDK.Resources.PathToResource("low_hp.wav"));
        }
    }
}
