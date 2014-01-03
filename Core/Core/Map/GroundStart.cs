using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Map
{
    class GroundStart : GroundItem
    {
        public GroundStart(int X, int Y)
            : base(X, Y)
        {
            Texture = TextureLoader.Start;
        }
    }
}
