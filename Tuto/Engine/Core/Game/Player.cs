using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Animation;

namespace Engine.Core.Game
{
    class Player : GameObject
    {
        
		public Player( Vector2 position, Vector2 size) : base(position, size)
        {
            
        }

        public void move(KeyboardState state, float vitesse)
        {

            if (state.IsKeyDown(Keys.Z))
            {
                this.position.Y -= vitesse;
                this.setAnimation("player");
            }
            if (state.IsKeyDown(Keys.Q))
            {
                this.position.X -= vitesse;
            }
            if (state.IsKeyDown(Keys.S))
            {
                this.position.Y += vitesse;
            }
            if (state.IsKeyDown(Keys.D))
            {
                this.position.X += vitesse;
            }
        }

       

    }
}
