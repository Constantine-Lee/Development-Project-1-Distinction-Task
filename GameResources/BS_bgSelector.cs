using System;
namespace MyGame
{
	public static class BS_bgSelector
	{
		private static int img = 6;

		static BS_bgSelector()
		{
		}

		public static string bg_img() {
			return Resources.imgOut(img);
		}

		public static void nextImg() 
		{
			img++;
		}

		public static void previousImg()
		{
			img--;
		}
	}
}
