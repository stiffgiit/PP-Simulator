namespace Simulator.Maps;
public abstract class SmallMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> creaturesAtPoints = new();

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 || sizeY > 20)
            throw new ArgumentOutOfRangeException("Rozmiar mapy musi mieścić się w granicach od 5 do 20 punktow!");
    }

    public override void Add(IMappable creature, Point point)
    {
        if (!Exist(point)) throw new ArgumentException("Punkt nie znajduje się na mapie!");
        if (!creaturesAtPoints.ContainsKey(point))
        {
            creaturesAtPoints[point] = new List<IMappable>();
        }
        creaturesAtPoints[point].Add(creature);
    }

    public override void Remove(IMappable creature, Point point)
    {
        if (creaturesAtPoints.TryGetValue(point, out var creatures))
        {
            creatures.Remove(creature);
            if (creatures.Count == 0) creaturesAtPoints.Remove(point);
        }
    }

    public override List<IMappable> At(Point point)
    {
        if (creaturesAtPoints.ContainsKey(point))
        {
            return creaturesAtPoints[point];
        }
        return new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public override Point Next(Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point(point.X, (point.Y - 1) % SizeY),
            Direction.Down => new Point(point.X, (point.Y + 1 + SizeY) % SizeY),
            Direction.Left => new Point((point.X - 1 + SizeX) % SizeX, point.Y),
            Direction.Right => new Point((point.X + 1) % SizeX, point.Y),
            _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
        };
    }

    public override Point NextDiagonal(Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point((point.X + 1) % SizeX, (point.Y - 1) % SizeY),
            Direction.Down => new Point((point.X - 1 + SizeX) % SizeX, (point.Y + 1 + SizeY) % SizeY),
            Direction.Left => new Point((point.X - 1 + SizeX) % SizeX, (point.Y + 1) % SizeY),
            Direction.Right => new Point((point.X + 1) % SizeX, (point.Y - 1 + SizeY) % SizeY),
            _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
        };
    }
}