using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace Simulator
{
    public class Rabbit : Creature
    {
        public Rabbit(string name = "Rabbit", int size = 4) : base(name, size) { }
        public override string Symbol => "A";
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

        /*
        public override int Power => 1;  // Przykładowa moc
        public override string Info => $"Rabbit (Level {Level})";
        public override string Greeting() => "I am a rabbit!";
        */   
}

    // Klasa Orzeł
    public class Eagle : Creature
    {
        public Eagle(string name = "Eagle", int size = 3) : base(name, size) { }

        public override string Symbol => "B";
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

        /*
        public override int Power => 5;  // Przykładowa moc
        public override string Info => $"Eagle (Level {Level})";
        public override string Greeting() => "I am an eagle!";
        */
    }

    // Klasa Struś
    public class Ostrich : Creature
    {
        public Ostrich(string name = "Ostrich", int size = 2) : base(name, size) { }
        public override string Symbol => "b";

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

        /*
        public override int Power => 3;  // Przykładowa moc
        public override string Info => $"Ostrich (Level {Level})";
        public override string Greeting() => "I am an ostrich!";
        */
    }
}
