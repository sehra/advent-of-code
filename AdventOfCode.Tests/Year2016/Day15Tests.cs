namespace AdventOfCode.Year2016;

[TestClass]
public class Day15Tests
{
	public const string Input =
		"""
		Disc #1 has 5 positions; at time=0, it is at position 4.
		Disc #2 has 2 positions; at time=0, it is at position 1.
		""";

	[TestMethod]
	[DataRow(5, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part1());
	}
}
