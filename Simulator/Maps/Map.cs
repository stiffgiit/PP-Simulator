using System;
using System.Collections.Generic;

namespace Simulator.Maps
{
    public abstract class Map
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }

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

        public virtual void Draw()
        {
            for (int y = 0; y < SizeY; y++)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    var entities = At(x, y);
                    if (entities.Count == 1)
                        Console.Write(entities[0].Symbol); // Symbol pojedynczego obiektu
                    else if (entities.Count > 1)
                        Console.Write("X"); // Więcej niż jeden obiekt
                    else
                        Console.Write("."); // Puste pole
                }
                Console.WriteLine();
            }
        }
    }
}
