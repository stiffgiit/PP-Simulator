namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; set; }
    public int SizeY { get; set; }

    public readonly Rectangle _map;

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Rozmiar mapy musi mieścić się w granicach od 5 do 20 punktow!");

        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public bool Exist(Point point)
    {
        return _map.Contains(point);
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public abstract void Add(IMappable creature, Point point);

    public void Move(IMappable creature, Point pos, Point nextpos)
    {
        Remove(creature, pos);
        Add(creature, nextpos);
    }

    public abstract void Remove(IMappable creature, Point point);
    public abstract List<IMappable> At(Point point);
    public abstract List<IMappable> At(int x, int y);
}