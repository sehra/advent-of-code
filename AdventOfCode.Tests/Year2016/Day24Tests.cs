namespace AdventOfCode.Year2016;

[TestClass]
public class Day24Tests
{
	private const string Input =
		"""
		###########
		#0.1.....2#
		#.#######.#
		#4.......3#
		###########
		""";

	[DataTestMethod]
	[DataRow(14, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part1());
	}
}
