namespace AdventOfCode.Year2023;

[TestClass]
public class Day20Tests
{
	private const string Input1 =
		"""
		broadcaster -> a, b, c
		%a -> b
		%b -> c
		%c -> inv
		&inv -> a
		""";
	private const string Input2 =
		"""
		broadcaster -> a
		%a -> inv, con
		&inv -> b
		%b -> con
		&con -> output
		""";

	[TestMethod]
	[DataRow(32000000, Input1)]
	[DataRow(11687500, Input2)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part1());
	}
}
