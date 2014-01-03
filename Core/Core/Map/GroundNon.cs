using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Map
{
    class GroundNon : GroundItem
    {
        public GroundNon(int X, int Y)
            : base(X, Y)
        {
            Texture = TextureLoader.None;
        }
    }
}
