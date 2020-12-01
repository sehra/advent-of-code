using System;
using System.Linq;

namespace AdventOfCode.Year2020
{
	public class Day1
	{
		private readonly int[] _input;

		public Day1(string input)
		{
			_input = input.ToLines().Select(Int32.Parse).ToArray();
		}

		public int Part1()
		{
			for (int i = 0; i < _input.Length; i++)
			{
				for (int j = i + 1; j < _input.Length; j++)
				{
					if (_input[i] + _input[j] == 2020)
					{
						return _input[i] * _input[j];
					}
				}
			}

			throw new Exception("not found");
		}

		public int Part2()
		{
			for (int i = 0; i < _input.Length; i++)
			{
				for (int j = i + 1; j < _input.Length; j++)
				{
					for (int k = j + 1; k < _input.Length; k++)
					{
						if (_input[i] + _input[j] + _input[k] == 2020)
						{
							return _input[i] * _input[j] * _input[k];
						}
					}
				}
			}

			throw new Exception("not found");
		}
	}
}
