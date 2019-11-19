using System;
using System.Collections.Generic;

namespace MyGame
{
	public static class Resources
	{

		private static List<string> _backgroundImage = new List<string>();

		static Resources()
		{
			_backgroundImage.Add("candybackground1.png");
			_backgroundImage.Add("candybackground2.png");
			_backgroundImage.Add("candybackground3.png");
			_backgroundImage.Add("candybackground4.png");
			_backgroundImage.Add("candybackground5.png");
			_backgroundImage.Add("candybackground6.png");
			_backgroundImage.Add("candybackground7.png");
		}

		public static string imgOut(int img) 
		{
			switch (img) {
				case (1):
					return _backgroundImage[1];
				case (2):
					return _backgroundImage[2];
				case (3):
					return _backgroundImage[3];
				case (4):
					return _backgroundImage[4];
				case (5):
					return _backgroundImage[5];
				case (6):
					return _backgroundImage[6];
				case (7):
					return _backgroundImage[7];
				default:
					return _backgroundImage[1];
			}
		}

		public static int numOfImgs() 
		{
			return _backgroundImage.Count;
		}
	}
}
