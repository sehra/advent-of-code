using System.Text;

namespace AdventOfCode.Year2021;

[TestClass]
public class Day13Tests
{
	private const string Input =
		"6,10\n" +
		"0,14\n" +
		"9,10\n" +
		"0,3\n" +
		"10,4\n" +
		"4,11\n" +
		"6,0\n" +
		"6,12\n" +
		"4,1\n" +
		"0,13\n" +
		"10,12\n" +
		"3,4\n" +
		"3,0\n" +
		"8,4\n" +
		"1,10\n" +
		"2,14\n" +
		"8,10\n" +
		"9,0\n" +
		"\n" +
		"fold along y=7\n" +
		"fold along x=5\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(17, new Day13(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		var expected = new StringBuilder()
			.AppendLine("#####")
			.AppendLine("#...#")
			.AppendLine("#...#")
			.AppendLine("#...#")
			.AppendLine("#####")
			.ToString();

		Assert.AreEqual(expected, new Day13(Input.ToLines()).Part2());
	}
}
