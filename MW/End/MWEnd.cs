using System;
using SwinGameSDK;

namespace MyGame
{
	public class MWEnd: View
	{
		private string _image;
		private MWButton _gotoMenuButton;
		private Sprite _menu;

		public MWEnd (ViewManager viewManager): base(viewManager)
		{
			//background Image
			_image = "game_over.jpg";
			SwinGame.LoadBitmapNamed (_image, _image);
			_menu = SwinGame.CreateSprite (SwinGame.BitmapNamed (_image));
			//

			//Go to menu
			_gotoMenuButton = new MWButton ("grey_button06.png");
			_gotoMenuButton.SetWidth (191);
			_gotoMenuButton.SetHeight (49);
			_gotoMenuButton.SetText ("-Back to Menu-",25);
			//
		}

		public override void Draw ()
		{
			SwinGame.DrawSprite (_menu);
			SwinGame.DrawText ("Game Over!", Color.Black, "Arial", 35, 280, 50);
			SwinGame.DrawText ("Score :" + MWSideBarUpdate.Score, Color.Black, "Arial", 35, 280, 90);
			_gotoMenuButton.Draw ();
		}

		public override void Update ()
		{
		}

		public override void ProcessEvent ()
		{
            SwinGame.StopMusic();
            if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
				if (_gotoMenuButton.IsAt (SwinGame.MousePosition ())) {
					_viewManager.View = _viewManager.Menu;
                    SwinGame.PlayMusic("Mountain.mp3");
                }
			}
			if (SwinGame.KeyTyped (KeyCode.vk_F12)) {
				SwinGame.ToggleFullScreen ();
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
