namespace AdventOfCode.Year2020;

[TestClass]
public class Day13Tests
{
	[DataTestMethod]
	[DataRow(295, "939\n7,13,x,x,59,x,31,19\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input).Part1());
	}

	[DataTestMethod]
	[DataRow(1068781, "7,13,x,x,59,x,31,19")]
	[DataRow(3417, "17,x,13,19")]
	[DataRow(754018, "67,7,59,61")]
	[DataRow(779210, "67,x,7,59,61")]
	[DataRow(1261476, "67,7,x,59,61")]
	[DataRow(1202161486, "1789,37,47,1889")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day13($"0\n{input}\n").Part2());
	}
}
