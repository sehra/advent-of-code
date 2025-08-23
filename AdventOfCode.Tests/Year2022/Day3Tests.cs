namespace AdventOfCode.Year2022;

[TestClass]
public class Day3Tests
{
	private const string Input =
		"""
		vJrwpWtwJgWrhcsFMMfFFhFp
		jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
		PmmdzqPrVvPwwTWBwg
		wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
		ttgJtRGJQctTZtZT
		CrZsJsPPZsGzwwsLwLmpwMDw
		""";

	[TestMethod]
	[DataRow(157, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(70, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input.ToLines()).Part2());
	}
}
