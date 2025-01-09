using Simulator.Maps;
using System;

namespace Simulator
{
    public abstract class Creature : IMappable
    {
        private string name = "Unknown";

        public string Name
        {
            get => name;
            init => name = Validator.Shortener(FormatName(value), 3, 25, '#');
        }

        private int level = 1;

        public int Level
        {
            get => level;
            init => level = Validator.Limiter(value, 1, 10);
        }

        public Map CurrentMap { get; private set; }
        public Point Position { get; private set; }

        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        public Creature() { }

        public abstract int Power { get; }
        public abstract string Info { get; }
        public abstract string Greeting();

        public void Upgrade()
        {
            if (Level < 10)
            {
                level++;
            }
        }

        public void SetMap(Map map, Point position)
        {
            CurrentMap = map ?? throw new ArgumentNullException(nameof(map));
            Position = position;
            CurrentMap.Add(this, position);
        }

        public void Go(Direction direction)
        {
            if (CurrentMap == null)
                throw new InvalidOperationException("Creature is not assigned to a map.");

            var nextPosition = CurrentMap.Next(Position, direction);
            CurrentMap.Move(Position, nextPosition, this);
            Position = nextPosition;
        }

        public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

        protected string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }
    }
}
