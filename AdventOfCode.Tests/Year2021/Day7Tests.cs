namespace AdventOfCode.Year2021;

[TestClass]
public class Day7Tests
{
	private const string Input = "16,1,2,0,4,2,7,1,2,14";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(37, new Day7(Input).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(168, new Day7(Input).Part2());
	}
}
