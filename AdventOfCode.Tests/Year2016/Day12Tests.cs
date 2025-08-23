namespace AdventOfCode.Year2016;

[TestClass]
public class Day12Tests
{
	private const string Input =
		"""
		cpy 41 a
		inc a
		inc a
		dec a
		jnz a 2
		dec a
		""";

	[TestMethod]
	[DataRow(42, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part1());
	}
}
