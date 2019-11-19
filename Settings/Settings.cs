using System;
using SwinGameSDK;

namespace MyGame
{
    public class Settings : View
    {
        private string _image;
        private BS_Button _gotoMenuButton;
		private BS_Button _nextImgButton;
		//private BS_Button _previousImgButton;
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
			_nextImgButton = new BS_Button("grey_button06.png");
			_nextImgButton.SetWidth(191);
			_nextImgButton.SetHeight(49);
			_nextImgButton.SetText(" Next", 25);

			//previous img button
			/*_previousImgButton = new BS_Button("blue_button07.png");
			_previousImgButton.SetWidth(20);
			_previousImgButton.SetHeight(29);
			_previousImgButton.SetText("Previous", 10);*/

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
			//_previousImgButton.Draw();
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
					BS_bgSelector.nextImg();
					SwinGame.UpdateSprite(_menu);

				}
				/*if (_previousImgButton.IsAt(SwinGame.MousePosition()))
				{
					BS_bgSelector.previousImg();
					Draw();
				}*/
            }
        }

        //x = 0
        public void SetX(int x)
        {
            _gotoMenuButton.SetX(x + 305);
            _gotoMenuButton.SetTextPositionX(x + 312);

			_nextImgButton.SetX(x + 75);
			_nextImgButton.SetTextPositionX(x + 82);

			/*_previousImgButton.SetX(x + 25);
			_previousImgButton.SetTextPositionX(x + 32);*/
        }

        //y = 0
        public void SetY(int y)
        {
            _gotoMenuButton.SetY(y + 340);
            _gotoMenuButton.SetTextPositionY(y + 350);

			_nextImgButton.SetY(y + 50);
			_nextImgButton.SetTextPositionY(y + 60);

			/*_previousImgButton.SetY(y + 50);
			_previousImgButton.SetTextPositionY(y + 60);*/
        }
    }
}