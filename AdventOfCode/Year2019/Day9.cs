using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
	public class Day9
	{
		private readonly string _input;

		public Day9(string input)
		{
			_input = input;
		}

		public async Task<BigInteger> Part1()
		{
			var results = new List<BigInteger>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = () => Task.FromResult((BigInteger)1),
				Output = value => { results.Add(value); return Task.CompletedTask; },
			};
			await intcode.RunAsync();

			return results[^1];
		}

		public async Task<BigInteger> Part2()
		{
			var results = new List<BigInteger>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = () => Task.FromResult((BigInteger)2),
				Output = value => { results.Add(value); return Task.CompletedTask; },
			};
			await intcode.RunAsync();

			return results[^1];
		}
	}
}
