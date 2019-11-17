using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMode : View
	{
		private MWButton _classicButton;
		private MWButton _survivalButton;
		private MWButton _casualButton;
		private MWButton _gotoMenuButton;

		private Sprite _gameMode;
		private string _backgroundImage;

        public string BackgroundImage { get => _backgroundImage; set => _backgroundImage = value; }

        public GameMode (ViewManager viewManager) : base (viewManager)
		{
			_backgroundImage = "Tutorial-game-interface-001.jpg";
			SwinGame.LoadBitmapNamed (_backgroundImage, _backgroundImage);
			_gameMode = SwinGame.CreateSprite (SwinGame.BitmapNamed (_backgroundImage));

			_classicButton = new MWButton ("grey_button06.png");
			_classicButton.SetWidth (191);
			_classicButton.SetHeight (49);
			_classicButton.SetText (" Classic ", 30);

			_survivalButton = new MWButton ("grey_button06.png");
			_survivalButton.SetWidth (191);
			_survivalButton.SetHeight (49);
			_survivalButton.SetText (" Survival ", 30);

			_casualButton = new MWButton ("grey_button06.png");
			_casualButton.SetWidth (191);
			_casualButton.SetHeight (49);
			_casualButton.SetText (" Casual ", 30);

			_gotoMenuButton = new MWButton ("grey_button06.png");
			_gotoMenuButton.SetWidth (191);
			_gotoMenuButton.SetHeight (49);
			_gotoMenuButton.SetText (" Back to Menu ", 25);
		}

		public override void Draw ()
		{
			SwinGame.DrawSprite (_gameMode);
			_classicButton.Draw2 ();
			_survivalButton.Draw2 ();
			_casualButton.Draw2 ();
			_gotoMenuButton.Draw ();
		}
	}
}

