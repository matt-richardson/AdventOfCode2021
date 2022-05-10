using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day11DumboOctopus;

namespace Tests;

public class Day11DumboOctopus
{
    [Test]
    public void CanRender()
    {
        var sampleData = new[] {
            "11111",
            "19991",
            "19191",
            "19991",
            "11111"
        };
        var grid = new OctopusGrid(sampleData);
        grid.Render().Should().BeEquivalentTo(sampleData);
    }
    
    [Test]
    public void SimpleExample()
    {
        var grid = new OctopusGrid(new[] {
            "11111",
            "19991",
            "19191",
            "19991",
            "11111"
        });
        grid.Step();

        grid.Render().Should().BeEquivalentTo(new[] {
            "34543",
            "40004",
            "50005",
            "40004",
            "34543"
        }, o => o.WithStrictOrderingFor(x => x));
        
        grid.Step();

        grid.Render().Should().BeEquivalentTo(new[] {
            "45654",
            "51115",
            "61116",
            "51115",
            "45654"
        }, o => o.WithStrictOrderingFor(x => x));
    }

    [Test]
    public void MoreComplexExample()
    {
        var grid = new OctopusGrid(new[] {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        });
        for (var i = 0; i < 10; i++)
            grid.Step();
        grid.Render().Should().BeEquivalentTo(new[] {
            "0481112976",
            "0031112009",
            "0041112504",
            "0081111406",
            "0099111306",
            "0093511233",
            "0442361130",
            "5532252350",
            "0532250600",
            "0032240000"
        }, o => o.WithStrictOrderingFor(x => x));
        grid.FlashCount.Should().Be(204);
    }
    
    [Test]
    public void MoreComplexExampleWith100Steps()
    {
        var grid = new OctopusGrid(new[] {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        });
        for (var i = 0; i < 100; i++)
            grid.Step();
        grid.FlashCount.Should().Be(1656);
    }
}
