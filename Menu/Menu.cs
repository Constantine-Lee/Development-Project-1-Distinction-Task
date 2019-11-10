using System;
using SwinGameSDK;

namespace MyGame
{
	public class Menu : View
	{
		private Button _startButton;
		private Button _instructionButton;
		private Sprite _menu;
		private string _backgroundImage;

		public Menu (ViewManager viewManager): base(viewManager)
		{
			_backgroundImage = "game_menu.jpg";
			SwinGame.LoadBitmapNamed (_backgroundImage, _backgroundImage);
			_menu = SwinGame.CreateSprite (SwinGame.BitmapNamed (_backgroundImage));

			_startButton = new Button ("grey_button06.png");
			_startButton.SetWidth (191);
			_startButton.SetHeight (49);
			_startButton.SetText ("     Start     ", 33);

			_instructionButton = new Button ("grey_button06.png");
			_instructionButton.SetWidth (191);
			_instructionButton.SetHeight (49);
			_instructionButton.SetText (" Instruction ", 33);
		}

		public override void Draw ()
		{
			SwinGame.DrawSprite (_menu);
			_startButton.Draw ();
			_instructionButton.Draw ();
		}

		public override void Update ()
		{
		}

		public override void ProcessEvent ()
		{
			if (SwinGame.MouseClicked (MouseButton.LeftButton)) {
				if (_startButton.IsAt (SwinGame.MousePosition ())) {
					_viewManager.View = _viewManager.NewGame ();
				}
				if (_instructionButton.IsAt (SwinGame.MousePosition ())) {
					_viewManager.View = _viewManager.Instruction;
				}
			}
		}


		//x = 0
		public void SetX (int x)
		{
			_startButton.SetX (x + 50);
			_startButton.SetTextPositionX (x + 58);

			_instructionButton.SetX (x + 50);
			_instructionButton.SetTextPositionX (x + 58);
		}

		//y = 0
		public void SetY (int y)
		{
			_startButton.SetY (y + 100);
			_startButton.SetTextPositionY (y + 105);

			_instructionButton.SetY (y + 170);
			_instructionButton.SetTextPositionY (y + 175);
		}

	}
}

