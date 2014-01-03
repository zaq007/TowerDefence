﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Extensions
{
    public static class Player
    {
        static public int Health { get; set; }
        static public int Gold { get; set; }

        static Player()
        {
            Health = 100;
            Gold = 1000;
        }    
    }
}
