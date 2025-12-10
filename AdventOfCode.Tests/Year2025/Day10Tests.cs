namespace AdventOfCode.Year2025;

[TestClass]
public class Day10Tests
{
	private const string Input =
		"""
		[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
		[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
		[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
		""";

	[TestMethod]
	[DataRow(2 + 3 + 2, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(10 + 12 + 11, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input.ToLines()).Part2());
	}
}
