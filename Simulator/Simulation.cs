using Simulator.Maps;
using Simulator;

public class Simulation
{
    public Map Map { get; }
    public List<Creature> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }

    private int _currentTurnIndex = 0;
    private int _totalMovesMade = 0;

    public bool Finished { get; private set; } = false;

    public Creature CurrentCreature
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Simulation is finished.");
            return Creatures[_currentTurnIndex];
        }
    }

    public string CurrentMoveName
    {
        get
        {
            if (Finished) throw new InvalidOperationException("Simulation is finished.");
            int moveIndex = _totalMovesMade % Moves.Length;
            return Moves[moveIndex].ToString().ToLower();
        }
    }

    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || !creatures.Any())
            throw new ArgumentException("Creatures list cannot be empty.", nameof(creatures));
        if (positions == null || creatures.Count != positions.Count)
            throw new ArgumentException("Number of creatures must match the number of starting positions.", nameof(positions));
        if (string.IsNullOrEmpty(moves))
            throw new ArgumentException("Moves cannot be null or empty.", nameof(moves));

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = new List<Creature>(creatures);
        Positions = new List<Point>(positions);
        Moves = moves.ToLower();

        for (int i = 0; i < Creatures.Count; i++)
        {
            Creatures[i].SetMap(map, positions[i]);
            Map.Add(Creatures[i], positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Cannot make a turn. Simulation is finished.");

        Direction? direction = DirectionParser.Parse(CurrentMoveName).FirstOrDefault();
        if (direction == null)
        {
            throw new InvalidOperationException("Invalid direction parsed.");
        }

        var creature = CurrentCreature;
        var currentPosition = creature.Position;

        
        creature.Move(direction.Value);

        Map.Remove(creature, currentPosition);
        Map.Add(creature, creature.Position);

        _totalMovesMade++;
        _currentTurnIndex = (_currentTurnIndex + 1) % Creatures.Count;

        
        if (_totalMovesMade >= Moves.Length * Creatures.Count)
        {
            Finished = true;
        }
    }
}
