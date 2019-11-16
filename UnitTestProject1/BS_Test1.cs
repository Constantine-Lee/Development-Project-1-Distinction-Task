using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class BS_Test1
    {
        BS_SideBar _sideBar = new BS_SideBar();
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(_sideBar.FullLifeCheck(), true);
        }
    }
}
