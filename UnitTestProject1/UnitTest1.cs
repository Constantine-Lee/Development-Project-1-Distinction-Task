using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        DiningTable _diningTable = new DiningTable();
        [TestMethod]
        public void TestMethod1()
        {
            _diningTable.SetX(0);
            Assert.AreEqual(_diningTable.DiningTableSprite.X, 10);
        }
    }
}
