using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Monsters
{
    public class Fly : Monster
    {
        public Fly(int X, int Y)
            : base(X, Y)
        {
            Speed = 1.5f;
            Texture = TextureLoader.Fly;
            Animation = new Animation(Texture, 2);
            Health = 8;
            Defence = 2;
            Cost = 4;
        }
    }
}
