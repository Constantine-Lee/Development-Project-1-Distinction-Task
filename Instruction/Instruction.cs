using System;
using SwinGameSDK;

namespace MyGame
{
	public class Instruction: View
	{
		private string _image;
		private Button _gotoMenuButton;
		private Sprite _menu;

		public Instruction(ViewManager viewManager): base(viewManager)
		{
			//background Image
			_image = "instruction.png";
			SwinGame.LoadBitmapNamed (_image, _image);
			_menu = SwinGame.CreateSprite (SwinGame.BitmapNamed (_image));
			//

			//Go to menu
			_gotoMenuButton = new Button ("grey_button06.png");
			_gotoMenuButton.SetWidth (191);
			_gotoMenuButton.SetHeight (49);
			_gotoMenuButton.SetText (" Back to Menu ", 25);
			//
		}

		public override void Draw ()
		{
			SwinGame.DrawSprite (_menu);
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
			_gotoMenuButton.SetX (x + 305);
			_gotoMenuButton.SetTextPositionX (x + 312);
		}

		//y = 0
		public void SetY (int y)
		{
			_gotoMenuButton.SetY (y + 340);
			_gotoMenuButton.SetTextPositionY (y + 350);
		}
	}
}
