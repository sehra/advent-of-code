namespace AdventOfCode.Year2022;

[TestClass]
public class Day1Tests
{
	private const string Input =
		"""
		1000
		2000
		3000

		4000

		5000
		6000

		7000
		8000
		9000

		10000
		""";

	[DataTestMethod]
	[DataRow(24000, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part1());
	}

	[DataTestMethod]
	[DataRow(45000, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part2());
	}
}
