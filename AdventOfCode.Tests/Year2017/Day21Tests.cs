namespace AdventOfCode.Year2017;

[TestClass]
public class Day21Tests
{
	private const string Input =
		"""
		../.# => ##./#../...
		.#./..#/### => #..#/..../..../#..#
		""";

	[TestMethod]
	[DataRow(12, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input.ToLines()).Part1(2));
	}
}
