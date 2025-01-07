using Simulator.Maps;
using System;
using Xunit;

namespace Simulator.Tests
{
    public class CreatureTests
    {
        [Fact]
        public void CreatureShouldMoveCorrectly()
        {
            var map = new SmallMap(5, 5);
            var creature = new DummyCreature("Dragon");
            creature.SetMap(map, new Point(2, 2));

            
            creature.Go(Direction.Up);
            Assert.Equal(new Point(2, 3), creature.Position);

            
            creature.Go(Direction.Left);
            Assert.Equal(new Point(1, 3), creature.Position);
        }
    }

    public class DummyCreature : Creature
    {
        public DummyCreature(string name) : base(name) { }

        public override int Power => 10;
        public override string Info => "A powerful creature";
        public override string Greeting() => "Hello!";
    }
}
