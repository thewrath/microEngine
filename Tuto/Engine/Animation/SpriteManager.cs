using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Engine.Animation
{
    abstract class SpriteManager
    {
        protected Texture2D texture;
        public Vector2 position;
        public Color color = Color.White;
        public Vector2 origin;
        public float rotation = 0f;
        public float scale = 1f;
        public SpriteEffects spriteEffect;
        protected Rectangle[] rectangles;
        protected int frameIndex = 0;

        public SpriteManager(Texture2D texture, int frames)
        {
            this.texture = texture;
            int width = this.texture.Width / frames;
            this.rectangles = new Rectangle[frames];
            for(int i = 0; i<frames ;i++)
            {
                rectangles[i] = new Rectangle(i * width, 0, width, this.texture.Height);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, this.rectangles[this.frameIndex],this.color, this.rotation, this.origin, this.scale, this.spriteEffect, 0f);
        }
    }
}
