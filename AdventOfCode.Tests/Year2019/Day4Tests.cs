namespace AdventOfCode.Year2019;

[TestClass]
public class Day4Tests
{
	[DataTestMethod]
	[DataRow("111111", true)]
	[DataRow("223450", false)]
	[DataRow("123789", false)]
	public void Part1(string value, bool expected)
	{
		Assert.AreEqual(expected, Day4.IsValid1(value));
	}

	[DataTestMethod]
	[DataRow("112233", true)]
	[DataRow("123444", false)]
	[DataRow("111122", true)]
	public void Part2(string value, bool expected)
	{
		Assert.AreEqual(expected, Day4.IsValid2(value));
	}
}
