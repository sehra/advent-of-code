namespace AdventOfCode.Year2023;

[TestClass]
public class Day7Tests
{
	private const string Input =
		"""
		32T3K 765
		T55J5 684
		KK677 28
		KTJJT 220
		QQQJA 483
		""";

	[DataTestMethod]
	[DataRow(6440, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(5905, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part2());
	}
}
