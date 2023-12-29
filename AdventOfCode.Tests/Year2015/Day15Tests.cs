namespace AdventOfCode.Year2015;

[TestClass]
public class Day15Tests
{
	private const string Input =
		"""
		Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
		Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
		""";

	[DataTestMethod]
	[DataRow(62842880, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(57600000, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part2());
	}
}
