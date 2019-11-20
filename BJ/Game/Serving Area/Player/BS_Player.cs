using System;
using SwinGameSDK;

namespace MyGame
{
	public class BS_Player
	{
		private Sprite _player;
		private string _holdingFoodName;

		private BS_Movement _movement;
		private BS_HoldingFoodFrame _holdingFoodFrame;

		public BS_Player ()
		{
			_movement = new BS_Movement ();
			_holdingFoodName = "";
			_player = SwinGame.CreateSprite (SwinGame.BitmapNamed ("Player"), SwinGame.AnimationScriptNamed ("WalkingScript"));
		}

		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_player, x);
			_movement.SetX (x);
		}

		public void SetY (int y)
		{
			SwinGame.SpriteSetY (_player, y);
			_movement.SetY (y);
		}

		public Sprite PlayerSprite {
			get { return _player; }
			set { _player = value; }
		}

		public string HoldingFoodName {
			get {return _holdingFoodName;}
			set {_holdingFoodName = value;}
		}

		public BS_Movement Movement {
			get {return _movement;}
			set {_movement = value;}
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_player);
			SwinGame.UpdateSprite (_player);
			//_movement.Draw (_player.X, _player.Y);
		}

		public void Update ()
		{
			SwinGame.UpdateSprite (_player);
		}

		public void ProcessEvent ()
		{
			_movement.ProcessEvent (_player);
			NotifyHoldingFrame ();
		}

		public void SetFood (string foodName)
		{
			_holdingFoodName = foodName;
		}

		public void NotifyHoldingFrame ()
		{
			if (_holdingFoodName != "") {
				_holdingFoodFrame.SetFood (_holdingFoodName);
			} else if (_holdingFoodName == "") {
				_holdingFoodFrame.SetFood ("");
			}
		}

		public void RegisterHoldingFrame (BS_HoldingFoodFrame holdingFoodFrame)
		{
			_holdingFoodFrame = holdingFoodFrame;
		}
	}
}
