using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
	public class Day21
	{
		private readonly string _input;

		public Day21(string input)
		{
			_input = input;
		}

		public Task<BigInteger> Part1()
		{
			var script = new[]
			{
				"OR A J",
				"AND B J",
				"AND C J",
				"NOT J J",
				"AND D J",
				"WALK",
			};

			return RunScriptAsync(script);
		}

		public Task<BigInteger> Part2()
		{
			var script = new[]
			{
				"OR A J",
				"AND B J",
				"AND C J",
				"NOT J J",
				"AND D J",
				"OR E T",
				"OR H T",
				"AND T J",
				"RUN",
			};

			return RunScriptAsync(script);
		}

		private async Task<BigInteger> RunScriptAsync(string[] lines, bool debug = false)
		{
			var input = new Queue<BigInteger>();
			var output = new List<BigInteger>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = () => Task.FromResult(input.Dequeue()),
				Output = value => { output.Add(value); return Task.CompletedTask; },
			};

			foreach (var line in lines)
			{
				foreach (var c in Encoding.ASCII.GetBytes(line))
				{
					input.Enqueue(c);
				}

				input.Enqueue((byte)'\n');
			}

			await intcode.RunAsync();

			if (debug)
			{
				foreach (var c in output)
				{
					Console.Write((char)c);
				}
			}

			return output[^1];
		}
	}
}
