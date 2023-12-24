namespace AdventOfCode.Year2023;

[TestClass]
public class Day24Tests
{
	private const string Input =
		"""
		19, 13, 30 @ -2,  1, -2
		18, 19, 22 @ -1, -1, -2
		20, 25, 34 @ -2, -2, -4
		12, 31, 28 @ -1, -2, -1
		20, 19, 15 @  1, -5, -3
		""";

	[DataTestMethod]
	[DataRow(2, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part1(7, 27));
	}

	[DataTestMethod]
	[DataRow(47, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part2());
	}
}
