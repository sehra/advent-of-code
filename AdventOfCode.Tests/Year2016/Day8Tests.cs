namespace AdventOfCode.Year2016;

[TestClass]
public class Day8Tests
{
	private const string Input =
		"""
		rect 3x2
		rotate column x=1 by 1
		rotate row y=0 by 4
		rotate column x=1 by 1
		""";

	[TestMethod]
	[DataRow(6, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part1(7, 3));
	}
}
