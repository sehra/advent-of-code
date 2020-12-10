using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020
{
	public class Day10
	{
		private readonly int[] _input;

		public Day10(string input)
		{
			_input = input.ToLines().Select(Int32.Parse).OrderBy(x => x).ToArray();
		}

		public int Part1()
		{
			var joltage = 0;
			var diffs1 = 0;
			var diffs3 = 0;

			for (int i = 0; i < _input.Length; i++)
			{
				var diff = _input[i] - joltage;

				if (diff == 1)
				{
					diffs1++;
				}
				else if (diff == 3)
				{
					diffs3++;
				}

				joltage = _input[i];
			}

			return diffs1 * (diffs3 + 1);
		}

		public long Part2()
		{
			var joltages = new int[_input.Length + 1];
			_input.CopyTo(joltages, 1);

			var routes = new Dictionary<int, long> { [joltages.Max() + 3] = 1 };

			foreach (var joltage in joltages.Reverse())
			{
				routes.TryGetValue(joltage + 1, out var count1);
				routes.TryGetValue(joltage + 2, out var count2);
				routes.TryGetValue(joltage + 3, out var count3);
				routes.Add(joltage, count1 + count2 + count3);
			}

			return routes[0];
		}
	}
}
