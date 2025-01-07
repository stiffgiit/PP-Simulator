using System;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public int Size { get; }
        private readonly Rectangle _map;

        public SmallTorusMap(int size) : base(size, size)  // Przekazujemy sizeX i sizeY do klasy bazowej
        {

            if (size is < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi być w przedziale od 5 do 20.");
            }

            Size = size;
            _map = new Rectangle(0, 0, Size - 1, Size - 1);  // Zmieniamy wymiary prostokąta, uwzględniając torusową mapę
        }

        public override bool Exist(Point point)
        {
            // Zmieniamy metodę, aby poprawnie obsługiwała torusowe współrzędne
            return point.X >= 0 && point.X < Size && point.Y >= 0 && point.Y < Size;
        }

        public override Point Next(Point point, Direction direction)
        {
            var (newX, newY) = direction switch
            {
                Direction.Up => (point.X, point.Y + 1),
                Direction.Down => (point.X, point.Y - 1),
                Direction.Left => (point.X - 1, point.Y),
                Direction.Right => (point.X + 1, point.Y),
                _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
            };

            return new Point(Wrap(newX), Wrap(newY));
        }

        public override Point NextDiagonal(Point point, Direction direction)
        {
            var (newX, newY) = direction switch
            {
                Direction.Up => (point.X + 1, point.Y + 1),
                Direction.Down => (point.X - 1, point.Y - 1),
                Direction.Left => (point.X - 1, point.Y + 1),
                Direction.Right => (point.X + 1, point.Y - 1),
                _ => throw new ArgumentException("Nieznany kierunek", nameof(direction))
            };

            return new Point(Wrap(newX), Wrap(newY));
        }

        private int Wrap(int coordinate) => (coordinate + Size) % Size;
    }
}
