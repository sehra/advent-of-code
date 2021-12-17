namespace AdventOfCode.Year2021;

[TestClass]
public class Day17Tests
{
	private const string Input = "target area: x=20..30, y=-10..-5";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(45, new Day17(Input).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(112, new Day17(Input).Part2());
	}
}
