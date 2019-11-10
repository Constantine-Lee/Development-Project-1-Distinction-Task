using System;
using SwinGameSDK;

namespace MyGame
{
	public class Movement
	{
		private double _speed;
		private StatusBar _statusBar;
		private Timer _gameTime;
		private int _ticks;

		public Movement ()
		{
			_speed = 1;
			_ticks = 60;

			_gameTime = SwinGame.CreateTimer ();
			SwinGame.StartTimer (_gameTime);

			_statusBar = new StatusBar ("hb_01c.png");
			_statusBar.SetFillingImage ("hb_01b.png");
		}

		public void SetX (int x)
		{
			_statusBar.SetX (x + 22);
		}

		public void SetY (int y)
		{
			_statusBar.SetY (y + 25);
		}

		public int Ticks {
			get { return _ticks; }
			set { _ticks = value; }
		}

		public void Draw (float x, float y)
		{
			_statusBar.Draw (_ticks, x, y);
		}

		public void ProcessEvent (Sprite _player)
		{
			if (SwinGame.TimerTicks (_gameTime) > 150) {
				if (_ticks < 50) {
					_ticks = _ticks + 1;
				}
				SwinGame.ResetTimer (_gameTime);
			}

			if (_ticks < 25) {
				_speed = 0.8;
			} else _speed = 1.3;

			Boundary (_player);

			//Code reference to Swingame.com
			if (SwinGame.SpriteAnimationHasEnded (_player)) {

				SwinGame.SpriteSetDX (_player, 0);
				SwinGame.SpriteSetDY (_player, 0);

				Walk (_player, KeyCode.vk_w, "WalkBack", 0, -_speed);
				Walk (_player, KeyCode.vk_s, "WalkFront", 0, +_speed);
				Walk (_player, KeyCode.vk_a, "WalkLeft", -_speed, 0);
				Walk (_player, KeyCode.vk_d, "WalkRight", +_speed, 0);

				SwinGame.UpdateSprite (_player);
			}
		}

		// move the player according to the argument sent in. Code reference to Swingame.com
		public void Walk (Sprite sprt, KeyCode key, string _animation, double dx, double dy)
		{
			if (SwinGame.KeyDown (key)) {
				if ((Math.Abs (dx) > 0.2) || (Math.Abs (dy) > 0.2)) {
					if (_ticks >= 15) {
						_ticks = _ticks - 2;
					}
				}
				SwinGame.SpriteStartAnimation (sprt, _animation);
				SwinGame.SpriteSetDX (sprt, (float)dx);
				SwinGame.SpriteSetDY (sprt, (float)dy);
			}
		}

		//restrict the movement of player
		public void Boundary (Sprite _player)
		{
			if (_player.X + _player.Width < 55) {
				Walk (_player, KeyCode.vk_a, "WalkLeft", 0, 0);
			}
			if (_player.Y + _player.Height < 135) {
				Walk (_player, KeyCode.vk_w, "WalkBack", 0, 0);
			}
			if ((_player.Y + _player.Height > 210) && (_player.X + _player.Width < 255)){
				Walk (_player, KeyCode.vk_s, "WalkFront", 0, 0);
			}
			if (_player.Y + _player.Height > 280) {
				Walk (_player, KeyCode.vk_s, "WalkFront", 0, 0);
			}
			if (_player.Y + _player.Height > 220){
				if (_player.X + _player.Width < 260) {
					Walk (_player, KeyCode.vk_a, "WalkLeft", 0, 0);
				}
			}
			if (_player.X + _player.Width > 360) {
				Walk (_player, KeyCode.vk_d, "WalkRight", 0, 0);
			}
		}
	}
}
