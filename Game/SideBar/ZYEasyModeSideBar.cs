using System;
using SwinGameSDK;

namespace MyGame
{
    public class EasyModeSideBar: ZYSideBarInterface
    {
        private Sprite _sideBar;
        private ZYGameLife _gameLife;
        private static int _life;

        private ZYHoldingFoodFrame _holdingFoodFrame;

        private Timer _gameTime;
        private static uint _ticks;

        private ViewManager _viewManager;

        public EasyModeSideBar(ViewManager viewManager)
        {
            _holdingFoodFrame = new ZYHoldingFoodFrame();

            _viewManager = viewManager;

            _gameTime = SwinGame.CreateTimer();
            SwinGame.StartTimer(_gameTime);

            _life = 6;
            _gameLife = new ZYGameLife();

            SwinGame.LoadBitmapNamed("side", "side_menu.png");
            _sideBar = SwinGame.CreateSprite(SwinGame.BitmapNamed("side"));
        }

        public void SetX(int x)
        {
            SwinGame.SpriteSetX(_sideBar, x);
        }

        public ZYHoldingFoodFrame HoldingFoodFrame
        {
            get { return _holdingFoodFrame; }
            set { _holdingFoodFrame = value; }
        }

        public static uint Ticks
        {
            get { return _ticks; }
            set { _ticks = value; }
        }

        public void Draw()
        {
            _ticks = SwinGame.TimerTicks(_gameTime) / 100;
            SwinGame.DrawSprite(_sideBar);
            _gameLife.Draw();
            
            _holdingFoodFrame.Draw();
        }

        public void DecreaseGameLife()
        {
            _life = _life - 1;
            _gameLife.Width = _gameLife.Width - 17;
        }

        public void ProcessEvent()
        {
            if (_life <= 0)
            {
                _viewManager.View = _viewManager.ZYEnd;
            }
        }

    }
}