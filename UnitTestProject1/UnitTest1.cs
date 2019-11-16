using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ZYDiningTable _diningTable = new ZYDiningTable();
        [TestMethod]
        public void TestMethod1()
        {
            _diningTable.SetX(0);
            Assert.AreEqual(_diningTable.DiningTableSprite.X, 0);
        }
    }
}
