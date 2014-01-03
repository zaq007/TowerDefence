using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Towers;
using Core.Monsters;
using Core.Bullets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Controllers
{
    public class BulletController
    {
        List<Tower> towers;
        List<Monster> monsters;
        List<Bullet> bullets;

        public BulletController(List<Tower> towers, List<Monster> monsters)
        {
            this.towers = towers;
            this.monsters = monsters;
            bullets = new List<Bullet>();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var tower in towers)
                foreach (var monster in monsters)
                    if ((tower.Position - monster.Position).Length() <= tower.Radius)
                        if (tower.Couldown <= TimeSpan.Zero && monster.isAlive)
                        {
                            bullets.Add(new Bullet((int)tower.Position.X / 35, (int)tower.Position.Y / 35, monster, tower.Power, this));
                            tower.Fire();
                        }
            for (int i = 0; i < bullets.Count; i++)
                bullets[i].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var bullet in bullets)
                bullet.Draw(spriteBatch);
        }

        public void Remove(Bullet bullet)
        {
            bullets.Remove(bullet);
        }

    }
}
