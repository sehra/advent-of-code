namespace AdventOfCode.Year2023;

[TestClass]
public class Day3Tests
{
	private const string Input =
		"""
		467..114..
		...*......
		..35..633.
		......#...
		617*......
		.....+.58.
		..592.....
		......755.
		...$.*....
		.664.598..
		""";

	[DataTestMethod]
	[DataRow(4361, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(467835, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input.ToLines()).Part2());
	}
}
