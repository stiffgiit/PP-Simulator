using Simulator.Maps;
using Simulator;
using System;

namespace Simulator
{

    
    public class Animals : IMappable
    {
        private string description = "Unknown";
        public uint Size { get; set; } = 3;

        public Map CurrentMap { get; private set; }
        public Point Position { get; set; }

        public string Description
        {
            get => description;
            init => description = Validator.Shortener(value, 3, 15, '#');
        }

        public string Info => $"{FormatName(Description)} <{Size}>";

        
        public string Symbol => "A";

        
        public void SetMap(Map map, Point position)
        {
            CurrentMap = map ?? throw new ArgumentNullException(nameof(map));
            Position = position;
            CurrentMap.Add(this, position);  
        }

        
        public void WalkDiagonally(Direction direction)
        {
            if (CurrentMap == null)
                throw new InvalidOperationException("Animal is not assigned to a map.");

            var nextPosition = CurrentMap.NextDiagonal(Position, direction); 
            CurrentMap.Move(Position, nextPosition, this);
            Position = nextPosition;
        }

        public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

        protected string FormatName(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            return char.ToUpper(name.Trim()[0]) + name.Trim().Substring(1).ToLower();
        }
    }
}
