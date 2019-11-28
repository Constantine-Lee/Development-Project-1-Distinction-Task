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
        public void SellItemSoundEffectTest() {
            bool check = File.Exists("Resources/sounds/sell_buy_item.wav");
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void CandyPickUpSoundEffectTest() {
            bool check = File.Exists("Resources/sounds/ring_inventory.wav");
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void candyTrashTest() {
            bool check = File.Exists("Resources/sounds/cloth-inventory.wav");
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void gainPackTest() {
            bool check = File.Exists("Resources/images/GainPack.png");
            Assert.IsTrue(check);
        }
    }
}
