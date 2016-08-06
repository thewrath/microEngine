using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Core.Game
{
    class World : GameObject
    {
        //constructeur de la classe dérivée avec le constructeur de la classe de base 
		public World(Vector2 position, Vector2 size) : base(position, size)
        {
            
        }
    }
}
