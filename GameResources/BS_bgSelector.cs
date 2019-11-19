using System;
namespace MyGame
{
	public static class BS_bgSelector
	{
		private static int img = 2;

		static BS_bgSelector()
		{
		}

		public static string bg_img() {
			return Resources.imgOut(img);
		}

		public static void nextImg() 
		{
			img = img + 1;
		}

		public static void previousImg()
		{
			img--;
			bg_img();
		}

		public static int Img 
		{
			get { return img; }
			set { img = value; }
		}
	}
}
