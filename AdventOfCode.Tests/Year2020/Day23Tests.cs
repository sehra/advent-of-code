namespace AdventOfCode.Year2020;

[TestClass]
public class Day23Tests
{
	private const string Input = "389125467";

	[DataTestMethod]
	[DataRow("92658374", Input, 10)]
	[DataRow("67384529", Input, 100)]
	public void Part1(string expected, string input, int moves)
	{
		Assert.AreEqual(expected, new Day23(input).Part1(moves));
	}

	[DataTestMethod]
	[DataRow(149245887792, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input).Part2());
	}
}
