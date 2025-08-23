namespace AdventOfCode.Year2018;

[TestClass]
public class Day3Tests
{
	private const string Input =
		"""
		#1 @ 1,3: 4x4
		#2 @ 3,1: 4x4
		#3 @ 5,5: 2x2
		""";

	[TestMethod]
	[DataRow(4, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(3, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input.ToLines()).Part2());
	}
}
