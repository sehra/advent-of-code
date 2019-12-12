using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2019
{
	public class Day12
	{
		private readonly (int x, int y, int z)[] _input;

		public Day12(string input)
		{
			_input = input
				.Split('\n')
				.Select(line => Regex.Match(line.Trim(), @"^<x=(?<x>-?\d+), y=(?<y>-?\d+), z=(?<z>-?\d+)>$"))
				.Where(match => match.Success)
				.Select(match =>
				(
					Int32.Parse(match.Groups["x"].Value),
					Int32.Parse(match.Groups["y"].Value),
					Int32.Parse(match.Groups["z"].Value)
				))
				.ToArray();
		}

		public int Part1() => RunPart1(1000);

		public int RunPart1(int steps)
		{
			var position = _input.ToArray();
			var velocity = new (int x, int y, int z)[_input.Length];

			for (int i = 0; i < steps; i++)
			{
				Step(position, velocity);
			}

			return position.Zip(velocity).Sum(pair => Energy(pair.First) * Energy(pair.Second));
		}

		public long Part2()
		{
			var position = _input.ToArray();
			var velocity = new (int x, int y, int z)[_input.Length];
			var steps = 0;

			long? xperiod = null;
			long? yperiod = null;
			long? zperiod = null;

			do
			{
				Step(position, velocity);
				steps++;

				if (!xperiod.HasValue && velocity.All(v => v.x == 0) &&
					position.Select(v => v.x).SequenceEqual(_input.Select(v => v.x)))
				{
					xperiod = steps;
				}

				if (!yperiod.HasValue && velocity.All(v => v.y == 0) &&
					position.Select(v => v.y).SequenceEqual(_input.Select(v => v.y)))
				{
					yperiod = steps;
				}

				if (!zperiod.HasValue && velocity.All(v => v.z == 0) &&
					position.Select(v => v.z).SequenceEqual(_input.Select(v => v.z)))
				{
					zperiod = steps;
				}
			} while (!(xperiod.HasValue && yperiod.HasValue && zperiod.HasValue));

			return Lcm(Lcm(xperiod.Value, yperiod.Value), zperiod.Value);
		}

		private static int Energy((int x, int y, int z) v) => Math.Abs(v.x) + Math.Abs(v.y) + Math.Abs(v.z);

		private static int Gravity(int a, int b) => a == b ? 0 : (a < b ? 1 : -1);

		private static long Lcm(long a, long b)
		{
			(a, b) = a > b ? (a, b) : (b, a);

			for (long i = 1; i < b; i++)
			{
				if (a * i % b == 0)
				{
					return i * a;
				}
			}

			return a * b;
		}

		private void Step((int x, int y, int z)[] position, (int x, int y, int z)[] velocity)
		{
			for (int i = 0; i < position.Length; i++)
			{
				for (int j = 0; j < position.Length; j++)
				{
					if (i == j)
					{
						continue;
					}

					velocity[i] = (
						velocity[i].x + Gravity(position[i].x, position[j].x),
						velocity[i].y + Gravity(position[i].y, position[j].y),
						velocity[i].z + Gravity(position[i].z, position[j].z)
					);
				}
			}

			for (int i = 0; i < position.Length; i++)
			{
				position[i] = (
					position[i].x + velocity[i].x,
					position[i].y + velocity[i].y,
					position[i].z + velocity[i].z

				);
			}
		}
	}
}
