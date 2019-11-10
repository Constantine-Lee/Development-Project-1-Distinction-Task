using System;
using SwinGameSDK;

namespace MyGame
{
	public class EnergyBall
	{
		private Sprite _energyBall;
		private string _energyImage;
		private static Random _random = new Random ();

		public EnergyBall ()
		{
			_energyImage = "ball.png";
			SwinGame.LoadBitmapNamed (_energyImage, _energyImage);
			_energyBall = SwinGame.CreateSprite (SwinGame.BitmapNamed (_energyImage));
		}

		public void SetX (int x)
		{
			SwinGame.SpriteSetX (_energyBall, x);
		}

		public void SetY (int y)
		{
			SwinGame.SpriteSetY (_energyBall, y);
		}

		public Sprite EnergyPotionSprite {
			get {return _energyBall;}
			set {_energyBall = value;}
		}

		public string EnergyImage {
			get {return _energyImage;}
			set {_energyImage = value;}
		}

		public void Draw ()
		{
			SwinGame.DrawSprite (_energyBall);
		}

		public void ResetEnergyBall ()
		{
			_energyImage = "";
			SwinGame.LoadBitmapNamed (_energyImage, _energyImage);
			_energyBall = SwinGame.CreateSprite (SwinGame.BitmapNamed (_energyImage));
		}

		public void NewEnergyBall ()
		{
			_energyImage = "ball.png";
			SwinGame.LoadBitmapNamed (_energyImage, _energyImage);
			_energyBall = SwinGame.CreateSprite (SwinGame.BitmapNamed (_energyImage));
		}

		public void ResetEnergyBallPosition ()
		{
			SetX (_random.Next (10, 330));
			SetY (_random.Next (115, 190));
		}
	}
}
