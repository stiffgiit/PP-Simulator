using Simulator.Maps;
using Simulator;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Write(Box.TopLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        for (int row = 0; row < _map.SizeY; row++)
        {
            Console.Write(Box.Vertical);
            for (int col = 0; col < _map.SizeX; col++)
            {
                var objectsAtPosition = _map.At(col, row);

                if (objectsAtPosition.Count > 0)
                {
                    var symbol = objectsAtPosition[0] is IMappable mappable
                        ? mappable.Symbol
                        : '?';

                    Console.Write($"{symbol}{Box.Vertical}");
                }
                else
                {
                    Console.Write($" {Box.Vertical}");
                }
            }
            Console.WriteLine();

            if (row < _map.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int col = 0; col < _map.SizeX - 1; col++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }

        Console.Write(Box.BottomLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
    }
}