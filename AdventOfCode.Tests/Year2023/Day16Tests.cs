namespace AdventOfCode.Year2023;

[TestClass]
public class Day16Tests
{
	private const string Input =
		"""
		.|...\....
		|.-.\.....
		.....|-...
		........|.
		..........
		.........\
		..../.\\..
		.-.-/..|..
		.|....-|.\
		..//.|....
		""";

	[TestMethod]
	[DataRow(46, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(51, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input.ToLines()).Part2());
	}
}
