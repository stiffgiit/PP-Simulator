using System;
using System.Collections.Generic;
using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.OutputEncoding = Encoding.UTF8;

            
            var map = new SmallSquareMap(5);

            if (map == null)
            {
                throw new Exception("Mapa jest niezainicjowana.");
            }

            var creatures = new List<Creature>
            {
                new Orc("Gorbag", 5, 2),
                new Elf("Elandor")
            };
            var points = new List<Point>
            {
                new Point(2, 2),
                new Point(3, 1)
            };
            var moves = "dlrludl";

            
            var simulation = new Simulation(map, creatures, points, moves);
            var mapVisualizer = new MapVisualizer(simulation.Map);

            
            mapVisualizer.Draw(creatures, points);

            
            while (!simulation.Finished)
            {
                simulation.Turn();
                mapVisualizer.Draw(creatures, points);
                System.Threading.Thread.Sleep(1000); 
            }

        }
    }
}
