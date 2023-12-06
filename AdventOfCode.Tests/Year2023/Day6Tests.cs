namespace AdventOfCode.Year2023;

[TestClass]
public class Day6Tests
{
	private const string Input =
		"""
		Time:      7  15   30
		Distance:  9  40  200
		""";

	[DataTestMethod]
	[DataRow(288, Input)]
	public void Part1(long expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(71503, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input.ToLines()).Part2());
	}
}
