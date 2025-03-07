﻿using Simulator;
using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        //Lab4a();
        //Lab4b();
        Lab5a();
        Lab5b();

    }
    /*
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */



    public static void Lab5a()
    {
        try
        {
            Rectangle rect = new Rectangle(10, 5, 15, 10);
            Console.WriteLine(rect);

            Point p = new Point(12, 7);
            Console.WriteLine($"Contains {p}: {rect.Contains(p)}");

            Point outside = new Point(20, 20);
            Console.WriteLine($"Contains {outside}: {rect.Contains(outside)}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public static void Lab5b()
    {
        try
        {
            SmallSquareMap map = new SmallSquareMap(10);
            Point p = new Point(0, 0);

            Console.WriteLine(map.Exist(p)); // true
            Console.WriteLine(map.Next(p, Direction.Right)); // (1, 0)
            Console.WriteLine(map.NextDiagonal(p, Direction.Right)); // (1, -1)
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }



}