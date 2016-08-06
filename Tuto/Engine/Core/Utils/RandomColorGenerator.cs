using System;
using Microsoft.Xna.Framework;



namespace Engine.Core.Utils
{
	public class RandomColorGenerator
	{

		Random r = new Random(DateTime.Now.Millisecond);

		public RandomColorGenerator()
		{
		}

		public Color randomColor()
		{
			byte red = (byte)r.Next(0, 255);
			byte green = (byte)r.Next(0, 255);
			byte blue = (byte)r.Next(0, 255);

			return new Color(red, green, blue);
		}
	}
}

