namespace AdventOfCode.Year2023;

[TestClass]
public class Day10Tests
{
	private const string Input1Easy =
		"""
		.....
		.S-7.
		.|.|.
		.L-J.
		.....
		""";
	private const string Input1Hard =
		"""
		-L|F7
		7S-7|
		L|7||
		-L-J|
		L|-JF
		""";
	private const string Input2Easy =
		"""
		..F7.
		.FJ|.
		SJ.L7
		|F--J
		LJ...
		""";
	private const string Input2Hard =
		"""
		7-F7-
		.FJ|7
		SJLL7
		|F--J
		LJ.LJ
		""";
	private const string Input3 =
		"""
		...........
		.S-------7.
		.|F-----7|.
		.||.....||.
		.||.....||.
		.|L-7.F-J|.
		.|..|.|..|.
		.L--J.L--J.
		...........
		""";
	private const string Input4 =
		"""
		.F----7F7F7F7F-7....
		.|F--7||||||||FJ....
		.||.FJ||||||||L7....
		FJL7L7LJLJ||LJ.L-7..
		L--J.L7...LJS7F-7L7.
		....F-J..F7FJ|L7L7L7
		....L7.F7||L7|.L7L7|
		.....|FJLJ|FJ|F7|.LJ
		....FJL-7.||.||||...
		....L---J.LJ.LJLJ...
		""";
	private const string Input5 =
		"""
		FF7FSF7F7F7F7F7F---7
		L|LJ||||||||||||F--J
		FL-7LJLJ||||||LJL-77
		F--JF--7||LJLJ7F7FJ-
		L---JF-JLJ.||-FJLJJ7
		|F|F-JF---7F7-L7L|7|
		|FFJF7L7F-JF7|JL---7
		7-L-JL7||F7|L7F-7F7|
		L.L7LFJ|||||FJL7||LJ
		L7JLJL-JLJLJL--JLJ.L
		""";

	[TestMethod]
	[DataRow(4, Input1Easy)]
	[DataRow(4, Input1Hard)]
	[DataRow(8, Input2Easy)]
	[DataRow(8, Input2Hard)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(4, Input3)]
	[DataRow(8, Input4)]
	[DataRow(10, Input5)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input.ToLines()).Part2());
	}
}
