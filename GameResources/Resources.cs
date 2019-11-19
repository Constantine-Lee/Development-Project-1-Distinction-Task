using System;
namespace MyGame
{
	public class Resources
	{

		private string _backgroundImage;

		public string BG { 
			get { return _backgroundImage; }
			set { _backgroundImage = value; }
		}
		public Resources()
		{
			_backgroundImage = "pink_background.png";
		}
	}
}
