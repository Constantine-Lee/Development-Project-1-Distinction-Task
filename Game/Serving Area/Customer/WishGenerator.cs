using System;
using System.Collections.Generic;
namespace MyGame
{
	public static class WishGenerator
	{
		private static string[] _random = new string[3] { "small_BlueCandy.png", "small_GreenCandy.png", "small_RedCandy.png" };
		private static Random _randomNo = new Random ();

		public static Wish NewWish ()
		{
			return new Wish (_random [_randomNo.Next (0, 3)]);
		}
	}
}
