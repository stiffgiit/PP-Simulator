namespace Simulator;
public class Elf : Creature
{
    private int agility = 1;
    private int singCounter = 0;

    public override string Symbol => "A";

    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public Elf() { }

    public void Sing()
    {
        
        singCounter++;

        if (singCounter % 3 == 0 && agility < 10)
        {
            agility++;
        }
    }

    //public override string Greeting() => 
    // $"I'm {Name}, my level is {Level}, my agility is {Agility}.";

    //public override int Power => 8 * Level + 2 * Agility;

    

    public override void Move(Direction direction)
    {
        //throw new NotImplementedException();
        Console.WriteLine($"{Name} porusza się w kierunku {direction}");
        if (CurrentMap == null)
            throw new InvalidOperationException("Creature is not assigned to a map.");

        var nextPosition = CurrentMap.Next(Position, direction);
        CurrentMap.Move(Position, nextPosition, this);
        Position = nextPosition;
    }
}