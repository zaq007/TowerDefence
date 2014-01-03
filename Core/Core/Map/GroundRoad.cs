using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Map
{
    class GroundRoad : GroundItem
    {
        public GroundRoad(int X, int Y)
            : base(X, Y)
        {
            Texture = TextureLoader.Road;
        }
    }
}
