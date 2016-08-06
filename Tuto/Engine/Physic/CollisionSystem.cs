using System;

using System.Collections.Generic;
using Engine.Core.Game;
namespace Engine.Physic
{
	public class CollisionSystem
	{
		List<GameObject> gameObjects;

		public CollisionSystem()
		{
			gameObjects = new List<GameObject>();
		}

		public bool checkCollisionRect1vs1(GameObject rect1, GameObject rect2)
		{
			if (rect1.position.X < rect2.position.X + rect2.size.X &&
			    rect1.position.X + rect1.size.X > rect2.position.X &&
				rect1.position.Y < rect2.position.Y + rect2.size.Y &&
				rect1.size.Y + rect1.position.Y > rect2.position.Y)
			{
					return true;
			}
			else
				return false;
		}

		public bool checkCollisionRect(GameObject rect1)
		{
			bool collide = false;
			foreach (var rect2 in gameObjects)
			{
				if (rect1.position.X < rect2.position.X + rect2.size.X &&
				rect1.position.X + rect1.size.X > rect2.position.X &&
				rect1.position.Y < rect2.position.Y + rect2.size.Y &&
				rect1.size.Y + rect1.position.Y > rect2.position.Y)
				{
					collide = true;
					break;
				}
			}
			return collide;
		}


		public void addObjectToCollisionWorld(GameObject gameObject)
		{
			gameObjects.Add(gameObject);
		}
	}
}

