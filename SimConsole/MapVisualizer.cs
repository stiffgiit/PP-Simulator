using System;
using System.Collections.Generic;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    public class MapVisualizer
    {
        public Map Map { get; }

        
        public const char
            Horizontal = '\u2500',
            Vertical = '\u2502',
            Cross = '\u253C',
            TopLeft = '\u250C',
            TopRight = '\u2510',
            TopMid = '\u252C',
            BottomLeft = '\u2514',
            BottomMid = '\u2534',
            BottomRight = '\u2518',
            MidLeft = '\u251C',
            MidRight = '\u2524';

        public MapVisualizer(Map map)
        {
            Map = map;
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

                   
                    var creaturesAtPosition = Map.At(x, y);  
                    if (creaturesAtPosition.Count > 1)
                        Console.Write("X"); 
                    else if (creaturesAtPosition.Count == 1)
                        Console.Write(creaturesAtPosition[0] is Orc ? "O" : "E"); 
                    else
                        Console.Write(" "); 
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
    }
}
