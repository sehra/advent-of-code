namespace AdventOfCode.Year2024;

[TestClass]
public class Day15Tests
{
	private const string Input1 =
		"""
		########
		#..O.O.#
		##@.O..#
		#...O..#
		#.#.O..#
		#...O..#
		#......#
		########

		<^^>>>vv<v>>v<<
		""";
	private const string Input2 =
		"""
		##########
		#..O..O.O#
		#......O.#
		#.OO..O.O#
		#..O@..O.#
		#O#..O...#
		#O..O..O.#
		#.OO.O.OO#
		#....O...#
		##########

		<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
		vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
		><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
		<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
		^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
		^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
		>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
		<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
		^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
		v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^
		""";

	[TestMethod]
	[DataRow(2028, Input1)]
	[DataRow(10092, Input2)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(9021, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part2());
	}
}
