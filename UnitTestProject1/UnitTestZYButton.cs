using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestZYButton
    {
        ZYButton zyButton = new ZYButton("");

        [TestMethod]
        public void TestSetX()
        {
            Assert.AreEqual(true, zyButton.SetX(0));
        }

        [TestMethod]
        public void TestSetY()
        {
            Assert.AreEqual(true, zyButton.SetY(0));
        }

        [TestMethod]
        public void TestWidth()
        {
            Assert.AreEqual(true, zyButton.SetWidth(0));
        }

        [TestMethod]
        public void TestHeight()
        {
            Assert.AreEqual(true, zyButton.SetHeight(0));
        }
    }
}
