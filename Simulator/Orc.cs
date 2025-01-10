namespace Simulator;
public class Orc : Creature
{
    private int rage = 1;
    private int huntCounter = 0;

    public override string Symbol => "A";
    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }

    public Orc(string name, int level, int rage) : base(name, level)
    {
        Rage = rage;
    }

    public Orc() { }

    public void Hunt()
    {
        
        huntCounter++;

        if (huntCounter % 2 == 0 && rage < 10)
        {
            rage++;
        }
    }

    /*
    public override string Greeting() => 
        $"I'm {Name}, my level is {Level}, my rage is {Rage}.";

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info => $"{Name} [{Level}][{Rage}]";
    */

    public override void Move(Direction direction)
    {
        Console.WriteLine($"{Name} porusza się w kierunku {direction}");
        if (CurrentMap == null)
            throw new InvalidOperationException("Creature is not assigned to a map.");

        var nextPosition = CurrentMap.Next(Position, direction);
        CurrentMap.Move(Position, nextPosition, this);
        Position = nextPosition;
    }

}