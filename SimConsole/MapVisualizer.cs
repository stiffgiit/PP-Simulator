using System;
using System.Collections.Generic;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    public class MapVisualizer
    {
        public Map Map { get; }

        // Stałe dla rysowania mapy
        public const char
            Horizontal = '\u2500',
            Vertical = '\u2502',
            Cross = '\u253C',
            TopLeft = '\u250C',
            TopRight = '\u2510',
            BottomLeft = '\u2514',
            BottomRight = '\u2518',
            TopMid = '\u252C',
            BottomMid = '\u2534',
            MidLeft = '\u251C',
            MidRight = '\u2524';

        public MapVisualizer(Map map)
        {
            Map = map ?? throw new ArgumentNullException(nameof(map));
        }

        public void Draw(List<Creature> creatures, List<Point> points)
        {
            Console.Clear();

            for (int y = 0; y < Map.SizeY; y++)
            {
                Console.Write(TopLeft);
                for (int x = 0; x < Map.SizeX - 1; x++)
                    Console.Write(Horizontal + "" + Horizontal);
                Console.WriteLine(TopRight);

                for (int x = 0; x < Map.SizeX; x++)
                {
                    Console.Write(Vertical);

                    var creaturesAtPosition = Map.At(x, y); // Pobieranie stworów w danym punkcie
                    if (creaturesAtPosition.Count > 1)
                        Console.Write("X"); // Jeśli jest więcej niż jedno stworzenie, wyświetl "X"
                    else if (creaturesAtPosition.Count == 1)
                    {
                        var creature = creaturesAtPosition[0];
                        Console.Write(creature.Symbol); // Używamy symbolu stworzenia
                    }
                    else
                        Console.Write(" "); // Pusta przestrzeń
                }

                Console.WriteLine(Vertical);

                if (y == Map.SizeY - 1)
                {
                    Console.Write(BottomLeft);
                    for (int x = 0; x < Map.SizeX - 1; x++)
                        Console.Write(Horizontal + "" + Horizontal);
                    Console.WriteLine(BottomRight);
                }
                else
                {
                    Console.Write(MidLeft);
                    for (int x = 0; x < Map.SizeX - 1; x++)
                        Console.Write(Horizontal + "" + Horizontal);
                    Console.WriteLine(MidRight);
                }
            }
        }



        private void DrawHorizontalBorder(char left, char middle, char right)
        {
            Console.Write(left);
            for (int x = 0; x < Map.SizeX + 1; x++)
            {
                Console.Write(Horizontal);
                Console.Write(Horizontal);
                Console.Write(middle);
            }
            Console.Write(Horizontal);
            Console.WriteLine(Horizontal + "" + right);
        }
    }
}
