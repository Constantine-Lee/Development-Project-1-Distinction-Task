using System;
using System.Collections.Generic;
using SwinGameSDK;

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
            Audio.LoadSoundEffectNamed("walking","walking.ogg");
            Audio.LoadSoundEffectNamed("candyPickUp","ring_inventory.wav");
            Audio.LoadSoundEffectNamed("sell","sell_buy_item.wav");
            Audio.LoadSoundEffectNamed("trash","cloth-inventory.wav");
		}

		public static string imgOut(int img) 
		{
            return _backgroundImage[img];
		}

		public static int numOfImgs() 
		{
			return _backgroundImage.Count;
		}
	}
}
