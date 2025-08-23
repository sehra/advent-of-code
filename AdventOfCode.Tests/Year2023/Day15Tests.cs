namespace AdventOfCode.Year2023;

[TestClass]
public class Day15Tests
{
	private const string Input =
		"rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";

	[TestMethod]
	[DataRow(52, "HASH")]
	[DataRow(1320, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input).Part1());
	}

	[TestMethod]
	[DataRow(145, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input).Part2());
	}
}
