namespace AdventOfCode.Year2019;

[TestClass]
public class Day12Tests
{
	[DataTestMethod]
	[DataRow("<x=-1, y=0, z=2>\n<x=2, y=-10, z=-7>\n<x=4, y=-8, z=8>\n<x=3, y=5, z=-1>", 10, 179)]
	[DataRow("<x=-8, y=-10, z=0>\n<x=5, y=5, z=10>\n<x=2, y=-7, z=3>\n<x=9, y=-8, z=-3>", 100, 1940)]
	public void Part1(string input, int steps, int expected)
	{
		Assert.AreEqual(expected, new Day12(input).Part1(steps));
	}

	[DataTestMethod]
	[DataRow("<x=-1, y=0, z=2>\n<x=2, y=-10, z=-7>\n<x=4, y=-8, z=8>\n<x=3, y=5, z=-1>", 2772)]
	[DataRow("<x=-8, y=-10, z=0>\n<x=5, y=5, z=10>\n<x=2, y=-7, z=3>\n<x=9, y=-8, z=-3>", 4686774924)]
	public void Part2(string input, long expected)
	{
		Assert.AreEqual(expected, new Day12(input).Part2());
	}
}
