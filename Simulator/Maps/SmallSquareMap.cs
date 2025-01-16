namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size) { }

    public override Point Next(Point point, Direction direction)
    {
        Point next = point.Next(direction);
        return Exist(next) ? next : point;
    }

    public override Point NextDiagonal(Point point, Direction direction)
    {
        Point next = point.NextDiagonal(direction);
        return Exist(next) ? next : point;
    }
}