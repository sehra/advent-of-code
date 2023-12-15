namespace AdventOfCode.Year2023;

[TestClass]
public class Day15Tests
{
	[DataTestMethod]
	[DataRow(52, "HASH")]
	[DataRow(1320, "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input).Part1());
	}

	[DataTestMethod]
	[DataRow(145, "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input).Part2());
	}
}
