namespace AdventOfCode.Year2023;

[TestClass]
public class Day7Tests
{
	private const string Input1 =
		"""
		32T3K 765
		T55J5 684
		KK677 28
		KTJJT 220
		QQQJA 483
		""";
	private const string Input2 =
		"""
		2345A 1
		Q2KJJ 13
		Q2Q2Q 19
		T3T3J 17
		T3Q33 11
		2345J 3
		J345A 2
		32T3K 5
		T55J5 29
		KK677 7
		KTJJT 34
		QQQJA 31
		JJJJJ 37
		JAAAA 43
		AAAAJ 59
		AAAAA 61
		2AAAA 23
		2JJJJ 53
		JJJJ2 41
		""";

	[DataTestMethod]
	[DataRow(6440, Input1)]
	[DataRow(6592, Input2)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(5905, Input1)]
	[DataRow(6839, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part2());
	}
}
