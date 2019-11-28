using System;
namespace MyGame
{
	public static class BS_bgSelector
	{
		private static int img = 0;

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

		public static int Img 
		{
			get { return img; }
			set { img = value; }
		}
	}
}
