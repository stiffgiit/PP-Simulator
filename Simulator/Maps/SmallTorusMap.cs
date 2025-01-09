using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;

public class SmallTorusMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _objectsOnMap = new();
    public int Size { get; }

    public SmallTorusMap(int size) : base(size, size)
    {
        if (size < 5 || size > 20)
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

    public override void Add(IMappable obj, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is out of map bounds.");

        if (!_objectsOnMap.ContainsKey(position))
        {
            _objectsOnMap[position] = new List<IMappable>();
        }

        _objectsOnMap[position].Add(obj);
    }

    public override void Remove(IMappable obj, Point position)
    {
        if (_objectsOnMap.ContainsKey(position))
        {
            _objectsOnMap[position].Remove(obj);
        }
    }

    public override void Move(Point from, Point to, IMappable obj)
    {
        if (!_objectsOnMap.ContainsKey(from) || !_objectsOnMap[from].Contains(obj))
        {
            throw new InvalidOperationException("Object not found at the source position.");
        }

        Remove(obj, from);
        Add(obj, to);
    }

    public override List<IMappable> At(Point position)
    {
        return _objectsOnMap.ContainsKey(position) ? _objectsOnMap[position] : new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
