using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
	public class Day11
	{
		private readonly string _input;

		public Day11(string input)
		{
			_input = input;
		}

		public async Task<int> Part1()
		{
			return (await RunRobotAsync(0)).Count;
		}

		public async Task<string> Part2()
		{
			var panels = await RunRobotAsync(1);
			var xmin = panels.Keys.Min(coord => coord.x);
			var ymin = panels.Keys.Min(coord => coord.y);

			return panels
				.Where(panel => panel.Value == 1)
				.Select(panel => (x: xmin + panel.Key.x, y: ymin + panel.Key.y))
				.GroupBy(coord => coord.y)
				.OrderByDescending(group => group.Key)
				.Aggregate(
					new StringBuilder(),
					(sb, panels) =>
					{
						var line = new char[panels.Max(coord => coord.x) + 1];
						Array.Fill(line, ' ');

						foreach (var (x, _) in panels)
						{
							line[x] = '*';
						}

						return sb.Append(line).AppendLine();
					},
					sb => sb.ToString()
				);
		}

		public async Task<Dictionary<(int x, int y), int>> RunRobotAsync(int? input)
		{
			var panels = new Dictionary<(int, int), int>();
			var position = (x: 0, y: 0);
			var direction = 1;
			var outputs = Channel.CreateUnbounded<BigInteger>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = async () =>
				{
					if (input.HasValue)
					{
						var value = input.GetValueOrDefault();
						input = null;

						return value;
					}

					var color = await outputs.Reader.ReadAsync();
					panels[position] = (int)color;
					direction = (int)await outputs.Reader.ReadAsync() switch
					{
						0 => (direction + 1) % 4,
						1 => (direction + 3) % 4,
						_ => throw new Exception(),
					};
					position = direction switch
					{
						0 => (position.x + 1, position.y),
						1 => (position.x, position.y + 1),
						2 => (position.x - 1, position.y),
						3 => (position.x, position.y - 1),
						_ => throw new Exception(),
					};

					return panels.TryGetValue(position, out var current) ? current : 0;
				},
				Output = value => outputs.Writer.WriteAsync(value).AsTask(),
			};
			await intcode.RunAsync();

			return panels;
		}
	}
}
