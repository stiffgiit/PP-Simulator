using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;

public class SmallMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _objectsOnMap = new();
    private readonly int _sizeX;
    private readonly int _sizeY;

    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 5x5.");

        _sizeX = sizeX;
        _sizeY = sizeY;
    }

    public override bool Exist(Point point)
    {
        return point.X >= 0 && point.Y >= 0 && point.X < _sizeX && point.Y < _sizeY;
    }

    public override Point Next(Point point, Direction direction)
    {
        int newX = point.X;
        int newY = point.Y;

        switch (direction)
        {
            case Direction.Up:
                newY = (point.Y + 1) % _sizeY;
                break;
            case Direction.Down:
                newY = (point.Y - 1 + _sizeY) % _sizeY;
                break;
            case Direction.Left:
                newX = (point.X - 1 + _sizeX) % _sizeX;
                break;
            case Direction.Right:
                newX = (point.X + 1) % _sizeX;
                break;
        }

        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point point, Direction direction)
    {
        int newX = point.X;
        int newY = point.Y;

        switch (direction)
        {
            case Direction.Up:
                newY = (point.Y + 1) % _sizeY;
                break;
            case Direction.Down:
                newY = (point.Y - 1 + _sizeY) % _sizeY;
                break;
            case Direction.Left:
                newX = (point.X - 1 + _sizeX) % _sizeX;
                break;
            case Direction.Right:
                newX = (point.X + 1) % _sizeX;
                break;
            default:
                throw new ArgumentException("Unknown direction", nameof(direction));
        }

        return new Point(newX, newY);
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
