namespace AdventOfCode.Year2018;

[TestClass]
public class Day9Tests
{
	[DataTestMethod]
	[DataRow(32, "9 players; last marble is worth 25 points")]
	[DataRow(8317, "10 players; last marble is worth 1618 points")]
	[DataRow(146373, "13 players; last marble is worth 7999 points")]
	[DataRow(2764, "17 players; last marble is worth 1104 points")]
	[DataRow(54718, "21 players; last marble is worth 6111 points")]
	[DataRow(37305, "30 players; last marble is worth 5807 points")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part1());
	}
}
