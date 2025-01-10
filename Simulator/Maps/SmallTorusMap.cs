namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX < 5 || sizeX > 20 || sizeY < 5 || sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Rozmiar mapy musi być w przedziale od 5 do 20.");
        }

        SizeX = sizeX;
        SizeY = sizeY;
    }
    private Point CorrectTorusPos(Point point)
    {
        var x = point.X;
        var y = point.Y;

        while (x < 0)
        {
            x += SizeX;
        }
        while (x >= SizeX)
        {
            x -= SizeX;
        }

        while (y < 0)
        {
            y += SizeY;
        }
        while (y >= SizeY)
        {
            y -= SizeY;
        }

        return new Point(x, y);
    }

    public override Point Next(Point p, Direction d)
    {
        return CorrectTorusPos(p.Next(d));
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return CorrectTorusPos(p.NextDiagonal(d));
    }
}