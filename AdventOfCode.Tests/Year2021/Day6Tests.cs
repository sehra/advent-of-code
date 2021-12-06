namespace AdventOfCode.Year2021;

[TestClass]
public class Day6Tests
{
	private const string Input = "3,4,3,1,2";

	[DataTestMethod]
	[DataRow(26, 18)]
	[DataRow(5934, 80)]
	public void Part1(long expected, int days)
	{
		Assert.AreEqual(expected, new Day6(Input).Part1(days));
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(26984457539, new Day6(Input).Part2());
	}
}
