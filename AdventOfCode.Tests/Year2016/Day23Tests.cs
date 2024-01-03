namespace AdventOfCode.Year2016;

[TestClass]
public class Day23Tests
{
	private const string Input =
		"""
		cpy 2 a
		tgl a
		tgl a
		tgl a
		cpy 1 a
		dec a
		dec a
		""";

	[DataTestMethod]
	[DataRow(3, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part1(0));
	}
}
