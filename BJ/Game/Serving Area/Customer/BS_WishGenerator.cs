using System;
using System.Collections.Generic;
namespace MyGame
{
	public static class BS_WishGenerator
	{
		private static string[] _random = new string[3] { "small_BlueCandy.png", "small_GreenCandy.png", "small_RedCandy.png" };
		private static Random _randomNo = new Random ();

		public static BS_Wish NewWish ()
		{
			return new BS_Wish (_random [_randomNo.Next (0, 3)]);
		}
	}
}
