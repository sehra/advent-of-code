namespace AdventOfCode.Year2015;

[TestClass]
public class Day4Tests
{
	[DataTestMethod]
	[DataRow(609043, "abcdef")]
	[DataRow(1048970, "pqrstuv")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input).Part1());
	}
}
