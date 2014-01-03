using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Towers
{
    public class LargeTower : Tower
    {
        public LargeTower(int X, int Y)
            : base(X, Y)
        {
            Texture = TextureLoader.LargeTower;
            Speed = new TimeSpan(0, 0, 0, 1);
            Radius = 105f;
            Power = 3;
            Cost = 5;
        }
    }
}
