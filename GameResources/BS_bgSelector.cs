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
			if (img < 7) {
				img++;
			} else if (img == 8) {
				img = 7;
			}
		}

		public static void previousImg()
		{
			if (img > 1) {
				img--;
			} else if (img == 0) {
				img = 1;
			}
		}

		public static int Img 
		{
			get { return img; }
			set { img = value; }
		}
	}
}
