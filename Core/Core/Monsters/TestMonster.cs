using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Monsters
{
    public class TestMonster : Monster
    {
        public TestMonster(int X, int Y)
            : base(X, Y)
        {
            Speed = 0.5f;
            Texture = TextureLoader.TestMonster;
            Animation = new Animation(Texture, 1);
            Health = 40;
            Defence = 2;
            Cost = 2;
        }
    }
}
