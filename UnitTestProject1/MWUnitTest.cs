using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using SwinGameSDK;

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
            Assert.AreEqual(_diningtable.DiningTableSprite.X,0);
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

        public void TestGameModeMousePosition()
        {
            MWButton _button = new MWButton("grey_button06.png");
            SwinGame.PointInRect(SwinGame.MousePosition(), 0, 0, 45, 50);
            _button.SetX(0);
            _button.SetY(0);
            _button.SetWidth(191);
            _button.SetWidth(49);
            Assert.AreEqual(true, _button.IsAt(SwinGame.MousePosition()));
        }

        public void TestGameModeBackground()
        {
            ViewManager _viewManager = new ViewManager();
            GameMode _gameMode = new GameMode(_viewManager);
            Assert.AreEqual("Tutorial-game-interface-001.jpg", _gameMode.BackgroundImage);
        }
    }
}
