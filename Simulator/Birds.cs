using Simulator.Maps;
using System;
using System.Xml.Linq;

namespace Simulator
{
    public class Birds : Creature
    {
        public bool CanFly { get; set; } = true;

        public Birds(string description, uint size = 3)
        {
            Description = description; // Inicjalizacja opisu ptaka
            Size = size;
        }

        public override void Move(Direction direction)
        {
            if (CanFly)
            {
                // Logika ruchu ptaka, jeśli może latać
                Console.WriteLine($"{Name} lata w kierunku {direction}");
                // Przemieszczanie się na mapie o 2 pola
            }
            else
            {
                // Logika ruchu ptaka, jeśli nie może latać (np. chodzenie po skosie)
                Console.WriteLine($"{Name} chodzi w kierunku {direction}");
            }
        }

        public override string Symbol => CanFly ? "B" : "b";

        // Metoda latania dla ptaków
        public void Fly(Direction direction)
        {
            if (!CanFly)
                throw new InvalidOperationException("This bird cannot fly.");

            if (CurrentMap == null)
                throw new InvalidOperationException("Bird is not assigned to a map.");

            // Wykonaj ruch o 2 pola w zadanym kierunku
            var nextPosition = CurrentMap.Next(Position, direction);
            nextPosition = CurrentMap.Next(nextPosition, direction); // Przemieszczenie o kolejne pole

            CurrentMap.Move(Position, nextPosition, this);
            Position = nextPosition;
        }

        // Metoda do chodzenia po skosie dla ptaków nielotnych
        public void WalkDiagonally(Direction direction)
        {
            if (!CanFly)
            {
                if (CurrentMap == null)
                    throw new InvalidOperationException("Bird is not assigned to a map.");

                var nextPosition = CurrentMap.NextDiagonal(Position, direction);
                CurrentMap.Move(Position, nextPosition, this);
                Position = nextPosition;
            }
            else
            {
                throw new InvalidOperationException("This bird can fly, so it cannot walk diagonally.");
            }
        }
    }
}
