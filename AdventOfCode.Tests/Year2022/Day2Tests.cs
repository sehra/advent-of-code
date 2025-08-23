namespace AdventOfCode.Year2022;

[TestClass]
public class Day2Tests
{
	private const string Input =
		"""
		A Y
		B X
		C Z
		""";

	[TestMethod]
	[DataRow(15, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(12, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part2());
	}
}
