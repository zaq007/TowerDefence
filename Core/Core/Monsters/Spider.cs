using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Monsters
{
    public class Spider : Monster
    {
        public Spider(int X, int Y)
            : base(X, Y)
        {
            Speed = 2f;
            Texture = TextureLoader.Spider;
            Animation = new Animation(Texture, 5);
            Health = 15;
            Defence = 2;
            Cost = 7;
        }
    }
}
