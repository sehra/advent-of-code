namespace AdventOfCode.Year2018;

[TestClass]
public class Day15Tests
{
	[TestMethod]
	//[DataRow(0,
	//	"""
	//	#########
	//	#G..G..G#
	//	#.......#
	//	#.......#
	//	#G..E..G#
	//	#.......#
	//	#.......#
	//	#G..G..G#
	//	#########
	//	""")]
	[DataRow(27730,
		"""
		#######
		#.G...#
		#...EG#
		#.#.#G#
		#..G#E#
		#.....#
		#######
		""")]
	[DataRow(36334,
		"""
		#######
		#G..#E#
		#E#E.E#
		#G.##.#
		#...#E#
		#...E.#
		#######
		""")]
	[DataRow(39514,
		"""
		#######
		#E..EG#
		#.#G.E#
		#E.##E#
		#G..#.#
		#..E#.#
		#######
		""")]
	[DataRow(27755,
		"""
		#######
		#E.G#.#
		#.#G..#
		#G.#.G#
		#G..#.#
		#...E.#
		#######
		""")]
	[DataRow(28944,
		"""
		#######
		#.E...#
		#.#..G#
		#.###.#
		#E#G#G#
		#...#G#
		#######
		""")]
	[DataRow(18740,
		"""
		#########
		#G......#
		#.E.#...#
		#..##..G#
		#...##..#
		#...#...#
		#.G...G.#
		#.....G.#
		#########
		""")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(4988,
		"""
		#######
		#.G...#
		#...EG#
		#.#.#G#
		#..G#E#
		#.....#
		#######
		""")]
	[DataRow(31284,
		"""
		#######
		#E..EG#
		#.#G.E#
		#E.##E#
		#G..#.#
		#..E#.#
		#######
		""")]
	[DataRow(3478,
		"""
		#######
		#E.G#.#
		#.#G..#
		#G.#.G#
		#G..#.#
		#...E.#
		#######
		""")]
	[DataRow(6474,
		"""
		#######
		#.E...#
		#.#..G#
		#.###.#
		#E#G#G#
		#...#G#
		#######
		""")]
	[DataRow(1140,
		"""
		#########
		#G......#
		#.E.#...#
		#..##..G#
		#...##..#
		#...#...#
		#.G...G.#
		#.....G.#
		#########
		""")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part2());
	}
}
