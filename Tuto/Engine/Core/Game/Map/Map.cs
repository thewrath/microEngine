using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Engine.Physic;
namespace Engine.Core.Game.Map
{
	public class Map
	{
		private List<Texture2D> tiles;
		private int[,] tileMap;
		private int physicTileNumber;
		private int tileSize;
		private CollisionSystem mapCollisionSystem;

		public Map(List<Texture2D> tiles, int physicTileNumber, int[,] tileMap, int tileSize)
		{
			this.tiles = tiles;
			this.physicTileNumber = physicTileNumber;
			this.tileMap = tileMap;
			this.tileSize = tileSize;
			this.mapCollisionSystem = new CollisionSystem();

		}


		//analyse de la map pour trouver les tilePhysic
		public void updateMap()
		{
			for (int i = 0; i < this.tileMap.GetLength(0); i++)
			{
				for (int j = 0; j < this.tileMap.GetLength(1); j++)
				{

					if (this.tileMap[i, j] == this.physicTileNumber)
					{
						this.mapCollisionSystem.addObjectToCollisionWorld(new GameObject(new Vector2(j * tileSize, i * tileSize), new Vector2(tileSize, tileSize)));
					}


				}
			}
		}

		public bool checkCollisionWiththeMap(GameObject gameObject)
		{
			return this.mapCollisionSystem.checkCollisionRect(gameObject);
		}

		public void drawMap(SpriteBatch spriteBatch)
		{
			GameObject drawer = new GameObject(new Vector2(0, 0), new Vector2(this.tileSize, this.tileSize));
			for (int i = 0; i < this.tileMap.GetLength(0); i++)
			{
				for (int j = 0; j < this.tileMap.GetLength(1); j++)
				{
					
					if (this.tileMap[i, j] < this.tiles.Count)
					{
						drawer.setPosition(new Vector2(j * tileSize, i * tileSize));
						drawer.setTexture(tiles[tileMap[i, j]]);
						drawer.draw(spriteBatch);
					}


				}
			}

		}
			
	}
}

