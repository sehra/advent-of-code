namespace AdventOfCode.Year2015;

[TestClass]
public class Day8Tests
{
	private const string Input =
		"""
		""
		"abc"
		"aaa\"aaa"
		"\x27"
		""";

	[TestMethod]
	[DataRow(12, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(19, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part2());
	}
}
