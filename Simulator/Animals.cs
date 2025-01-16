using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "No description.";
    public string Description
    {
        get { return description; }
        init { description = Validator.Shortener(value, 3, 15, '#'); }
    }

    public uint Size { get; set; } = 3;
    public Map? CurrentMap { get; private set; } = null;
    public Point CreaturePos { get; set; }
    public virtual char Symbol => 'A';

    public virtual string Info => $"{Description} <{Size}>";

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

    public Point GetPos()
    {
        return CreaturePos;
    }

    public virtual string Go(Direction direction)
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
            throw new InvalidOperationException("Blad! - Zwierze nie ma jeszcze przydzielonej mapy.");
        }
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}