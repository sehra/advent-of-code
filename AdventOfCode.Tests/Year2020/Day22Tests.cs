using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020
{
	[TestClass]
	public class Day22Tests
	{
		[DataTestMethod]
		[DataRow(306,
			"Player 1:\n" +
			"9\n" +
			"2\n" +
			"6\n" +
			"3\n" +
			"1\n" +
			"\n" +
			"Player 2:\n" +
			"5\n" +
			"8\n" +
			"4\n" +
			"7\n" +
			"10\n")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day22(input).Part1());
		}

		[DataTestMethod]
		[DataRow(291,
			"Player 1:\n" +
			"9\n" +
			"2\n" +
			"6\n" +
			"3\n" +
			"1\n" +
			"\n" +
			"Player 2:\n" +
			"5\n" +
			"8\n" +
			"4\n" +
			"7\n" +
			"10\n")]
		[DataRow(0,
			"Player 1:\n" +
			"43\n" +
			"19\n" +
			"\n" +
			"Player 2:\n" +
			"2\n" +
			"29\n" +
			"14\n")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day22(input).Part2());
		}
	}
}
