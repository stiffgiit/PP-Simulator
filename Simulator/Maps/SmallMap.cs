namespace Simulator.Maps
{
    public class SmallMap : Map
    {
        private readonly Dictionary<Point, List<Creature>> _creaturesOnMap = new();
        private readonly int _sizeX;
        private readonly int _sizeY;

        public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX < 5 || sizeY < 5)
                throw new ArgumentOutOfRangeException("Map dimensions must be at least 5x5.");

            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public override bool Exist(Point point)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < _sizeX && point.Y < _sizeY;
        }

        
        public override Point Next(Point point, Direction direction)
        {
            int newX = point.X;
            int newY = point.Y;

            switch (direction)
            {
                case Direction.Up:
                    newY = (point.Y + 1) % _sizeY;
                    break;
                case Direction.Down:
                    newY = (point.Y - 1 + _sizeY) % _sizeY;
                    break;
                case Direction.Left:
                    newX = (point.X - 1 + _sizeX) % _sizeX;
                    break;
                case Direction.Right:
                    newX = (point.X + 1) % _sizeX;
                    break;
            }

            return new Point(newX, newY);
        }

        
        public override Point NextDiagonal(Point point, Direction direction)
        {
            int newX = point.X;
            int newY = point.Y;

            switch (direction)
            {
                case Direction.Up:
                    newY = (point.Y + 1) % _sizeY;
                    break;
                case Direction.Down:
                    newY = (point.Y - 1 + _sizeY) % _sizeY;
                    break;
                case Direction.Left:
                    newX = (point.X - 1 + _sizeX) % _sizeX;
                    break;
                case Direction.Right:
                    newX = (point.X + 1) % _sizeX;
                    break;
                case Direction.UpLeft:
                    newX = (point.X - 1 + _sizeX) % _sizeX;
                    newY = (point.Y + 1) % _sizeY;
                    break;
                case Direction.UpRight:
                    newX = (point.X + 1) % _sizeX;
                    newY = (point.Y + 1) % _sizeY;
                    break;
                case Direction.DownLeft:
                    newX = (point.X - 1 + _sizeX) % _sizeX;
                    newY = (point.Y - 1 + _sizeY) % _sizeY;
                    break;
                case Direction.DownRight:
                    newX = (point.X + 1) % _sizeX;
                    newY = (point.Y - 1 + _sizeY) % _sizeY;
                    break;
                default:
                    throw new ArgumentException("Nieznany kierunek", nameof(direction));
            }

            return new Point(newX, newY);
        }

        public override void Add(Creature creature, Point position)
        {
            if (!Exist(position))
                throw new ArgumentOutOfRangeException(nameof(position), "Point is out of map bounds.");

            if (!_creaturesOnMap.ContainsKey(position))
            {
                _creaturesOnMap[position] = new List<Creature>();
            }

            _creaturesOnMap[position].Add(creature);
        }

        public override void Remove(Creature creature, Point position)
        {
            if (_creaturesOnMap.ContainsKey(position))
            {
                _creaturesOnMap[position].Remove(creature);
            }
        }

        public override void Move(Point from, Point to, Creature creature)
        {
            if (!_creaturesOnMap.ContainsKey(from) || !_creaturesOnMap[from].Contains(creature))
            {
                throw new InvalidOperationException("Creature not found at the source position.");
            }

            
            Remove(creature, from);
            Add(creature, to);
        }

        public override List<Creature> At(Point position)
        {
            return _creaturesOnMap.ContainsKey(position) ? _creaturesOnMap[position] : new List<Creature>();
        }

        public override List<Creature> At(int x, int y)
        {
            return At(new Point(x, y));
        }
    }
}
