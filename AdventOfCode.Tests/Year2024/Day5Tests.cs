namespace AdventOfCode.Year2024;

[TestClass]
public class Day5Tests
{
	private const string Input =
		"""
		47|53
		97|13
		97|61
		97|47
		75|29
		61|13
		75|53
		29|13
		97|29
		53|29
		61|53
		97|53
		61|29
		47|13
		75|47
		97|75
		47|61
		75|61
		47|29
		75|13
		53|13

		75,47,61,53,29
		97,61,53,29,13
		75,29,13
		75,97,47,61,53
		61,13,29
		97,13,75,29,47
		""";

	[TestMethod]
	[DataRow(143, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(123, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input.ToLines()).Part2());
	}
}
