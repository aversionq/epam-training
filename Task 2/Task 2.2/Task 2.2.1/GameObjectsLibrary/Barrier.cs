﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
    class Barrier : GameObject
    {
        public Barrier(int x, int y) : base(x, y)
        {
            this.name = '/';
        }
    }
}
