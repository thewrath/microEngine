using System;
using Microsoft.Xna.Framework;
namespace Engine.Physic
{
	public class GravitySystem
	{
		const int GRAVITY = 4; 
		public GravitySystem()
		{
		}

		public Vector2 applyGravity(Vector2 position)
		{
			return new Vector2(position.X,position.Y+GRAVITY);
		}
			
	}
}

