using Simulator.Maps;
using Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public IMappable CurrentCreature
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Blad! - Symulacja sie zakonczyla.");
            return Creatures[currentCreatureIndex];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Blad! - Symulacja sie zakonczyla.");
            return DirectionParser.Parse(Moves[currentMoveIndex].ToString())[0].ToString().ToLower();
        }
    }

    private int currentCreatureIndex = 0;
    private int currentMoveIndex = 0;

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
        {
            throw new ArgumentException("Blad! - Lista stworow nie moze byc pusta.");
        }

        if (positions.Count != creatures.Count)
        {
            throw new ArgumentException("Blad! - Lista pozycji startowych musi byc rowna liscie stworow.");
        }

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            Creatures[i].AssignMap(map, positions[i]);
        }

    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished) throw new InvalidOperationException("Blad! - Symulacja sie zakonczyla.");

        IMappable creature = CurrentCreature;
        Direction direction = DirectionParser.Parse(Moves)[currentMoveIndex];
        creature.Go(direction);

        currentMoveIndex++;
        if (currentMoveIndex >= Moves.Length)
        {
            Finished = true;
        }

        currentCreatureIndex++;
        if (currentCreatureIndex >= Creatures.Count)
        {
            currentCreatureIndex = 0;
        }
    }
}