using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Animation
{
    class FrameAnimation : SpriteManager
    {
        public FrameAnimation(Texture2D texture, int frames) : base (texture, frames)
        {

        }

        public void setFrame(int frame)
        {
            if(frame < this.rectangles.Length)
            {
                this.frameIndex = frame;
            }
        } 
    }
}
