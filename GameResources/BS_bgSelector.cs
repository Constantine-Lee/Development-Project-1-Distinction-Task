using System;
namespace MyGame
{
	public static class BS_bgSelector
	{
		private static int img = 1;

		static BS_bgSelector()
		{
		}

		public static string bg_img() {
			return Resources.imgOut(img);
		}

		public static void nextImg() 
		{
			if (img < 8) {
				img++;
			} 
		}

		public static void previousImg()
		{
			if (img > 0) {
				img--;
			} 
		}

		public static int Img 
		{
			get { return img; }
			set { img = value; }
		}
	}
}
