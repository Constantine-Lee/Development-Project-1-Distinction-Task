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
        private ZYButton _resumeButton;
        private Sprite _menu;

        public PauseScreen()
        {
            //background Image
            _image = "pausescreen.png";
            SwinGame.LoadBitmapNamed(_image, _image);
            _menu = SwinGame.CreateSprite(SwinGame.BitmapNamed(_image));
            //

            //Go to menu
            _resumeButton = new ZYButton("grey_button06.png");
            _resumeButton.SetWidth(191);
            _resumeButton.SetHeight(49);
            _resumeButton.SetText(" Back to Game ", 25);
            //
        }
    }
}
