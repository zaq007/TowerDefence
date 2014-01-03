using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Monsters
{
    public class Bug : Monster
    {
        public Bug (int X, int Y)
            : base(X, Y)
        {
            Speed = 0.6f;
            Texture = TextureLoader.Bug;
            Animation = new Animation(Texture, 2);
            Health = 7;
            Defence = 0;
            Cost = 2;
        }
    }
}
