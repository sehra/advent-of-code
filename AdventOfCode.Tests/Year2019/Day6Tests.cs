using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019
{
	[TestClass]
	public class Day6Tests
	{
		[TestMethod]
		public void Part1()
		{
			const string input = "COM)B\nB)C\nC)D\nD)E\nE)F\nB)G\nG)H\nD)I\nE)J\nJ)K\nK)L";
			var orbits = new Day6(input).GetOrbits();

			Assert.AreEqual(42, orbits.Sum(x => Day6.CountOrbits(orbits, x.Key)));
		}

		[TestMethod]
		public void Part2()
		{
			const string input = "COM)B\nB)C\nC)D\nD)E\nE)F\nB)G\nG)H\nD)I\nE)J\nJ)K\nK)L\nK)YOU\nI)SAN";
			var orbits = new Day6(input).GetOrbits();

			Assert.AreEqual(4, Day6.CountTransfers(orbits, "YOU", "SAN"));
		}
	}
}
