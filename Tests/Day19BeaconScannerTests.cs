using FluentAssertions;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class Day19BeaconScannerTests
{
    [Test]
    public void foo()
    {
        var inputData = @"--- scanner 0 ---
-1,-1,1
-2,-2,2
-3,-3,3
-2,-3,1
5,6,-4
8,0,7

--- scanner 0 ---
1,-1,1
2,-2,2
3,-3,3
2,-1,3
-5,4,-6
-8,-7,0

--- scanner 0 ---
-1,-1,-1
-2,-2,-2
-3,-3,-3
-1,-3,-2
4,6,5
-7,0,8

--- scanner 0 ---
1,1,-1
2,2,-2
3,3,-3
1,3,-2
-4,-6,5
7,0,8

--- scanner 0 ---
1,1,1
2,2,2
3,3,3
3,1,2
-6,-4,-5
0,7,-8";
        var scannerMap = ScannerParser.Parse(inputData.Split(Environment.NewLine));

        scannerMap.Scanners
            .Skip(1)
            .Count(x => x.OverlapsWith(scannerMap.Scanners.First(), 6)).Should().Be(6);
    }
}