namespace AdventOfCode.Year2023;

[TestClass]
public class Day21Tests
{
	private const string Input =
		"""
		...........
		.....###.#.
		.###.##..#.
		..#.#...#..
		....#.#....
		.##..S####.
		.##..#...#.
		.......##..
		.##.#.####.
		.##..##.##.
		...........
		""";

	[DataTestMethod]
	[DataRow(16, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input.ToLines()).Part1(6));
	}

	[DataTestMethod]
	[DataRow(16, Input, 6)]
	[DataRow(50, Input, 10)]
	//[DataRow(1594, Input, 50)]
	//[DataRow(6536, Input, 100)]
	//[DataRow(167004, Input, 500)]
	//[DataRow(668697, Input, 1000)]
	//[DataRow(16733044, Input, 5000)]
	public void Part2(int expected, string input, int steps)
	{
		Assert.AreEqual(expected, new Day21(input.ToLines()).Part2(steps));
	}
}
