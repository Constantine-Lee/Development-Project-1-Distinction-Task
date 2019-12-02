using System;
using SwinGameSDK;

namespace MyGame
{
	public class ZYEnd: View
	{
		private string _image;
		private ZYButton _gotoMenuButton;
		private Sprite _menu;
        private Sprite winEnding;
        public static Boolean  winOrLose;

		public ZYEnd (ViewManager viewManager): base(viewManager)
		{
            winOrLose = false;
			//background Image
            SwinGame.LoadBitmapNamed("loseBackground", "loseBackground.jpg");
            _menu = SwinGame.CreateSprite(SwinGame.BitmapNamed("loseBackground"));
            //

            SwinGame.LoadBitmapNamed("winEnding.jpg", "winEnding.jpg");
            winEnding = SwinGame.CreateSprite(SwinGame.BitmapNamed("winEnding.jpg"));
			//Go to menu
			_gotoMenuButton = new ZYButton ("grey_button06.png");
			_gotoMenuButton.SetWidth (191);
			_gotoMenuButton.SetHeight (49);
			_gotoMenuButton.SetText ("-Back to Menu-",25);
			//
		}

		public override void Draw ()
		{
            if (winOrLose)
            {
                
                SwinGame.DrawSprite(winEnding);
            }
            else
            {
                SwinGame.DrawSprite(_menu);
            }

			_gotoMenuButton.Draw ();
		}

		public override void Update ()
		{
		}

		public override void ProcessEvent ()
		{
			if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
				if (_gotoMenuButton.IsAt (SwinGame.MousePosition ())) {
					_viewManager.View = _viewManager.Menu;
				}
			}
		}

		//x = 0
		public void SetX (int x)
		{
			_gotoMenuButton.SetX (x + 290);
			_gotoMenuButton.SetTextPositionX (x + 297);
		}

		//y = 0
		public void SetY (int y)
		{
			_gotoMenuButton.SetY (y + 300);
			_gotoMenuButton.SetTextPositionY (y + 310);
		}
	}
}
