using System;


using Microsoft.Xna.Framework;
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
		GameObject rect1;
		GameObject rect2;
		GameObject rect3;

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
			rect1 = new GameObject(new Vector2(50, 350), new Vector2(32,32));
			rect2 = new GameObject(new Vector2(0, 0), new Vector2(32, 32));
			rect3 = new GameObject(new Vector2(300, 150), new Vector2(32, 32));
			heroParticle = new ParticleManager();
			collisionSystem = new CollisionSystem();
			collisionSystem.addObjectToCollisionWorld(rect1);
			this.random = new Random();
			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			hero.addAnimation ("walk", Content.Load<Texture2D> ("spriteSheet"), 5, true, 10);
			hero.addAnimation ("pri", Content.Load<Texture2D> ("spriteSheet1"), 5, true, 10);
			hero.setAnimation ("walk");
			//charger une texture  utilise plusieur dans une variable 
			rect1.setTexture(Content.Load<Texture2D>("collisionTexture"));
			rect2.setTexture(Content.Load<Texture2D>("collisionTexture"));
			rect3.setTexture(Content.Load<Texture2D>("collisionTexture"));
			particleTexture1 = Content.Load<Texture2D>("particle");
			particleTexture2 = Content.Load<Texture2D>("particle2");
			particleTexture3 = Content.Load<Texture2D>("particle3");
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
				heroParticle.generateParticle(particleTexture1, new Vector2(mouseState.X, mouseState.Y), 100, 50, ParticleType.EXPLODE, 1, true);
			}
			else 
			{
				heroParticle.generateParticle(particleTexture3, new Vector2(mouseState.X, mouseState.Y), 200, 2, ParticleType.FALL, 3, true);
			}

			rect2.setPosition(new Vector2(mouseState.X, mouseState.Y));
			heroParticle.generateParticle(particleTexture2, new Vector2(hero.position.X+10, hero.position.Y+88), 20, 2, ParticleType.FOLLOW,1,false,1);
			if (collisionSystem.checkCollisionRect1vs1(hero, rect1) != true)
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
				rect1.color = Color.BurlyWood;
			}
			else
			{
				rect2.color = Color.White;
				rect1.color = Color.White;
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
			heroParticle.updateParticle();
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
			spriteBatch.Begin();
			hero.drawAnimation(spriteBatch);
			rect1.draw(spriteBatch);
			rect2.draw(spriteBatch);
			rect3.draw(spriteBatch);
			heroParticle.drawParticle(spriteBatch);
			base.Draw (gameTime);
			spriteBatch.End ();
		}
	}
}

