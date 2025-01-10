using Simulator.Maps;
using Simulator;

public interface IMappable
{
    Map CurrentMap { get; }
    Point Position { get; }
    void SetMap(Map map, Point position);
    string Symbol { get; }
}
