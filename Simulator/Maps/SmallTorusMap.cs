using Simulator.Maps;
using Simulator;

public class SmallTorusMap : Map
{
    private readonly Dictionary<Point, List<Creature>> _creaturesOnMap = new();
    public int Size { get; }

    public SmallTorusMap(int size) : base(size, size) 
    {
        if (size is < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi być w przedziale od 5 do 20.");
        }

        Size = size;
        
    }

    private int Wrap(int coordinate) => (coordinate + Size) % Size;

    public override bool Exist(Point point)
    {
        return point.X >= 0 && point.X < Size && point.Y >= 0 && point.Y < Size;
    }

    public override Point Next(Point point, Direction direction)
    {
        var (newX, newY) = direction switch
        {
            Direction.Up => (point.X, point.Y + 1),
            Direction.Down => (point.X, point.Y - 1),
            Direction.Left => (point.X - 1, point.Y),
            Direction.Right => (point.X + 1, point.Y),
            _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
        };

        return new Point(Wrap(newX), Wrap(newY));
    }

    public override Point NextDiagonal(Point point, Direction direction)
    {
        var (newX, newY) = direction switch
        {
            Direction.Up => (point.X + 1, point.Y + 1),
            Direction.Down => (point.X - 1, point.Y - 1),
            Direction.Left => (point.X - 1, point.Y + 1),
            Direction.Right => (point.X + 1, point.Y - 1),
            _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
        };

        return new Point(Wrap(newX), Wrap(newY));
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
