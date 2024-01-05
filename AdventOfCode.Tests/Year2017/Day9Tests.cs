namespace AdventOfCode.Year2017;

[TestClass]
public class Day9Tests
{
	[DataTestMethod]
	[DataRow(1, "{}")]
	[DataRow(6, "{{{}}}")]
	[DataRow(5, "{{},{}}")]
	[DataRow(16, "{{{},{},{{}}}}")]
	[DataRow(1, "{<a>,<a>,<a>,<a>}")]
	[DataRow(9, "{{<ab>},{<ab>},{<ab>},{<ab>}}")]
	[DataRow(9, "{{<!!>},{<!!>},{<!!>},{<!!>}}")]
	[DataRow(3, "{{<a!>},{<a!>},{<a!>},{<ab>}}")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part1());
	}

	[DataTestMethod]
	[DataRow(0, "<>")]
	[DataRow(17, "<random characters>")]
	[DataRow(3, "<<<<>")]
	[DataRow(2, "<{!>}>")]
	[DataRow(0, "<!!>")]
	[DataRow(0, "<!!!>>")]
	[DataRow(10, "<{o\"i!a,<{i<a>")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part2());
	}
}
