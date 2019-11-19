using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class BS_Test1
    {
        Settings _settings = new Settings();
        
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(_settings);
        }
    }
}
