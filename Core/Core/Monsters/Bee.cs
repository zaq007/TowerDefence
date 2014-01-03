using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Monsters
{
    public class Bee : Monster
    {
        public Bee(int X, int Y)
            : base(X, Y)
        {
            Speed = 1f;
            Texture = TextureLoader.Bee;
            Animation = new Animation(Texture, 2);
            Health = 5;
            Defence = 3;
            Cost = 3;
        }
    }
}
