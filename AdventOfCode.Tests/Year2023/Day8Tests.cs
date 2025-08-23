namespace AdventOfCode.Year2023;

[TestClass]
public class Day8Tests
{
	private const string Input1 =
		"""
		RL

		AAA = (BBB, CCC)
		BBB = (DDD, EEE)
		CCC = (ZZZ, GGG)
		DDD = (DDD, DDD)
		EEE = (EEE, EEE)
		GGG = (GGG, GGG)
		ZZZ = (ZZZ, ZZZ)
		""";
	private const string Input2 =
		"""
		LLR

		AAA = (BBB, BBB)
		BBB = (AAA, ZZZ)
		ZZZ = (ZZZ, ZZZ)
		""";
	private const string Input3 =
		"""
		LR

		11A = (11B, XXX)
		11B = (XXX, 11Z)
		11Z = (11B, XXX)
		22A = (22B, XXX)
		22B = (22C, 22C)
		22C = (22Z, 22Z)
		22Z = (22B, 22B)
		XXX = (XXX, XXX)
		""";

	[TestMethod]
	[DataRow(2, Input1)]
	[DataRow(6, Input2)]
	public void Part1(long expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(6, Input3)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part2());
	}
}
