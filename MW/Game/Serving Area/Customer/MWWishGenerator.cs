using System;
using System.Collections.Generic;
namespace MyGame
{
	public static class MWWishGenerator
	{
		private static string[] _random = new string[3] { "small_BlueCandy.png", "small_GreenCandy.png", "small_RedCandy.png" };
		private static Random _randomNo = new Random ();

		public static MWWish NewWish ()
		{
			return new MWWish (_random [_randomNo.Next (0, 3)]);
		}
	}
}
