using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    /// <summary>
    /// Map of points with defined boundaries.
    /// </summary>
    public abstract class Map
    {
        public int SizeX { get; }
        public int SizeY { get; }

        /// <summary>
        /// Constructor for a map with defined size.
        /// </summary>
        /// <param name="sizeX">Width of the map.</param>
        /// <param name="sizeY">Height of the map.</param>
        protected Map(int sizeX, int sizeY)
        {
            if (sizeX < 5 || sizeY < 5)
                throw new ArgumentOutOfRangeException("size", "Rozmiar mapy musi być w przedziale od 5 do 20.");

            SizeX = sizeX;
            SizeY = sizeY;
        }

        /// <summary>
        /// Check if the given point exists within the map boundaries.
        /// </summary>
        public abstract bool Exist(Point p);

        /// <summary>
        /// Get the next position in the given direction.
        /// </summary>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Get the next diagonal position in the given direction.
        /// </summary>
        public abstract Point NextDiagonal(Point p, Direction d);

        
        public abstract void Add(Creature creature, Point position);

        
        public abstract void Remove(Creature creature, Point position);

        public abstract void Move(Point from, Point to, Creature creature);

        public abstract List<Creature> At(Point position);
        public abstract List<Creature> At(int x, int y);


    }
}




