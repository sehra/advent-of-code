using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020
{
	[TestClass]
	public class Day17Tests
	{
		[DataTestMethod]
		[DataRow(112, ".#.\n..#\n###\n")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day17(input).Part1());
		}

		[DataTestMethod]
		[DataRow(848, ".#.\n..#\n###\n")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day17(input).Part2());
		}
	}
}
