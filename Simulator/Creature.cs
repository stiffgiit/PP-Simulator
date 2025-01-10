using Simulator.Maps;
using Simulator;
using System;

namespace Simulator
{
    public abstract class Creature : Animals
    {
        private string name = "Unknown";

        public abstract string Symbol { get; }
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
        public Point Position { get; set; }

        public Creature(string name, int level = 1) 
        {
            Name = name;
            Level = level;
        }

        public Creature() { }

        public  int Power { get; }
        new public string Info { get; }
        //new public string Greeting();


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


        // Ogólny sposób poruszania się
        public abstract void Move(Direction direction);
        

        public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

        protected string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }
    }
}
