namespace AdventOfCode.Year2023;

[TestClass]
public class Day2Tests
{
	public const string Input =
		"""
		Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
		Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
		Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
		Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
		Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
		""";

	[TestMethod]
	[DataRow(8, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(2286, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part2());
	}
}
