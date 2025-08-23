namespace AdventOfCode.Year2023;

[TestClass]
public class Day17Tests
{
	private const string Input1 =
		"""
		2413432311323
		3215453535623
		3255245654254
		3446585845452
		4546657867536
		1438598798454
		4457876987766
		3637877979653
		4654967986887
		4564679986453
		1224686865563
		2546548887735
		4322674655533
		""";
	private const string Input2 =
		"""
		111111111111
		999999999991
		999999999991
		999999999991
		999999999991
		""";

	[TestMethod]
	[DataRow(102, Input1)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(94, Input1)]
	[DataRow(71, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input.ToLines()).Part2());
	}
}
