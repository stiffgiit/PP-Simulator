using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;

public class SmallSquareMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _objectsOnMap = new();

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
