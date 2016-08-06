using System;


using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Engine.Core.Game;
using Engine.Effect.Particle;
using Engine.Physic;

namespace Tuto
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		//keyboard 
		KeyboardState kbState;
		MouseState mouseState;
		//test 
		ParticleManager heroParticle;
		CollisionSystem collisionSystem;
		Texture2D particleTexture1;
		Texture2D particleTexture2;
		Texture2D particleTexture3;
		Player hero;
		List<GameObject> rects;
		GameObject rect2;
		GameObject rect3;

		List<GameObject> fireWorks;
		Texture2D fireWorkTexture;
		//random
		Random random;

		public Game1()
		{
			graphics = new GraphicsDeviceManager (this);
			//graphics.PreferredBackBufferWidth = 1920;
			//graphics.PreferredBackBufferHeight = 1080;
			//graphics.IsFullScreen = true;
			graphics.ApplyChanges();
			Content.RootDirectory = "Content";
		}
		protected override void Initialize ()
		{
			this.IsMouseVisible = true;
			hero = new Player( new Vector2(50,50), new Vector2(90, 96));
			heroParticle = new ParticleManager();
			collisionSystem = new CollisionSystem();
			rects = new List<GameObject>();
			for (int i = 0; i< 10; i++)
			{
				GameObject rect = new GameObject(new Vector2(32*i, 250), new Vector2(32, 32));
				collisionSystem.addObjectToCollisionWorld(rect);
				rects.Add(rect);
			}


			rect2 = new GameObject(new Vector2(0, 0), new Vector2(32, 32));
			rect3 = new GameObject(new Vector2(300, 150), new Vector2(32, 32));
			fireWorks = new List<GameObject>();	
			this.random = new Random();
			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			hero.addAnimation ("walk", Content.Load<Texture2D> ("spriteSheet"), 5, true, 10);
			hero.addAnimation ("pri", Content.Load<Texture2D> ("spriteSheet1"), 5, true, 10);
			hero.setAnimation ("walk");
			//charger une texture  utilise plusieur dans une variable 
			for (int i = 0; i < rects.Count; i++)
			{
				rects[i].setTexture(Content.Load<Texture2D>("collisionTexture")); ;
			}
			rect2.setTexture(Content.Load<Texture2D>("collisionTexture"));
			rect3.setTexture(Content.Load<Texture2D>("collisionTexture"));
			particleTexture1 = Content.Load<Texture2D>("particle");
			particleTexture2 = Content.Load<Texture2D>("particle2");
			particleTexture3 = Content.Load<Texture2D>("particle3");
			fireWorkTexture = Content.Load<Texture2D>("fire");
			spriteBatch = new SpriteBatch(GraphicsDevice);

		}
	
		protected override void Update (GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			KeyboardState prevKbState = kbState;
			kbState = Keyboard.GetState();

			MouseState prevMouseState = mouseState;
			mouseState = Mouse.GetState();

			if (kbState.IsKeyDown(Keys.Space))
			{
				hero.setAnimation("pri");

			}
			else 
			{
				hero.setAnimation("walk");
			}

			if (prevMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
			{
				//heroParticle.generateParticle(particleTexture1, new Vector2(mouseState.X, mouseState.Y), 100, 50, ParticleType.EXPLODE, 1, true);
				var fireWork = new GameObject(new Vector2(mouseState.X, mouseState.Y), new Vector2(16,16));
				fireWork.setTexture(fireWorkTexture);
				fireWorks.Add(fireWork);
			}
			else 
			{
				heroParticle.generateParticle(particleTexture2, new Vector2(mouseState.X, mouseState.Y), 10, 2, ParticleType.EXPLODE, 1, true);
				heroParticle.generateParticle(particleTexture3, new Vector2(mouseState.X, mouseState.Y), 200, 2, ParticleType.FALL, 3, true);
			}

			rect2.setPosition(new Vector2(mouseState.X, mouseState.Y));

			heroParticle.generateParticle(particleTexture2, new Vector2(hero.position.X+10, hero.position.Y+88), 20, 2, ParticleType.FOLLOW,1,false,1);
			if (collisionSystem.checkCollisionRect(hero) != true)
			{
				hero.update(gameTime, true);
			}
			else
			{
				hero.update(gameTime, false);
			}

			if (collisionSystem.checkCollisionRect(rect2))
			{
				rect2.color = Color.Chocolate;

			}
			else
			{
				rect2.color = Color.White;

			}
			if (collisionSystem.checkCollisionRect1vs1(rect2, rect3))
			{
				rect2.color = Color.Chocolate;
				rect3.color = Color.Pink;
			}
			else
			{
				//rect2.color = Color.White;
				rect3.color = Color.White;	
			}

			for (int i = 0; i < this.fireWorks.Count; i++)
			{
				fireWorks[i].position.Y -= 5;
				if (fireWorks[i].position.Y < fireWorks[i].origin.Y - 300 || collisionSystem.checkCollisionRect(fireWorks[i]))
				{
					heroParticle.generateParticle(particleTexture2, new Vector2(fireWorks[i].position.X, fireWorks[i].position.Y), 100, 50, ParticleType.EXPLODE, 1, true);
					fireWorks.Remove(this.fireWorks[i]);

				}
			}


			heroParticle.updateParticle();
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
			spriteBatch.Begin();
			hero.drawAnimation(spriteBatch);
			foreach (var i in rects)
			{
				i.draw(spriteBatch);
			}
			rect2.draw(spriteBatch);
			rect3.draw(spriteBatch);
			heroParticle.drawParticle(spriteBatch);
			foreach (var fireWork in fireWorks)
			{
				fireWork.draw(spriteBatch);
			}
			base.Draw (gameTime);
			spriteBatch.End ();
		}
	}
}

