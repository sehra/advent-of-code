namespace AdventOfCode.Year2017;

[TestClass]
public class Day16Tests
{
	[DataTestMethod]
	[DataRow("baedc", "s1,x3/4,pe/b")]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input).Part1(5));
	}

	[DataTestMethod]
	[DataRow("baedc", "s1,x3/4,pe/b")]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input).Part2(5));
	}
}
