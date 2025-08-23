namespace AdventOfCode.Year2022;

[TestClass]
public class Day18Tests
{
	private const string Input =
		"""
		2,2,2
		1,2,2
		3,2,2
		2,1,2
		2,3,2
		2,2,1
		2,2,3
		2,2,4
		2,2,6
		1,2,5
		3,2,5
		2,1,5
		2,3,5
		""";

	[TestMethod]
	[DataRow(64, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day18(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(58, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day18(input.ToLines()).Part2());
	}
}
