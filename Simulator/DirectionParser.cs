﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public static class DirectionParser
    {
        public static Direction[] Parse(string input)
        {
            var directions = new List<Direction>();

            foreach (char c in input.ToUpper())
            {
                switch (c)
                {
                    case 'U':
                        directions.Add(Direction.Up);
                        break;
                    case 'R':
                        directions.Add(Direction.Right);
                        break;
                    case 'D':
                        directions.Add(Direction.Down);
                        break;
                    case 'L':
                        directions.Add(Direction.Left);
                        break;
                }
            }

            return directions.ToArray();
        }

    }
}
