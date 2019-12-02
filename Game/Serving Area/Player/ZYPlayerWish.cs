using System;
using SwinGameSDK;

namespace MyGame
{
    public class ZYPlayerWish
    {
        private Bitmap _fullBar;
        private Rectangle _partRect;
        private Sprite _statusBar;
        private Timer timer;
        public String Image;
        private Sprite _wishBackground;

        public ZYPlayerWish(string emptyBar)
        {
            SwinGame.LoadBitmapNamed(emptyBar, emptyBar);
            _statusBar = SwinGame.CreateSprite(SwinGame.BitmapNamed(emptyBar));
            timer = SwinGame.CreateTimer();
            //wish background
            SwinGame.LoadBitmapNamed("wish", "wish.png");
            _wishBackground = SwinGame.CreateSprite(SwinGame.BitmapNamed("wish"));
            //
        }

        public Sprite StatusBarSprite
        {
            get { return _statusBar; }
            set { _statusBar = value; }
        }

        public void SetX(float x)
        {
            SwinGame.SpriteSetX(_statusBar, x);
            SwinGame.SpriteSetX(_wishBackground, x-13);

        }

        public void SetY(float y)
        {
            SwinGame.SpriteSetY(_statusBar, y);
            SwinGame.SpriteSetY(_wishBackground, y-5);
        }

        public void SetFillingImage(string fillingImage)
        {
            SwinGame.StartTimer(timer);
            Image = fillingImage;
            _fullBar = SwinGame.LoadBitmapNamed(fillingImage, fillingImage);
        }

        public void Draw(int ticks, float x, float y)
        {
            SetX(x);
            SetY(y);
            SwinGame.DrawSprite(_wishBackground);
            SwinGame.DrawSprite(_statusBar);
            _partRect = SwinGame.RectangleFrom(0, 0, ticks, 128);
            SwinGame.DrawBitmapPart(_fullBar, _partRect, x, y);
        }

        public void ProcessEvent()
        {
            if((SwinGame.TimerTicks(timer) / 1000) > 5)
            {
                Image = "tired.png";
                _fullBar = SwinGame.LoadBitmapNamed("tired.png", "tired.png");
            }
        }
    }
}
