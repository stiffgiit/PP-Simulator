namespace Simulator.Maps;

public interface IMappable
{
    char Symbol { get; }
    void AssignMap(Map map, Point point);
    string Go(Direction direction);
    string ToString();
    Point GetPos();
}