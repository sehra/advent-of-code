﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019
{
	[TestClass]
	public class Day10Tests
	{
		private const string Input1 =
			".#..#\n" +
			".....\n" +
			"#####\n" +
			"....#\n" +
			"...##";
		private const string Input2 =
			"......#.#.\n" +
			"#..#.#....\n" +
			"..#######.\n" +
			".#.#.###..\n" +
			".#..#.....\n" +
			"..#....#.#\n" +
			"#..#....#.\n" +
			".##.#..###\n" +
			"##...#..#.\n" +
			".#....####\n";
		private const string Input3 =
			"#.#...#.#.\n" +
			".###....#.\n" +
			".#....#...\n" +
			"##.#.#.#.#\n" +
			"....#.#.#.\n" +
			".##..###.#\n" +
			"..#...##..\n" +
			"..##....##\n" +
			"......#...\n" +
			".####.###.";
		private const string Input4 =
			".#..#..###\n" +
			"####.###.#\n" +
			"....###.#.\n" +
			"..###.##.#\n" +
			"##.##.#.#.\n" +
			"....###..#\n" +
			"..#.#..#.#\n" +
			"#..#.#.###\n" +
			".##...##.#\n" +
			".....#.#..";
		private const string Input5 =
			".#..##.###...#######\n" +
			"##.############..##.\n" +
			".#.######.########.#\n" +
			".###.#######.####.#.\n" +
			"#####.##.#.##.###.##\n" +
			"..#####..#.#########\n" +
			"####################\n" +
			"#.####....###.#.#.##\n" +
			"##.#################\n" +
			"#####.##.###..####..\n" +
			"..######..##.#######\n" +
			"####.##.####...##..#\n" +
			".#####..#.######.###\n" +
			"##...#.##########...\n" +
			"#.##########.#######\n" +
			".####.#.###.###.#.##\n" +
			"....##.##.###..#####\n" +
			".#.#.###########.###\n" +
			"#.#.#.#####.####.###\n" +
			"###.##.####.##.#..##";

		[DataTestMethod]
		[DataRow(Input1, 3, 4, 8)]
		[DataRow(Input2, 5, 8, 33)]
		[DataRow(Input3, 1, 2, 35)]
		[DataRow(Input4, 6, 3, 41)]
		[DataRow(Input5, 11, 13, 210)]
		public void Part1(string input, int x, int y, int count)
		{
			Assert.AreEqual(((x, y), count), new Day10(input).Part1());
		}

		[TestMethod]
		public void Part2()
		{
			Assert.AreEqual(802, new Day10(Input5).Part2());
		}
	}
}
