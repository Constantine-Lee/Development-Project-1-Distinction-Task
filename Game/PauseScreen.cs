using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame
{
    public class PauseScreen
    {
        private string _image;
        private ZYButton _gotoMenuButton;
        private Sprite _menu;

        public PauseScreen()
        {
            //background Image
            _image = "instruction.png";
            SwinGame.LoadBitmapNamed(_image, _image);
            _menu = SwinGame.CreateSprite(SwinGame.BitmapNamed(_image));
            //

            //Go to menu
            _gotoMenuButton = new ZYButton("grey_button06.png");
            _gotoMenuButton.SetWidth(191);
            _gotoMenuButton.SetHeight(49);
            _gotoMenuButton.SetText(" Back to Menu ", 25);
            //
        }
    }
}
