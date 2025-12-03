namespace AdventOfCode.Year2025;

[TestClass]
public class Day3Tests
{
	private const string Input =
		"""
		987654321111111
		811111111111119
		234234234234278
		818181911112111
		""";

	[TestMethod]
	[DataRow(357, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(3121910778619, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input.ToLines()).Part2());
	}
}
