using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Monsters
{
    public class Ladybug : Monster
    {
        public Ladybug(int X, int Y)
            : base(X, Y)
        {
            Speed = 0.5f;
            Texture = TextureLoader.Lady;
            Animation = new Animation(Texture, 4);
            Health = 30;
            Defence = 5;
            Cost = 10;
        }
    }
}
