﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.FuruHana
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }




        public Vector2()
        {
            X = Zero().X;
            Y = Zero().Y;
        }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }
    }
}
