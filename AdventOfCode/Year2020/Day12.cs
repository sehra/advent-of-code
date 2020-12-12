using System;

namespace AdventOfCode.Year2020
{
	public class Day12
	{
		private readonly string[] _input;

		public Day12(string input)
		{
			_input = input.ToLines();
		}

		public int Part1()
		{
			var pos = (x: 0, y: 0);
			var dir = 90;

			foreach (var line in _input)
			{
				var cmd = line[0];
				var val = line.AsSpan(1).ToInt32();

				(pos, dir) = cmd switch
				{
					'N' => ((pos.x, pos.y + val), dir),
					'S' => ((pos.x, pos.y - val), dir),
					'E' => ((pos.x + val, pos.y), dir),
					'W' => ((pos.x - val, pos.y), dir),
					'L' => (pos, dir - val),
					'R' => (pos, dir + val),
					'F' => ((dir % 360) switch
					{
						0 => (pos.x, pos.y + val),
						90 or -270 => (pos.x + val, pos.y),
						180 or -180 => (pos.x, pos.y - val),
						270 or -90 => (pos.x - val, pos.y),
						_ => throw new Exception("dir?"),
					}, dir),
					_ => throw new Exception("cmd?"),
				};
			}

			return Math.Abs(pos.x) + Math.Abs(pos.y);
		}

		public int Part2()
		{
			var pos = (x: 0, y: 0);
			var way = (x: 10, y: 1);

			foreach (var line in _input)
			{
				var cmd = line[0];
				var val = line.AsSpan(1).ToInt32();

				(pos, way) = (cmd, val) switch
				{
					('N', _) => (pos, (way.x, way.y + val)),
					('S', _) => (pos, (way.x, way.y - val)),
					('E', _) => (pos, (way.x + val, way.y)),
					('W', _) => (pos, (way.x - val, way.y)),
					('L', 90) or ('R', 270) => (pos, (-way.y, way.x)),
					('R', 90) or ('L', 270) => (pos, (way.y, -way.x)),
					('L' or 'R', 180) => (pos, (-way.x, -way.y)),
					('F', _) => ((pos.x + val * way.x, pos.y + val * way.y), way),
					_ => throw new Exception("cmd?"),
				};
			}

			return Math.Abs(pos.x) + Math.Abs(pos.y);
		}
	}
}
