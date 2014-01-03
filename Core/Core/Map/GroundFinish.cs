using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;

namespace Core.Map
{
    public class GroundFinish : GroundItem
    {
        public GroundFinish(int X, int Y)
            : base(X, Y)
        {
            Texture = TextureLoader.Finish;
        }
    }
}
