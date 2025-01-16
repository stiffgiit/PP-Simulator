using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        int turn = 1;
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals{ Description = "Rabbits", Size = 6 },
            new Birds { Description = "Eagles", Size = 4, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
            ];

        List<Point> points = [
            new(2, 2),
            new(3, 1),
            new(3, 2),
            new(6, 5),
            new(5, 5)
            ];
        string moves = "dlrludlruddurlr";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine("\nStarting positions:");
        mapVisualizer.Draw();

        while (simulation.Finished == false)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine($"\nTurn: {turn}");
            Console.WriteLine($"{simulation.CurrentCreature} {simulation.CurrentCreature.GetPos()} goes {simulation.CurrentMoveName}:");
            simulation.Turn();
            mapVisualizer.Draw();
            turn++;
        }
    }
}