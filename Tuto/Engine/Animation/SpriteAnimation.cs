using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Animation
{
    class SpriteAnimation : SpriteManager
    {
        private float timeElapsed;
        public bool isLooping = false;
        public string name;
        private float timeToUpdate = 0.05f;
        public int framesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }

        public SpriteAnimation(Texture2D texture, int frames) : base (texture, frames)
        {

        }

        public void update(GameTime gameTime)
        {
            this.timeElapsed += (float)
                gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > this.timeToUpdate)
            {
                this.timeElapsed -= this.timeToUpdate;

                if (this.frameIndex < this.rectangles.Length - 1)
                    this.frameIndex++;
                else if (this.isLooping)
                    this.frameIndex = 0;
            }
        }
    }
}
