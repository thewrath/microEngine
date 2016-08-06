using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Engine.Effect.Particle
{
	public class Particle
	{
		private int lifeTime;
		private Vector2 position;
		private Texture2D texture;
		private Vector2 origin;
		private ParticleType particleType;
		private int fallVelocity;
		private Color color;
		private int orientation;
		public bool inLive;
		public int direction;



		public Particle(Texture2D texture, Vector2 position, int lifeTime, int randomDirection, ParticleType particleType, int fallVelocity, Color color, int orientation=1) 
		{
			this.position = position;
			this.lifeTime = lifeTime;
			this.texture = texture;
			this.origin = position;
			this.inLive = true;
			this.direction = randomDirection;
			this.particleType = particleType;
			this.fallVelocity = fallVelocity;
			this.color = color;
			this.orientation = orientation;

		}

		public void setTexture(Texture2D texture)
		{
			this.texture = texture;
		}

		public void update()
		{
			if (this.inLive == true)
			{
				if (this.position.X < this.origin.X - this.lifeTime || this.position.Y < this.origin.Y - this.lifeTime || this.position.X > this.origin.X + this.lifeTime || this.position.Y > this.origin.Y + this.lifeTime)
				{
					this.inLive = false;
				}
				//a changer en fonciton de l'enum direction 
				else
				{
					switch (this.particleType)
					{
						case ParticleType.EXPLODE:
							switch (this.direction)
							{
								//1 = haut, 2 = droite, 3 = bas, 4 = gauche
								case 1:
									this.position.X -= 1;
									this.position.Y -= 1;
									break;
								case 2:
									this.position.X += 1;

									break;
								case 3:
									this.position.X += 1;
									this.position.Y += 1;
									break;
								case 4:
									this.position.X -= 1;
									break;
								case 5:
									this.position.Y += 1;
									break;
								case 6:
									this.position.Y -= 1;
									break;
								case 7:
									this.position.X += 1;
									this.position.Y -= 1;
									break;
								case 8:
									this.position.X -= 1;
									this.position.Y += 1;
									break;
								case 9:
									this.position.X -= 2;
									this.position.Y += 1;
									break;
								case 10:
									this.position.X += 2;
									this.position.Y -= 1;
									break;
								case 11:
									this.position.X += 1;
									this.position.Y += 2;
									break;
								case 12:
									this.position.X += 1;
									this.position.Y -= 2;
									break;
								case 13:
									this.position.X -= 1;
									this.position.Y += 1;
									break;
								case 14:
									this.position.X -= 1;
									this.position.Y += 1;
									break;
								default:
									this.position.X += 1;
									this.position.Y += 1;
									break;
							}
							break;
						case ParticleType.FALL:
							this.position.Y += this.fallVelocity;
							break;
						case ParticleType.FOLLOW:
							switch (this.direction)
							{
								//1 = haut, 2 = droite, 3 = bas, 4 = gauche
								case 1:
									if (this.orientation == 1)
									{
										this.position.X -= 2;
									}
									else
									{
										this.position.X += 2;
									}
									this.position.Y -= 1;
									break;
								case 2:
									if (this.orientation == 1)
									{
										this.position.X -= 2;
									}
									else
									{
										this.position.X += 2;
									}
									break;
								case 3:
									this.position.Y -= 1;
									break;
								default:
									if (this.orientation == 1)
									{
										this.position.X -= 1;
									}
									else
									{
										this.position.X += 1;
									}
									break;
							}
							break;
						default:
							break;
					}
				}
			}
				

		}

		public void draw(SpriteBatch spriteBacth)
		{
			if (this.inLive == true)
				spriteBacth.Draw(this.texture, this.position, this.color);
		}

	}
}

