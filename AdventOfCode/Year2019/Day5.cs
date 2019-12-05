using System.Collections.Generic;

namespace AdventOfCode.Year2019
{
	public class Day5
	{
		private readonly string _input;

		public Day5(string input)
		{
			_input = input;
		}

		public int Part1()
		{
			var outputs = new List<int>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = () => 1,
				Output = value => outputs.Add(value),
			};
			intcode.Run();

			return outputs[^1];
		}

		public int Part2()
		{
			var outputs = new List<int>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = () => 5,
				Output = value => outputs.Add(value),
			};
			intcode.Run();

			return outputs[^1];
		}
	}
}
