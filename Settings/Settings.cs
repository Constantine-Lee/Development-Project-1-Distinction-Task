using System;
using SwinGameSDK;

namespace MyGame
{
    public class Settings : View
    {
        private string _image;
        private BS_Button _gotoMenuButton;
		private BS_Button _nextImgButton;
		private BS_Button _previousImgButton;
		private Sprite _menu;

        private MWButton _BGM1Button;
        private MWButton _BGM2Button;
        private MWButton _stopBGMButton;

        public Settings(ViewManager viewManager)
            : base(viewManager)
        {
            //background Image
			_image = BS_bgSelector.bg_img();
            SwinGame.LoadBitmapNamed(_image, _image);
            _menu = SwinGame.CreateSprite(SwinGame.BitmapNamed(_image));
			//

			//next img button
			_nextImgButton = new BS_Button("flatDark24_2.png");
			_nextImgButton.SetWidth(30);
			_nextImgButton.SetHeight(30);
            _nextImgButton.SetText(" Background Changer ",15);

			//previous img button
			_previousImgButton = new BS_Button("flatDark23_2.png");
			_previousImgButton.SetWidth(30);
			_previousImgButton.SetHeight(30);

            //BGM1 button
            _BGM1Button = new MWButton("red_button2.png");
            _BGM1Button.SetWidth(80);
            _BGM1Button.SetHeight(40);
            _BGM1Button.SetText("Adventure", 15);

            //BGM2 button
            _BGM2Button = new MWButton("red_button2.png");
            _BGM2Button.SetWidth(80);
            _BGM2Button.SetHeight(40);
            _BGM2Button.SetText(" Fantasy ", 15);

            //stop BGM button
            _stopBGMButton = new MWButton("red_button2.png");
            _stopBGMButton.SetWidth(80);
            _stopBGMButton.SetHeight(40);
            _stopBGMButton.SetText("No Music", 15);

            //Go to menu
            _gotoMenuButton = new BS_Button("grey_button06.png");
            _gotoMenuButton.SetWidth(191);
            _gotoMenuButton.SetHeight(49);
            _gotoMenuButton.SetText(" Back to Menu ", 25);
            //
        }

        public Settings() { }

        public override void Draw()
        {
           SwinGame.DrawSprite(_menu);
           SwinGame.DrawRectangle(SwinGame.RGBAColor(133,16,216,100),true, 20, 50, 150, 300);
			_gotoMenuButton.Draw();
			_nextImgButton.Draw();
			_previousImgButton.Draw();
            _BGM1Button.Draw();
            _BGM2Button.Draw();
            _stopBGMButton.Draw();
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
                    _viewManager.View = _viewManager.Menu;
                }
				if (_nextImgButton.IsAt(SwinGame.MousePosition())) 
				{
					
					if (BS_bgSelector.Img < 6) {
                        BS_bgSelector.nextImg ();
						SwinGame.ReleaseBitmap (_image);
						_image = BS_bgSelector.bg_img ();
						SwinGame.LoadBitmapNamed (_image, _image);
						_menu = SwinGame.CreateSprite (SwinGame.LoadBitmap (_image));
					}
				}
				if (_previousImgButton.IsAt(SwinGame.MousePosition()))
				{
					
					if (BS_bgSelector.Img > 0) {
                        BS_bgSelector.previousImg ();
						SwinGame.ReleaseBitmap (_image);
						_image = BS_bgSelector.bg_img ();
						SwinGame.LoadBitmapNamed (_image, _image);
						_menu = SwinGame.CreateSprite (SwinGame.LoadBitmap (_image));
					}
				}
                if (_BGM1Button.IsAt(SwinGame.MousePosition()))
                {
                    SwinGame.StopMusic();
                    SwinGame.LoadMusic("Mountain.mp3");
                    SwinGame.PlayMusic("Mountain.mp3");
                }
                if (_BGM2Button.IsAt(SwinGame.MousePosition()))
                {
                    SwinGame.StopMusic();
                    SwinGame.LoadMusic("Netherplace.mp3");
                    SwinGame.PlayMusic("Netherplace.mp3");
                }
                if (_stopBGMButton.IsAt(SwinGame.MousePosition()))
                {
                    SwinGame.StopMusic();
                }
            }
        }

        //x = 0
        public void SetX(int x)
        {
            _gotoMenuButton.SetX(x + 305);
            _gotoMenuButton.SetTextPositionX(x + 312);

			_nextImgButton.SetX(x + 75);
			_nextImgButton.SetTextPositionX(x + 20);

			_previousImgButton.SetX(x + 25);
			_previousImgButton.SetTextPositionX(x + 32);

            _BGM1Button.SetX(x + 25);
            _BGM1Button.SetTextPositionX(x + 30);

            _BGM2Button.SetX(x + 25);
            _BGM2Button.SetTextPositionX(x + 35);

            _stopBGMButton.SetX(x + 25);
            _stopBGMButton.SetTextPositionX(x + 35);
        }

        //y = 0
        public void SetY(int y)
        {
            _gotoMenuButton.SetY(y + 340);
            _gotoMenuButton.SetTextPositionY(y + 350);

			_nextImgButton.SetY(y + 75);
			_nextImgButton.SetTextPositionY(y + 110);

			_previousImgButton.SetY(y + 75);
			_previousImgButton.SetTextPositionY(y + 85);

            _BGM1Button.SetY(y + 200);
            _BGM1Button.SetTextPositionY(y + 212);

            _BGM2Button.SetY(y + 250);
            _BGM2Button.SetTextPositionY(y + 262);

            _stopBGMButton.SetY(y + 300);
            _stopBGMButton.SetTextPositionY(y + 312);
        }
    }
}