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

			//previous img button
			_previousImgButton = new BS_Button("flatDark23_2.png");
			_previousImgButton.SetWidth(30);
			_previousImgButton.SetHeight(30);

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
			_gotoMenuButton.Draw();
			_nextImgButton.Draw();
			_previousImgButton.Draw();
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
					BS_bgSelector.nextImg ();
					if (BS_bgSelector.Img < 7) {
						SwinGame.ReleaseBitmap (_image);
						_image = BS_bgSelector.bg_img ();
						SwinGame.LoadBitmapNamed (_image, _image);
						_menu = SwinGame.CreateSprite (SwinGame.LoadBitmap (_image));
					}
				}
				if (_previousImgButton.IsAt(SwinGame.MousePosition()))
				{
					BS_bgSelector.previousImg ();
					if (BS_bgSelector.Img > 1) {
						SwinGame.ReleaseBitmap (_image);
						_image = BS_bgSelector.bg_img ();
						SwinGame.LoadBitmapNamed (_image, _image);
						_menu = SwinGame.CreateSprite (SwinGame.LoadBitmap (_image));
					}
				}
            }
        }

        //x = 0
        public void SetX(int x)
        {
            _gotoMenuButton.SetX(x + 305);
            _gotoMenuButton.SetTextPositionX(x + 312);

			_nextImgButton.SetX(x + 75);
			_nextImgButton.SetTextPositionX(x + 82);

			_previousImgButton.SetX(x + 25);
			_previousImgButton.SetTextPositionX(x + 32);
        }

        //y = 0
        public void SetY(int y)
        {
            _gotoMenuButton.SetY(y + 340);
            _gotoMenuButton.SetTextPositionY(y + 350);

			_nextImgButton.SetY(y + 50);
			_nextImgButton.SetTextPositionY(y + 60);

			_previousImgButton.SetY(y + 50);
			_previousImgButton.SetTextPositionY(y + 60);
        }
    }
}