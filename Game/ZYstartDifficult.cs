using System;
using SwinGameSDK;

namespace MyGame
{
    public class ZYStartDifficult : View
    {
        private string _image;
        private ZYButton _gotoMenuButton;
        private Sprite _menu;

        public ZYStartDifficult(ViewManager viewManager) : base(viewManager)
        {
            //background Image
            _image = "startmedium.png";
            SwinGame.LoadBitmapNamed(_image, _image);
            _menu = SwinGame.CreateSprite(SwinGame.BitmapNamed(_image));
            //

            //Go to menu
            _gotoMenuButton = new ZYButton("grey_button06.png");
            _gotoMenuButton.SetWidth(191);
            _gotoMenuButton.SetHeight(49);
            _gotoMenuButton.SetText("  Start Next Level", 20);
            //
        }

        public override void Draw()
        {
            SwinGame.DrawSprite(_menu);
            _gotoMenuButton.Draw();
        }

        public override void Update()
        {
        }

        public override void ProcessEvent()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                if (_gotoMenuButton.IsAt(SwinGame.MousePosition()))
                {

                    //_viewManager.View = _viewManager.NewDifficultMode();
                }
            }
        }

        //x = 0
        public void SetX(int x)
        {
            _gotoMenuButton.SetX(x + 165);
            _gotoMenuButton.SetTextPositionX(x + 175);
        }

        //y = 0
        public void SetY(int y)
        {
            _gotoMenuButton.SetY(y + 220);
            _gotoMenuButton.SetTextPositionY(y + 235);
        }
    }
}
