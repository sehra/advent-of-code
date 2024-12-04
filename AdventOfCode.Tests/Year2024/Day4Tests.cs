namespace AdventOfCode.Year2024;

[TestClass]
public class Day4Tests
{
	private const string Input =
		"""
		MMMSXXMASM
		MSAMXMSMSA
		AMXSXMAAMM
		MSAMASMSMX
		XMASAMXAMM
		XXAMMXXAMA
		SMSMSASXSS
		SAXAMASAAA
		MAMMMXMMMM
		MXMXAXMASX
		""";

	[DataTestMethod]
	[DataRow(18, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(9, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input.ToLines()).Part2());
	}
}
