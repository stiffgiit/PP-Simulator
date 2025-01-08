namespace Simulator
{
    public readonly struct Point
    {
        public readonly int X, Y;

        public Point(int x, int y) => (X, Y) = (x, y);

        public override string ToString() => $"({X}, {Y})";

        public Point Next(Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Point(X, Y + 1),
                Direction.Down => new Point(X, Y - 1),
                Direction.Left => new Point(X - 1, Y),
                Direction.Right => new Point(X + 1, Y),
                _ => this
            };
        }

        public Point NextDiagonal(Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Point(X + 1, Y + 1),
                Direction.Down => new Point(X - 1, Y - 1),
                Direction.Left => new Point(X - 1, Y + 1),
                Direction.Right => new Point(X + 1, Y - 1),
                _ => this
            };
        }

        // Nadpisanie Equals
        public override bool Equals(object obj)
        {
            if (obj is Point other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        // Nadpisanie GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        // Przeciążenie operatorów porównania
        public static bool operator ==(Point left, Point right) => left.Equals(right);
        public static bool operator !=(Point left, Point right) => !left.Equals(right);
    }
}
