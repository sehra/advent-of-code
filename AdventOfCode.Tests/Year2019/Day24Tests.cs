using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019
{
	[TestClass]
	public class Day24Tests
	{
		private const string Example1 =
			"....#\n" +
			"#..#.\n" +
			"#..##\n" +
			"..#..\n" +
			"#....";

		[TestMethod]
		public void Part1()
		{
			Assert.AreEqual(2129920, new Day24(Example1).Part1());
		}

		[TestMethod]
		public void Part2()
		{
			Assert.AreEqual(99, new Day24(Example1).Part2(10));
		}
	}
}
