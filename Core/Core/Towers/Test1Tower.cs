using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Towers
{
    public class Test1Tower : Tower
    {
        public Test1Tower(int X, int Y)
            : base(X, Y)
        {
            Texture = TextureLoader.Tower;
            Speed = new TimeSpan(0, 0, 0, 1);
            Radius = 70f;
            Power = 0;
            Cost = 5;
        }
    }
}
