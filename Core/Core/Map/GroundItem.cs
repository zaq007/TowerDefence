using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Map
{
    public class GroundItem
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public GroundItem(int X, int Y)
        {
            Position = new Vector2(35*X, 35*Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

    }
}
