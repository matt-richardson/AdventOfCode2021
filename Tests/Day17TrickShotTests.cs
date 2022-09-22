using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day17TrickShot;

namespace Tests;

[TestFixture]
public class Day17TrickShotTests
{
    [Test]
    public void CanCalculateVelocities()
    {
        var calculator = new VelocityCalculator("target area: x=20..30, y=-10..-5");
        var results = calculator.Calculate().Select(x => x.InitialVelocity).ToArray();

        results.Should().Contain(new Velocity(7, 2));
        results.Should().Contain(new Velocity(6, 3));
        results.Should().Contain(new Velocity(9, 0));
        results.Should().NotContain(new Velocity(17, -4));
    }

    [Test]
    public void CanCalculateHighestPosition()
    {
        var calculator = new VelocityCalculator("target area: x=20..30, y=-10..-5");
        var results = calculator.Calculate().ToArray();
        var result = results
            .MaxBy(probe => probe.MaxYPosition)!;
        result.InitialVelocity.X.Should().Be(6);
        result.InitialVelocity.Y.Should().Be(9);
        result.MaxYPosition.Should().Be(45);
    }
}