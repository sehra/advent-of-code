namespace AdventOfCode.Year2016;

[TestClass]
public class Day2Tests
{
	private const string Input =
		"""
		ULL
		RRDDD
		LURDL
		UUUUD
		""";

	[DataTestMethod]
	[DataRow("1985", Input)]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow("5DB3", Input)]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part2());
	}
}
