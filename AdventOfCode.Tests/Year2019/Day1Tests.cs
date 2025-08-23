namespace AdventOfCode.Year2019;

[TestClass]
public class Day1Tests
{
	[TestMethod]
	[DataRow("12", 2)]
	[DataRow("14", 2)]
	[DataRow("1969", 654)]
	[DataRow("100756", 33583)]
	public void Part1(string input, int expected)
	{
		Assert.AreEqual(expected, new Day1(input).Part1());
	}

	[TestMethod]
	[DataRow("14", 2)]
	[DataRow("1969", 966)]
	[DataRow("100756", 50346)]
	public void Part2(string input, int expected)
	{
		Assert.AreEqual(expected, new Day1(input).Part2());
	}
}
