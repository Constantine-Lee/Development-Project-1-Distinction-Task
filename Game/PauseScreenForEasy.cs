using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    public class PauseScreenForEasy: View
    {
        private string _image;
        private ZYButton _gotoMenuButton;
        private Sprite _menu;

        public PauseScreenForEasy(ViewManager viewManager): base(viewManager)
        {
            //background Image
            _image = "pauseBackground.jpg";
            SwinGame.LoadBitmapNamed(_image, _image);
            _menu = SwinGame.CreateSprite(SwinGame.BitmapNamed(_image));
            //

            //Go to menu
            _gotoMenuButton = new ZYButton("grey_button06.png");
            _gotoMenuButton.SetWidth(191);
            _gotoMenuButton.SetHeight(49);
            _gotoMenuButton.SetText(" Resume ", 25);
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
                    _viewManager.View = _viewManager.EasyMode;
                }
            }
        }

        //x = 0
        public void SetX(int x)
        {
            _gotoMenuButton.SetX(x + 155);
            _gotoMenuButton.SetTextPositionX(x + 195);
        }

        //y = 0
        public void SetY(int y)
        {
            _gotoMenuButton.SetY(y + 270);
            _gotoMenuButton.SetTextPositionY(y + 280);
        }
    }
}
