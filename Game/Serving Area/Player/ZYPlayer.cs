﻿using System;
using SwinGameSDK;

namespace MyGame
{
	public class ZYPlayer
	{
		private Sprite _player;
		private string _holdingFoodName;

		private ZYMovement _movement;
		private ZYHoldingFoodFrame _holdingFoodFrame;
/*        private static String _image;

        public static String Image
        {
            get { return _image; }
            set { _image = value; }
        }
*/
        public ZYPlayer ()
		{
            
            _movement = new ZYMovement ();
			_holdingFoodName = "";
            SwinGame.LoadBitmapNamed("Player", "ASH");
            _player = SwinGame.CreateSprite(SwinGame.BitmapNamed("Player"), SwinGame.AnimationScriptNamed("WalkingScript"));
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

		public ZYMovement Movement {
			get {return _movement;}
			set {_movement = value;}
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_player);
			SwinGame.UpdateSprite (_player);
			_movement.Draw (_player.X, _player.Y);
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

		public void RegisterHoldingFrame (ZYHoldingFoodFrame holdingFoodFrame)
		{
			_holdingFoodFrame = holdingFoodFrame;
		}
	}
}
