using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Engine.Core.UI
{
    //faire une zone area cliquable qui possede la position et la taille de la texture du bo uton
    class Button : UIObject
    {
        string name;
        Rectangle area;
        Texture2D inputTexture;
        Texture2D noInputTexture;

        public Button(string name, Texture2D noInputTexture, Texture2D inputTexture, Vector2 position) : base(position)
        {
            this.name = name;
            this.noInputTexture = noInputTexture;
            this.texture = this.noInputTexture;
            this.inputTexture = inputTexture;
            this.area = new Rectangle((int)position.X,(int)position.Y, texture.Width, texture.Height);
        }

        
        public bool mouseOnButton()
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);

            if (this.area.Contains(mousePosition))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void changeButtonTextureWhenInput(bool input)
        {
            if (input)
            {
                this.texture = this.inputTexture;
            }
            else
            {
                this.texture = this.noInputTexture;
            }
                
            
        }
      
    }
}
