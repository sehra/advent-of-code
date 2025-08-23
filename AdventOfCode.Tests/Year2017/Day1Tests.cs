namespace AdventOfCode.Year2017;

[TestClass]
public class Day1Tests
{
	[TestMethod]
	[DataRow(3, "1122")]
	[DataRow(4, "1111")]
	[DataRow(0, "1234")]
	[DataRow(9, "91212129")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part1());
	}

	[TestMethod]
	[DataRow(6, "1212")]
	[DataRow(0, "1221")]
	[DataRow(4, "123425")]
	[DataRow(12, "123123")]
	[DataRow(4, "12131415")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part2());
	}
}
