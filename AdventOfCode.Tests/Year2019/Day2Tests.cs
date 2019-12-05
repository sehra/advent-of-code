using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019
{
	[TestClass]
	public class Day2Tests
	{
		[DataTestMethod]
		[DataRow("1,9,10,3,2,3,11,0,99,30,40,50", 0, 3500)]
		[DataRow("1,0,0,0,99", 0, 2)]
		[DataRow("2,3,0,3,99", 3, 6)]
		[DataRow("2,4,4,5,99,0", 5, 9801)]
		[DataRow("1,1,1,4,99,5,6,0,99", 0, 30)]
		public void Computer(string memory, int address, int expected)
		{
			var intcode = new IntcodeComputer(memory);
			intcode.Run();

			Assert.AreEqual(expected, intcode.Get(address));
		}
	}
}
