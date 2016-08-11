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
		public bool jumping;
		public Vector2 lastPosition;

		public Player( Vector2 position, Vector2 size) : base(position, size)
        {
			this.jumping = false;
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
            //if (state.IsKeyDown(Keys.S))
            //{
                //this.position.Y += vitesse;
            //}
            if (state.IsKeyDown(Keys.D))
            {
                this.position.X += vitesse;
            }
        }

		public bool jump(KeyboardState state)
		{
			if (state.IsKeyDown (Keys.Space)) {
				//jump 
				this.jumping = true;
				this.lastPosition = this.position;
				return true;
			} 
			else 
			{

				return false;
			}

		}

		public void updateJump()
		{
			if (this.jumping == true)
			{
				//le personnage saute 

				if (this.position.Y > this.lastPosition.Y - 120)
				{
					this.setPosition(new Vector2(this.position.X, this.position.Y -= 10));
				}
				else
				{
					this.jumping = false;
				}
			}
		}
    }
}
