using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Timers;

namespace Core.Monsters
{
    public class Animation
    {
        Texture2D Texture;
        int Frames;
        int Current;
        Timer timer;

        public Animation(Texture2D texture, int frames)
        {
            Texture = texture;
            Frames = frames;
            Current = 0;
            timer = new Timer(150);
            timer.AutoReset = true;
            timer.Elapsed += delegate(object sender, ElapsedEventArgs e)
            {
                Current++;
                if (Current == Frames)
                    Current = 0;
            };
            timer.Start();
        }

        public Rectangle GetFrame()
        {
            Rectangle rect = new Rectangle(35*Current, 0, 35, 35);            
            return rect;
        }

    }
}
