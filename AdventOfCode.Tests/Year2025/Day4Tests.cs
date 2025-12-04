namespace AdventOfCode.Year2025;

[TestClass]
public class Day4Tests
{
	private const string Input =
		"""
		..@@.@@@@.
		@@@.@.@.@@
		@@@@@.@.@@
		@.@@@@..@.
		@@.@@@@.@@
		.@@@@@@@.@
		.@.@.@.@@@
		@.@@@.@@@@
		.@@@@@@@@.
		@.@.@@@.@.
		""";

	[TestMethod]
	[DataRow(13, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(43, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input.ToLines()).Part2());
	}
}
