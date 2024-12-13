using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount;

    public int Rage
    {
        get => _rage;
        set => _rage = Math.Clamp(value, 0, 10);
    }

    public Orc(string name = "Unknown", int level = 1, int rage = 0) : base(name, level)
    {
        Rage = rage;
    }

    public Orc() : base()
    {
    }

    public override int Power => Level * 7 + Rage * 3;

    public void Hunt()
    {
        _huntCount++;
        if (_huntCount % 2 == 0)
        {
            Rage++;
        }
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm an Orc named {Name}, Level {Level}, Rage {Rage}.");

    public override string Info => $"{Name} [{Level}][{Rage}]";
}
