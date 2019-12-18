﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019
{
	[TestClass]
	public class Day18Tests
	{
		[DataTestMethod]
		[DataRow(
			"#########\n" +
			"#b.A.@.a#\n" +
			"#########", 8)]
		[DataRow(
			"########################\n" +
			"#f.D.E.e.C.b.A.@.a.B.c.#\n" +
			"######################.#\n" +
			"#d.....................#\n" +
			"########################", 86)]
		[DataRow(
			"########################\n" +
			"#...............b.C.D.f#\n" +
			"#.######################\n" +
			"#.....@.a.B.c.d.A.e.F.g#\n" +
			"########################", 132)]
		[DataRow(
			"#################\n" +
			"#i.G..c...e..H.p#\n" +
			"########.########\n" +
			"#j.A..b...f..D.o#\n" +
			"########@########\n" +
			"#k.E..a...g..B.n#\n" +
			"########.########\n" +
			"#l.F..d...h..C.m#\n" +
			"#################", 136)]
		[DataRow(
			"########################\n" +
			"#@..............ac.GI.b#\n" +
			"###d#e#f################\n" +
			"###A#B#C################\n" +
			"###g#h#i################\n" +
			"########################", 81)]
		public void Part1(string input, int expected)
		{
			Assert.AreEqual(expected, new Day18(input).Part1());
		}

		[DataTestMethod]
		[DataRow(
			"#######\n" +
			"#a.#Cd#\n" +
			"##...##\n" +
			"##.@.##\n" +
			"##...##\n" +
			"#cB#Ab#\n" +
			"#######", 8)]
		[DataRow(
			"###############\n" +
			"#d.ABC.#.....a#\n" +
			"######...######\n" +
			"######.@.######\n" +
			"######...######\n" +
			"#b.....#.....c#\n" +
			"###############", 24)]
		[DataRow(
			"#############\n" +
			"#DcBa.#.GhKl#\n" +
			"#.###...#I###\n" +
			"#e#d#.@.#j#k#\n" +
			"###C#...###J#\n" +
			"#fEbA.#.FgHi#\n" +
			"#############", 32)]
		[DataRow(
			"#############\n" +
			"#g#f.D#..h#l#\n" +
			"#F###e#E###.#\n" +
			"#dCba...BcIJ#\n" +
			"#####.@.#####\n" +
			"#nK.L...G...#\n" +
			"#M###N#H###.#\n" +
			"#o#m..#i#jk.#\n" +
			"#############", 72)]
		public void Part2(string input, int expected)
		{
			Assert.AreEqual(expected, new Day18(input).Part2());
		}
	}
}
