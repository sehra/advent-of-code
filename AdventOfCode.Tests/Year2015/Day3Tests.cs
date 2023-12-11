namespace AdventOfCode.Year2015;

[TestClass]
public class Day3Tests
{
	[DataTestMethod]
	[DataRow(2, ">")]
	[DataRow(4, "^>v<")]
	[DataRow(2, "^v^v^v^v^v")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input).Part1());
	}

	[DataTestMethod]
	[DataRow(3, "^v")]
	[DataRow(3, "^>v<")]
	[DataRow(11, "^v^v^v^v^v")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input).Part2());
	}
}
