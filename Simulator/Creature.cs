using Simulator.Maps;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Simulator;

public abstract class Creature : IMappable
{
    private string name = "Unknown";
    private int level = 1;

    public abstract int Power { get; }
    public virtual char Symbol => 'C';
    public Map? CurrentMap { get; private set; } = null;
    public Point CreaturePos { get; private set; }

    public string Name
    {
        get { return name; }
        init { name = Validator.Shortener(value, 3, 25, '#'); }
    }

    public int Level
    {
        get { return level; }
        init { level = Validator.Limiter(value, 1, 10); }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Greeting();

    public abstract string Info { get; }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public void AssignMap(Map map, Point point)
    {
        if (CurrentMap != null)
        {
            throw new InvalidOperationException("Blad! - Mapa byla juz wczesniej przydzielona.");
        }
        CurrentMap = map;
        CreaturePos = point;
        CurrentMap.Add(this, point);
    }

    public string Go(Direction direction)
    {
        if (CurrentMap != null)
        {
            var newPos = CurrentMap.Next(CreaturePos, direction);
            CurrentMap.Move(this, CreaturePos, newPos);
            CreaturePos = newPos;
            return $"{direction.ToString().ToLower()}";
        }
        else
        {
            throw new InvalidOperationException("Blad! - Stwor nie ma jeszcze przydzielonej mapy.");
        }
    }

    public Point GetPos()
    {
        return CreaturePos;
    }
}