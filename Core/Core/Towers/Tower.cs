using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;
using Core.Controllers;
using Microsoft.Xna.Framework.Input;
using Core.Handlers;

namespace Core.Towers
{
    public class Tower
    {
        public float Radius { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public int Power { get; set; }
        public int Level { get; set; }
        public int Cost { get; set; }
        public TimeSpan Speed { get; set; }
        public TimeSpan Couldown { get; set; }
        
        public Tower(int X, int Y)
        {
            Position = new Vector2(35 * X, 35 * Y);
            Level = 0;
            Couldown = TimeSpan.Zero;
        }

        public void Update(GameTime gameTime)
        {
            if (Couldown > TimeSpan.Zero)
                Couldown -= gameTime.ElapsedGameTime;            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Fire()
        {
            Couldown = Speed;
        }

        public void OnClick(object sender, MouseAgrs e)
        {
            if (e.ClickedKey == Key.Left &&
                new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height).Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                InterfaceController.IC.Pick(this);
        }

        public void Upgrade()
        {
            if (Level < 3 && Player.Gold >= (10 + Level * 5))
            {
                Power++;
                Level++;
                Radius += 35;
                Player.Gold -= 10 + Level * 5;
            }
        }
    }
}
