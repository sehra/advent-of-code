namespace AdventOfCode.Year2025;

[TestClass]
public class Day9Tests
{
	private const string Input =
		"""
		7,1
		11,1
		11,7
		9,7
		9,5
		2,5
		2,3
		7,3
		""";

	[TestMethod]
	[DataRow(50, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(24, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input.ToLines()).Part2());
	}
}
