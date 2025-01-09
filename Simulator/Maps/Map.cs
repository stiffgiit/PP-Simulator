using System;
using System.Collections.Generic;

namespace Simulator.Maps
{
    public abstract class Map
    {
        public int SizeX { get; }
        public int SizeY { get; }

        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5 || sizeY < 5)
                throw new ArgumentOutOfRangeException("size", "Map size must be between 5 and 20.");

            SizeX = sizeX;
            SizeY = sizeY;
        }

        public abstract bool Exist(Point p);
        public abstract Point Next(Point p, Direction d);
        public abstract Point NextDiagonal(Point p, Direction d);
        public abstract void Add(IMappable obj, Point position);  
        public abstract void Remove(IMappable obj, Point position);  
        public abstract void Move(Point from, Point to, IMappable obj);  
        public abstract List<IMappable> At(Point position);  
        public abstract List<IMappable> At(int x, int y); 
    }
}
