using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Animation;
using Engine.Physic;

namespace Engine.Core.Game
{
   
    public class GameObject
    {

        public Vector2 position;
		public Vector2 size;
		public Color color;
		public Texture2D texture;
		//variables pour les collision
		public bool canMove;
		private GravitySystem gravitySystem;
        private List<SpriteAnimation> animations;
        private int animationIndex = 0;

		public GameObject(Vector2 position, Vector2 size)
        {
            this.animations = new List<SpriteAnimation>();
            this.position = position;
			this.size = size;
			this.color = Color.White;
			this.canMove = true;
			this.gravitySystem = new GravitySystem();
            
        }

        public void setTexture(Texture2D objectTexture)
        {
            this.texture = objectTexture;
        }

        public void setPosition(Vector2 newPosition)
        {
            this.position = newPosition;
        }

		//il ne faut pas l'appeler si pas de texture 
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, this.color);

        }

        public void addAnimation(string animationName, Texture2D texture, int frames, bool isLooping, int framePerSecond)
        {
            SpriteAnimation animation;
            animation = new SpriteAnimation(texture, frames);
            animation.name = animationName;
            animation.isLooping = isLooping;
            animation.framesPerSecond = framePerSecond;
            animations.Add(animation);

        }

        public void setAnimation(string name)
        {
            for (int i = 0; i < this.animations.Count; i++)
            {
                if (this.animations[i].name == name)
                {
                    animationIndex = i;
                }
            }
        }

        public void drawAnimation(SpriteBatch spriteBatch)
        {
            if (this.animations.Count == 0)
            {
                this.draw(spriteBatch);
            }
            else
            {
                this.animations[animationIndex].draw(spriteBatch);
            }

        }

		public void update(GameTime gameTime, bool addPhysic)
        {
            if (this.animations.Count != 0)
            {
                this.animations[animationIndex].update(gameTime);
                this.animations[animationIndex].position = this.position;
            }
			if (addPhysic == true)
			{
				this.setPosition(gravitySystem.applyGravity(this.position));
			}

        }
    }
}
