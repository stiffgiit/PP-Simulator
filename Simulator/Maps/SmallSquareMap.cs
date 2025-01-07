using Simulator.Maps;
using Simulator;

public class SmallSquareMap : Map
{
    private readonly Dictionary<Point, List<Creature>> _creaturesOnMap = new();

    public SmallSquareMap(int size)
        : base(Math.Min(Math.Max(size, 5), 20), Math.Min(Math.Max(size, 5), 20))  
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException("Size must be between 5 and 20.");
        Size = size;
    }


    public int Size { get; }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }

    public override Point Next(Point p, Direction d)
    {
        Point next = p.Next(d);
        return Exist(next) ? next : p; 
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonal = p.NextDiagonal(d);
        return Exist(nextDiagonal) ? nextDiagonal : p; 
    }

    public override void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is out of map bounds.");

        if (!_creaturesOnMap.ContainsKey(position))
        {
            _creaturesOnMap[position] = new List<Creature>();
        }

        _creaturesOnMap[position].Add(creature);
    }

    public override void Remove(Creature creature, Point position)
    {
        if (_creaturesOnMap.ContainsKey(position))
        {
            _creaturesOnMap[position].Remove(creature);
        }
    }

    public override void Move(Point from, Point to, Creature creature)
    {
        if (!_creaturesOnMap.ContainsKey(from) || !_creaturesOnMap[from].Contains(creature))
        {
            throw new InvalidOperationException("Creature not found at the source position.");
        }

        
        Remove(creature, from);
        Add(creature, to);
    }

    public override List<Creature> At(Point position)
    {
        return _creaturesOnMap.ContainsKey(position) ? _creaturesOnMap[position] : new List<Creature>();
    }

    public override List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
