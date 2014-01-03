using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Monsters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Controllers
{
    public class MonsterController
    {
        List<Monster> monsters;

        public MonsterController()
        {
            this.monsters = new List<Monster>();
        }

        public void Add(Monster monster)
        {
            monsters.Add(monster);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in monsters)
                item.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in monsters)
                item.Draw(spriteBatch);
        }

        public List<Monster> GetMonsters()
        {
            return monsters;
        }

    }
}
