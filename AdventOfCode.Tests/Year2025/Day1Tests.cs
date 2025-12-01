namespace AdventOfCode.Year2025;

[TestClass]
public class Day1Tests
{
	private const string Input =
		"""
		L68
		L30
		R48
		L5
		R60
		L55
		L1
		L99
		R14
		L82
		""";

	[TestMethod]
	[DataRow(3, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(6, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input.ToLines()).Part2());
	}
}
