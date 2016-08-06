using System;

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Core.Utils;

namespace Engine.Effect.Particle
{
	public class ParticleManager
	{
		private int particleNumber;
		private List<Particle> particles;
		private Random random;

		public ParticleManager()
		{
			this.particles = new List<Particle>();
			this.random = new Random();
		}

		public void generateParticle(Texture2D texture,Vector2 position, int lifeTime, int particleNumber, ParticleType particleType, int fallDuration=1, bool randomColor=false, int orientation=1)
		{
			//borns a et b 
			int a, b;
			Color color;
			this.particleNumber = particleNumber;
			if (particleType == ParticleType.FALL)
			{
				a = -10;
				b = 11;
			}
			else 
			{
				a = -3;
				b = 4;
			}

			for (int i = 0; i < this.particleNumber; i++)
			{
				if (randomColor == true)
				{
					color = new RandomColorGenerator().randomColor();
				}
				else
				{
					color = Color.White;
				}
				Particle particle = new Particle(texture, new Vector2(position.X + random.Next(a, b), position.Y + random.Next(a, b)), lifeTime, random.Next(1,15), particleType, fallDuration,color, orientation);
				particles.Add(particle);
			}
		}

		public void updateParticle()
		{
			for (int i = 0; i < this.particles.Count; i++)
			{
				this.particles[i].update();
				if (this.particles[i].inLive == false)
				{
					this.particles.Remove(this.particles[i]);

				}
			}


		}

		public void drawParticle(SpriteBatch spriteBacth)
		{
			foreach (var i in this.particles)
			{
				i.draw(spriteBacth);
			}
		}
	}
}

