using System;
using System.Collections.Generic;
using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    class Program : Animals
    {
        static void Main(string[] args)
        {


            Console.OutputEncoding = Encoding.UTF8;

            
            var map = new SmallTorusMap(8, 6);

            if (map == null)
            {
                throw new Exception("Mapa jest niezainicjowana.");
            }

            var creatures = new List<Creature>
            {
                new Orc("Gorbag", 2, 3),
                new Elf("Legolas", 2, 3),
                new Rabbit(),
                new Eagle(),
                new Ostrich()
            };
            var points = new List<Point>
            {
                new Point(2, 2),
                new Point(3, 1),
                new Point(4, 1),
                new Point(1, 2),
                new Point(2, 3),
            };
            var moves = "lrdulrudrldulru";

            
            var simulation = new Simulation(map, creatures, points, moves);
            var mapVisualizer = new MapVisualizer(simulation.Map);

            
            mapVisualizer.Draw(creatures,points);

            
            while (!simulation.Finished)
            {
                simulation.Turn();
                mapVisualizer.Draw(creatures,points);
                System.Threading.Thread.Sleep(2000); 
            }

        }
    }
}
