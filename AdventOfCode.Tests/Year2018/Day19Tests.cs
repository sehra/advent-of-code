namespace AdventOfCode.Year2018;

[TestClass]
public class Day19Tests
{
	private const string Input =
		"""
		#ip 0
		seti 5 0 1
		seti 6 0 2
		addi 0 1 0
		addr 1 2 3
		setr 1 0 0
		seti 8 0 4
		seti 9 0 5
		""";

	[DataTestMethod]
	[DataRow(6, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input.ToLines()).Part1());
	}
}
