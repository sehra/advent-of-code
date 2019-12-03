using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class Day3
	{
		private readonly string[][] _input;

		public Day3(string input)
		{
			_input = input.Split('\n').Select(line => line.Split(',')).ToArray();
		}

		public int Part1()
		{
			return GetPoints()
				.Where(x => x.Value.Wires == 3)
				.Min(x => Math.Abs(x.Key.X) + Math.Abs(x.Key.Y));
		}

		public int Part2()
		{
			return GetPoints()
				.Where(x => x.Value.Wires == 3)
				.Min(x => x.Value.Steps.Sum() ?? throw new Exception("not found"));
		}

		private IDictionary<(int X, int Y), PointState> GetPoints()
		{
			var points = new Dictionary<(int X, int Y), PointState>();

			foreach (var wire in _input.Select((x, i) => new { Index = i, Segments = x }))
			{
				var position = (X: 0, Y: 0);
				var steps = 1;

				foreach (var segment in wire.Segments)
				{
					var distance = Int32.Parse(segment.AsSpan(1));

					for (int i = 0; i < distance; i++, steps++)
					{
						position = segment[0] switch
						{
							'U' => (position.X, position.Y + 1),
							'D' => (position.X, position.Y - 1),
							'R' => (position.X + 1, position.Y),
							'L' => (position.X - 1, position.Y),
							_ => throw new NotSupportedException(),
						};

						if (!points.ContainsKey(position))
						{
							points[position] = new PointState(_input.Length);
						}

						var state = points[position];
						state.Wires |= 1 << wire.Index;
						state.Steps[wire.Index] ??= steps;
					}
				}
			}

			return points;
		}

		private class PointState
		{
			public PointState(int length)
			{
				Steps = new int?[length];
			}

			public int Wires { get; set; }
			public int?[] Steps { get; set; }
		}
	}
}
