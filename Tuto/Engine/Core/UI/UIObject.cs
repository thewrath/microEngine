using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace Engine.Core.UI
{
   
    class UIObject
    {

        public Vector2 position;
        public Texture2D texture;
        private int animationIndex = 0;

		public UIObject(Vector2 position)
        {
           
            this.position = position;
            
        }

        public void setTexture(Texture2D objectTexture)
        {
            this.texture = objectTexture;
        }

        public void setPosition(Vector2 newPosition)
        {
            this.position = newPosition;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);

        }

        
    }
}
