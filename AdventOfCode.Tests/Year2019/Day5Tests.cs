using System.Numerics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019
{
	[TestClass]
	public class Day5Tests
	{
		[TestMethod]
		public async Task InputOutput()
		{
			BigInteger result = -1;
			var intcode = new IntcodeComputer(new BigInteger[] { 3, 0, 4, 0, 99 })
			{
				Input = () => Task.FromResult((BigInteger)42),
				Output = value => { result = value; return Task.CompletedTask; },
			};
			await intcode.RunAsync();

			Assert.AreEqual(42, result);
		}

		[TestMethod]
		public async Task AddressingMode()
		{
			var intcode = new IntcodeComputer(new BigInteger[] { 1002, 4, 3, 4, 33 });
			await intcode.RunAsync();

			Assert.AreEqual(99, intcode.Get(4));
		}

		[DataTestMethod]
		[DataRow("3,9,8,9,10,9,4,9,99,-1,8", 8, 1)]
		[DataRow("3,9,8,9,10,9,4,9,99,-1,8", 9, 0)]
		[DataRow("3,9,7,9,10,9,4,9,99,-1,8", 7, 1)]
		[DataRow("3,9,7,9,10,9,4,9,99,-1,8", 8, 0)]
		[DataRow("3,3,1108,-1,8,3,4,3,99", 8, 1)]
		[DataRow("3,3,1108,-1,8,3,4,3,99", 9, 0)]
		[DataRow("3,3,1107,-1,8,3,4,3,99", 7, 1)]
		[DataRow("3,3,1107,-1,8,3,4,3,99", 8, 0)]
		public async Task Comparisons(string memory, int input, int expected)
		{
			BigInteger result = -1;
			var intcode = new IntcodeComputer(memory)
			{
				Input = () => Task.FromResult((BigInteger)input),
				Output = value => { result = value; return Task.CompletedTask; },
			};
			await intcode.RunAsync();

			Assert.AreEqual(expected, result);
		}

		[DataTestMethod]
		[DataRow("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 0, 0)]
		[DataRow("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 42, 1)]
		[DataRow("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 0, 0)]
		[DataRow("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 42, 1)]
		public async Task ConditionalJumps(string memory, int input, int expected)
		{
			BigInteger result = -1;
			var intcode = new IntcodeComputer(memory)
			{
				Input = () => Task.FromResult((BigInteger)input),
				Output = value => { result = value; return Task.CompletedTask; },
			};
			await intcode.RunAsync();

			Assert.AreEqual(expected, result);
		}

		[DataTestMethod]
		[DataRow(7, 999)]
		[DataRow(8, 1000)]
		[DataRow(9, 1001)]
		public async Task LargeExample(int input, int expected)
		{
			var memory = new BigInteger[]
			{
				3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21,
				125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99,
			};

			BigInteger result = -1;
			var intcode = new IntcodeComputer(memory)
			{
				Input = () => Task.FromResult((BigInteger)input),
				Output = value => { result = value; return Task.CompletedTask; },
			};
			await intcode.RunAsync();

			Assert.AreEqual(expected, result);
		}
	}
}
