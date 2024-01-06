namespace AdventOfCode.Year2018;

[TestClass]
public class Day12Tests
{
	private const string Input =
		"""
		initial state: #..#.#..##......###...###

		##### => .
		####. => #
		###.# => #
		###.. => #
		##.## => #
		##.#. => #
		##..# => .
		##... => .
		#.### => #
		#.##. => .
		#.#.# => #
		#.#.. => .
		#..## => .
		#..#. => .
		#...# => .
		#.... => .
		.#### => #
		.###. => .
		.##.# => .
		.##.. => #
		.#.## => #
		.#.#. => #
		.#..# => .
		.#... => #
		..### => .
		..##. => .
		..#.# => .
		..#.. => #
		...## => #
		...#. => .
		....# => .
		..... => .
		""";

	[DataTestMethod]
	[DataRow(325, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part1());
	}
}
