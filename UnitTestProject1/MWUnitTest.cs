using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class MWUnitTest
    {
        MWDiningTable _diningtable = new MWDiningTable();

        [TestMethod]
        public void TestMethod1()
        {
            _diningtable.SetX(0);
            Assert.AreEqual(_diningtable.DiningTableSprite,10);
        }
    }
}
