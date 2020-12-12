using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020
{
	[TestClass]
	public class Day12Tests
	{
		[DataTestMethod]
		[DataRow(25, "F10\nN3\nF7\nR90\nF11\n")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day12(input).Part1());
		}

		[DataTestMethod]
		[DataRow(286, "F10\nN3\nF7\nR90\nF11\n")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day12(input).Part2());
		}
	}
}
