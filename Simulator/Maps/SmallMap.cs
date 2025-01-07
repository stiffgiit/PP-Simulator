using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    /// <summary>
    /// Map with a maximum size of 20x20.
    /// </summary>
    public class SmallMap : Map
    {
        private const int MaxSize = 20;

        public SmallMap(int sizeX, int sizeY)
            : base(Math.Min(sizeX, MaxSize), Math.Min(sizeY, MaxSize))
        {
            
        }

        
        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
        }

        public override Point Next(Point p, Direction d)
        {
            
            return p; 
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            
            return p; 
        }
    }
}
