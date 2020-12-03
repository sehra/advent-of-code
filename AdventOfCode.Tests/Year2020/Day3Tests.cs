using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020
{
	[TestClass]
	public class Day3Tests
	{
		[DataTestMethod]
		[DataRow(7,
			"..##.......\n" +
			"#...#...#..\n" +
			".#....#..#.\n" +
			"..#.#...#.#\n" +
			".#...##..#.\n" +
			"..#.##.....\n" +
			".#.#.#....#\n" +
			".#........#\n" +
			"#.##...#...\n" +
			"#...##....#\n" +
			".#..#...#.#\n")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day3(input).Part1());
		}

		[DataTestMethod]
		[DataRow(336,
			"..##.......\n" +
			"#...#...#..\n" +
			".#....#..#.\n" +
			"..#.#...#.#\n" +
			".#...##..#.\n" +
			"..#.##.....\n" +
			".#.#.#....#\n" +
			".#........#\n" +
			"#.##...#...\n" +
			"#...##....#\n" +
			".#..#...#.#\n")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day3(input).Part2());
		}
	}
}
