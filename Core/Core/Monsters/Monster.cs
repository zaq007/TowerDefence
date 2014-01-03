using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Map;
using Core.Extensions;

namespace Core.Monsters
{
    public class Monster
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        bool isMoving { get; set; }
        public bool isAlive { get; set; }
        public float Speed { get; set; }
        Point Current { get; set; }
        Point Next { get; set; }
        Vector2 nextPosition { get; set; }
        public int Health { get; set; }
        char[,] Mask { get; set; }
        public int Defence { get; set; }
        public int Cost { get; set; }
        protected Animation Animation { get; set; }

        public Monster(int X, int Y)
        {
            Current = new Point(X, Y);
            Position = new Vector2(35 * X, 35 * Y);
            isMoving = false;
            isAlive = true;
            Mask = (char[,])Ground.Mask.Clone();
        }

        public void Update(GameTime gameTime)
        {
            if (Health <= 0 && isAlive)
            {
                Player.Gold += Cost;
                isAlive = false;
            }
            if (!isAlive) return;
            if (Current == Ground.End)
            {
                isAlive = false;
                Player.Health -= Cost;
                return;
            }
            if (!isMoving)
            {
                if (Mask[Current.X, Current.Y + 1] == '2' || Mask[Current.X, Current.Y + 1] == '3')
                {
                    Mask[Current.X, Current.Y] = '0';
                    Next = new Point(Current.X, Current.Y + 1);
                    nextPosition = new Vector2(35 * Next.X, 35 * Next.Y);
                } else
                if (Mask[Current.X + 1, Current.Y] == '2' || Mask[Current.X + 1, Current.Y] == '3')
                {
                    Mask[Current.X, Current.Y] = '0';
                    Next = new Point(Current.X + 1, Current.Y);
                    nextPosition = new Vector2(35 * Next.X, 35 * Next.Y);
                } else
                if (Mask[Current.X, Current.Y - 1] == '2' || Mask[Current.X, Current.Y - 1] == '3')
                {
                    Mask[Current.X, Current.Y] = '0';
                    Next = new Point(Current.X, Current.Y - 1);
                    nextPosition = new Vector2(35 * Next.X, 35 * Next.Y);
                } else
                if (Mask[Current.X - 1, Current.Y] == '2' || Mask[Current.X - 1, Current.Y] == '3')
                {
                    Mask[Current.X, Current.Y] = '0';
                    Next = new Point(Current.X - 1, Current.Y);
                    nextPosition = new Vector2(35*Next.X, 35*Next.Y);
                }
                isMoving = true;
            }
            if (isMoving)
            {
                Vector2 temp = new Vector2(Position.X + Speed * (Next.X - Current.X), Position.Y + Speed * (Next.Y - Current.Y));
                if (!new Rectangle((int)nextPosition.X, (int)nextPosition.Y, 35, 35).Contains(new Point((int)(temp.X + 17.5 + 17.5 * (Next.X - Current.X)), (int)(temp.Y + 17.5 + 17.5 * (Next.Y - Current.Y)))))
                {
                    Position = nextPosition;
                    Current = Next;
                    isMoving = false;
                }
                else
                {
                    Position = temp;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isAlive) return;
            if (Next.X - Current.X == 1)
                spriteBatch.Draw(Texture, Position, Animation.GetFrame(), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            if (Next.X - Current.X == -1)
                spriteBatch.Draw(Texture, Position, Animation.GetFrame(), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.FlipHorizontally, 0f);
            if (Next.Y - Current.Y == -1)
                spriteBatch.Draw(Texture, Position, Animation.GetFrame(), Color.White, -(float)Math.PI / 2, new Vector2(35, 0), 1f, SpriteEffects.None, 0f);
            if (Next.Y - Current.Y == 1)
                spriteBatch.Draw(Texture, Position, Animation.GetFrame(), Color.White, -(float)Math.PI / 2, new Vector2(35, 0), 1f, SpriteEffects.FlipHorizontally, 0f);
        }

        public void Hit(int Value)
        {
            int k = Value - Defence;
            if (k <= 0) Health--; else Health -= k;
        }
    }
}
