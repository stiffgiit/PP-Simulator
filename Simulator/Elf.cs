using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount;

    public int Agility
    {
        get => _agility;
        private set => _agility = Math.Clamp(value, 0, 10);
    }

    public Elf(string name = "Unknown", int level = 1, int agility = 0) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() : base()
    {
    }

    public override int Power => Level * 8 + Agility * 2;

    public void Sing()
    {
        _singCount++;
        if (_singCount % 3 == 0)
        {
            Agility++;
        }
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm an Elf named {Name}, Level {Level}, Agility {Agility}.");

    public override string Info => $"{Name} [{Level}][{Agility}]";
}
