namespace AdventOfCode.Year2024;

[TestClass]
public class Day12Tests
{
	private const string Input1 =
		"""
		AAAA
		BBCD
		BBCC
		EEEC
		""";
	private const string Input2 =
		"""
		OOOOO
		OXOXO
		OOOOO
		OXOXO
		OOOOO
		""";
	private const string Input3 =
		"""
		RRRRIICCFF
		RRRRIICCCF
		VVRRRCCFFF
		VVRCCCJFFF
		VVVVCJJCFE
		VVIVCCJJEE
		VVIIICJJEE
		MIIIIIJJEE
		MIIISIJEEE
		MMMISSJEEE
		""";

	[DataTestMethod]
	[DataRow(140, Input1)]
	[DataRow(772, Input2)]
	[DataRow(1930, Input3)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(80, Input1)]
	[DataRow(436, Input2)]
	[DataRow(1206, Input3)]
	[DataRow(236,
		"""
		EEEEE
		EXXXX
		EEEEE
		EXXXX
		EEEEE
		""")]
	[DataRow(368,
		"""
		AAAAAA
		AAABBA
		AAABBA
		ABBAAA
		ABBAAA
		AAAAAA
		""")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part2());
	}
}
