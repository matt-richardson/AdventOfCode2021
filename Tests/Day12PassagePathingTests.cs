using FluentAssertions;
using NUnit.Framework;
using Puzzles.Day12PassagePathing;

namespace Tests;

public class Day12PassagePathingTests
{
    [Test]
    public void Part1FindsCorrectNumberOfPathsThroughSampleData()
    {
        var sampleData = new[]
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end"
        };

        var expectedPaths = new[]
        {
            "start,A,b,A,c,A,end",
            "start,A,b,A,end",
            "start,A,b,end",
            "start,A,c,A,b,A,end",
            "start,A,c,A,b,end",
            "start,A,c,A,end",
            "start,A,end",
            "start,b,A,c,A,end",
            "start,b,A,end",
            "start,b,end"
        };

        var pathFinder = new PathFinder(sampleData);
        var results = pathFinder.Part1Paths;
       
        results.Select(x => x.ToString()).Should().BeEquivalentTo(expectedPaths);
    }

    [Test] 
    public void Part1FindsCorrectNumberOfPathsThroughSlightlyLargerSampleData()
    {
        var sampleData = new[]
        {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc",
        };

        var expectedPaths = new[]
        {
            "start,HN,dc,HN,end",
            "start,HN,dc,HN,kj,HN,end",
            "start,HN,dc,end",
            "start,HN,dc,kj,HN,end",
            "start,HN,end",
            "start,HN,kj,HN,dc,HN,end",
            "start,HN,kj,HN,dc,end",
            "start,HN,kj,HN,end",
            "start,HN,kj,dc,HN,end",
            "start,HN,kj,dc,end",
            "start,dc,HN,end",
            "start,dc,HN,kj,HN,end",
            "start,dc,end",
            "start,dc,kj,HN,end",
            "start,kj,HN,dc,HN,end",
            "start,kj,HN,dc,end",
            "start,kj,HN,end",
            "start,kj,dc,HN,end",
            "start,kj,dc,end",
        };

        var pathFinder = new PathFinder(sampleData);
        var results = pathFinder.Part1Paths;
       
        results.Select(x => x.ToString()).Should().BeEquivalentTo(expectedPaths);
    }
    
    [Test] 
    public void Part1FindsCorrectNumberOfPathsThroughEvenLargerSampleData()
    {
        var sampleData = new[]
        {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW",
        };

        var pathFinder = new PathFinder(sampleData);
        var results = pathFinder.Part1Paths;

        results.Count().Should().Be(226);
    }

    [Test]
    public void CalculatesPart1()
    {
        Console.WriteLine(new Day12PassagePathing().Calculate().answer1);
    }
    
    [Test]
    public void Part2FindsCorrectNumberOfPathsThroughSampleData()
    {
        var sampleData = new[]
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end"
        };

        var expectedPaths = new[]
        {
            "start,A,b,A,b,A,c,A,end",
            "start,A,b,A,b,A,end",
            "start,A,b,A,b,end",
            "start,A,b,A,c,A,b,A,end",
            "start,A,b,A,c,A,b,end",
            "start,A,b,A,c,A,c,A,end",
            "start,A,b,A,c,A,end",
            "start,A,b,A,end",
            "start,A,b,d,b,A,c,A,end",
            "start,A,b,d,b,A,end",
            "start,A,b,d,b,end",
            "start,A,b,end",
            "start,A,c,A,b,A,b,A,end",
            "start,A,c,A,b,A,b,end",
            "start,A,c,A,b,A,c,A,end",
            "start,A,c,A,b,A,end",
            "start,A,c,A,b,d,b,A,end",
            "start,A,c,A,b,d,b,end",
            "start,A,c,A,b,end",
            "start,A,c,A,c,A,b,A,end",
            "start,A,c,A,c,A,b,end",
            "start,A,c,A,c,A,end",
            "start,A,c,A,end",
            "start,A,end",
            "start,b,A,b,A,c,A,end",
            "start,b,A,b,A,end",
            "start,b,A,b,end",
            "start,b,A,c,A,b,A,end",
            "start,b,A,c,A,b,end",
            "start,b,A,c,A,c,A,end",
            "start,b,A,c,A,end",
            "start,b,A,end",
            "start,b,d,b,A,c,A,end",
            "start,b,d,b,A,end",
            "start,b,d,b,end",
            "start,b,end",
        };

        var pathFinder = new PathFinder(sampleData);
        var results = pathFinder.Part2Paths;
       
        results.Select(x => x.ToString()).Should().BeEquivalentTo(expectedPaths);
    }

    [Test] 
    public void Part2FindsCorrectNumberOfPathsThroughSlightlyLargerSampleData()
    {
        var sampleData = new[]
        {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc",
        };

        var pathFinder = new PathFinder(sampleData);
        var results = pathFinder.Part2Paths;
       
        results.Count().Should().Be(103);
    }
    
    [Test] 
    public void Part2FindsCorrectNumberOfPathsThroughEvenLargerSampleData()
    {
        var sampleData = new[]
        {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW",
        };

        var pathFinder = new PathFinder(sampleData);
        var results = pathFinder.Part2Paths;

        results.Count().Should().Be(3509);
    }

    [Test]
    public void CalculatesPart2()
    {
        Console.WriteLine(new Day12PassagePathing().Calculate().answer2);
    }
}
