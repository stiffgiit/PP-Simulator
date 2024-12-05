namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        var creature = new Creature("Orc",7);
        creature.SayHi();
        Console.WriteLine(creature.Info);


        var animal = new Animals { Description = "Dogs", Size = 3 };
        Console.WriteLine(animal.Info);


    }
}
