using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using SwinGameSDK;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class MWUnitTest
    {
        MWDiningTable _diningtable = new MWDiningTable();
        MWWoodenTable _woodentable = new MWWoodenTable();

        [TestMethod]
        public void TestDiningTableSetX()
        {
            _diningtable.SetX(0);
            Assert.AreEqual(_diningtable.DiningTableSprite.X, 0);
        }

        [TestMethod]
        public void TestWoodenTableSetX()
        {
            _woodentable.SetX(0);
            Assert.AreEqual(_woodentable.DiningTableSprite.X, 0);
        }

        [TestMethod]
        public void TestSideBarUpdateHoldingFoodFrame()
        {
            MWHoldingFoodFrame _holdingfoodframe = new MWHoldingFoodFrame();
            Assert.AreEqual(_holdingfoodframe.HoldingFood.X, 384);
            Assert.AreEqual(_holdingfoodframe.HoldingFood.Y, 178);
        }

        [TestMethod]
        public void TestSideBarUpdateScore()
        {
            MWSideBarUpdate __sidebarUpdate = new MWSideBarUpdate();
            __sidebarUpdate.AddScore();
            Assert.AreEqual(100, MWSideBarUpdate.Score);
        }

        [TestMethod]
        public void TestCustomerSelection()
        {
            MWCustomerSelection mWCustomerSelection = new MWCustomerSelection();
            Assert.IsNotNull(mWCustomerSelection);
        }

        [TestMethod]
        public void CustomerImageExistTest()
        {
            bool check1 = File.Exists("Resources/images/daisy.png");
            bool check2 = File.Exists("Resources/images/luigi.png");
            bool check3 = File.Exists("Resources/images/mario.png");
            bool check4 = File.Exists("Resources/images/mushroom.png");
            bool check5 = File.Exists("Resources/images/pinkmushroom.png");
            bool check6 = File.Exists("Resources/images/yoshi.png");

            Assert.IsTrue(check1);
            Assert.IsTrue(check2);
            Assert.IsTrue(check3);
            Assert.IsTrue(check4);
            Assert.IsTrue(check5);
            Assert.IsTrue(check6);
        }

        [TestMethod]
        public void TestNewMarioCharacterGame()
        {
            bool check1 = File.Exists("MW/Game/MWmarioGame.cs");
            Assert.IsTrue(check1);
        }

        [TestMethod]
        public void TestMarioDiningTable()
        {
            MWMarioDiningTable mWMarioDiningTable = new MWMarioDiningTable();
            MWMarioWoodenTable mWMarioWoodenTable = new MWMarioWoodenTable();
            
            Assert.IsNotNull(mWMarioDiningTable);
            Assert.IsNotNull(mWMarioWoodenTable);
        }

        [TestMethod]
        public void TestSideBarMarioUpdate()
        {
            MWSideBarMarioUpdate mWSideBarMarioUpdate = new MWSideBarMarioUpdate();
           
            Assert.IsNotNull(mWSideBarMarioUpdate);
        }
    }
}
