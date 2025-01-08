using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class SimulationTests
    {
        [Fact]
        public void SimulationShouldThrowWhenCreaturesAndPositionsDoNotMatch()
        {
            // Arrange
            var map = new SmallMap(5, 5);
            var creatures = new List<Creature> { new DummyCreature("Dragon") };
            var positions = new List<Point> { new Point(1, 1), new Point(2, 2) };
            var moves = "up";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Simulation(map, creatures, positions, moves));
        }

        [Fact]
        public void SimulationShouldMoveCreaturesCorrectly()
        {
            // Arrange
            var map = new SmallMap(5, 5);
            var creature = new DummyCreature("Dragon");
            var creatures = new List<Creature> { creature };
            var positions = new List<Point> { new Point(2, 2) };
            var moves = "up";

            var simulation = new Simulation(map, creatures, positions, moves);

            // Act
            simulation.Turn();

            // Assert
            Assert.Equal(new Point(2, 3), creature.Position);
        }
    }

    public class DummyCreature : Creature
    {
        public DummyCreature(string name) : base(name) { }

        public override int Power => 10;
        public override string Info => "A dummy creature";
        public override string Greeting() => "Hello!";
    }
}
