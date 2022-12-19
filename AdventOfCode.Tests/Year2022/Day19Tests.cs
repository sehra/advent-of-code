namespace AdventOfCode.Year2022;

[TestClass]
public class Day19Tests
{
	private const string Input =
		"""
		Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
		Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.
		""";

	[DataTestMethod]
	[DataRow(33, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(56 * 62, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input.ToLines()).Part2());
	}
}
