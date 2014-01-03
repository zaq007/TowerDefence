using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Extensions;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Core.Map
{
    public class Ground
    {
        public static int MapWidth = 15;
        public static int MapHeight = 15;
        static public char[,] Mask { get; set; }
        GroundItem[,] Map {get; set;}
        public static Point Start { get; set; }
        public static Point End { get; set; }


        public Ground()
        {
            Map = new GroundItem[15, 15];
            Mask = FileIO.GetLevelMask();
            for (int i=0; i<15; i++)
                for (int j=0; j<15; j++)
                    switch (Mask[i, j])
                    {
                        case '0': Map[i, j] = new GroundNon(i, j); break;
                        case '1': Map[i, j] = new GroundStart(i, j); Start = new Point(i, j); break;
                        case '2': Map[i, j] = new GroundRoad(i, j); break;
                        case '3': Map[i, j] = new GroundFinish(i, j); End = new Point(i, j); break;
                    }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in Map)
                item.Draw(spriteBatch);
        }

    }
}
