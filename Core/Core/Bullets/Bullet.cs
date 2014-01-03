using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Core.Monsters;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;
using Core.Controllers;

namespace Core.Bullets
{
    public class Bullet
    {
        public Vector2 Position { get; set; }
        Texture2D Texture { get; set; }
        public Monster Aim { get; set; }
        public float Speed { get; set; }
        public bool isAlive { get; set; }
        public int Power { get; set; }
        BulletController bulletController { get; set; }

        public Bullet(int X, int Y, Monster aim, int power, BulletController bulletController)
        {
            Position = new Vector2(35 * X + 17.5f, 35 * Y + 17.5f);
            Aim = aim;
            isAlive = true;
            Speed = 1.5f;
            Texture = TextureLoader.Bullet;
            Power = power;
            this.bulletController = bulletController;
        }

        public void Update(GameTime gameTime)
        {
            if (!isAlive) return;
            if (!new Rectangle((int)Aim.Position.X, (int)Aim.Position.Y, 35, 35).Contains(new Point((int)this.Position.X, (int)this.Position.Y)))
            {
                Vector2 direction = Aim.Position - this.Position;
                direction += new Vector2(17.5f, 17.5f);
                direction.Normalize();
                direction = direction * Speed;
                Position += direction;
            }
            else
            {
                this.isAlive = false;
                Aim.Hit(Power);
                bulletController.Remove(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(isAlive) spriteBatch.Draw(Texture, Position, Color.White);
        }

    }
}
