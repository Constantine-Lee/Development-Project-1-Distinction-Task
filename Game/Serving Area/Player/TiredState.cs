using System;
using SwinGameSDK;

namespace MyGame
{
	public class TiredState: State
	{
		public TiredState ():base()
		{
			_speed = 0.5;
		}

		public override void Walk (Sprite sprt, KeyCode key, string _animation, double dx, double dy)
		{
			if (SwinGame.KeyDown (key)) {
				/*if ((Math.Abs (dx) > 0.2) || (Math.Abs (dy) > 0.2)) {
					_ticks = _ticks - 2;
				}*/
				SwinGame.SpriteStartAnimation (sprt, _animation);
				SwinGame.SpriteSetDX (sprt, (float)dx);
				SwinGame.SpriteSetDY (sprt, (float)dy);
			}
		}

	}
}
