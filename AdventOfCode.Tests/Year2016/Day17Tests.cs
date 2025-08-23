namespace AdventOfCode.Year2016;

[TestClass]
public class Day17Tests
{
	[TestMethod]
	[DataRow("DDRRRD", "ihgpwlah")]
	[DataRow("DDUDRLRRUDRD", "kglvqrro")]
	[DataRow("DRURDRUDDLLDLUURRDULRLDUUDDDRR", "ulqzkmiv")]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input).Part1());
	}

	[TestMethod]
	[DataRow(370, "ihgpwlah")]
	[DataRow(492, "kglvqrro")]
	[DataRow(830, "ulqzkmiv")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input).Part2());
	}
}
