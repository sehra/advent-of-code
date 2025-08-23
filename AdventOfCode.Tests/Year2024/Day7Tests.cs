namespace AdventOfCode.Year2024;

[TestClass]
public class Day7Tests
{
	private const string Input =
		"""
		190: 10 19
		3267: 81 40 27
		83: 17 5
		156: 15 6
		7290: 6 8 6 15
		161011: 16 10 13
		192: 17 8 14
		21037: 9 7 18 13
		292: 11 6 16 20
		""";

	[TestMethod]
	[DataRow(3749, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(11387, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part2());
	}
}
