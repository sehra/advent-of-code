namespace AdventOfCode.Year2017;

[TestClass]
public class Day10Tests
{
	[DataTestMethod]
	[DataRow(12, "3,4,1,5")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input).Part1(5));
	}

	[DataTestMethod]
	[DataRow("a2582a3a0e66e6e86e3812dcb672a272", "")]
	[DataRow("33efeb34ea91902bb2f59c9920caa6cd", "AoC 2017")]
	[DataRow("3efbe78a8d82f29979031a4aa0b16a9d", "1,2,3")]
	[DataRow("63960835bcdc130f0b66d7ff4f6a5a8e", "1,2,4")]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input).Part2());
	}
}
