using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
	public class Day15
	{
		private const int N = 1;
		private const int S = 2;
		private const int W = 3;
		private const int E = 4;

		private readonly string _input;

		public Day15(string input)
		{
			_input = input;
		}

		public async Task<int> Part1()
		{
			var (map, dst) = await GetMapAsync();
			var visited = new HashSet<(int, int)>();

			return Solve((0, 0), 0);

			int Solve((int, int) pos, int len)
			{
				if (pos == dst)
				{
					return len;
				}

				if (visited.Contains(pos) || !IsOpen(map, pos))
				{
					return Int32.MaxValue;
				}

				visited.Add(pos);

				return new[]
				{
					Solve(Step(pos, N), len + 1),
					Solve(Step(pos, S), len + 1),
					Solve(Step(pos, W), len + 1),
					Solve(Step(pos, E), len + 1),
				}.Min();
			}
		}

		public async Task<int> Part2()
		{
			var (map, src) = await GetMapAsync();
			var visited = new HashSet<(int, int)>();

			return Solve(src, 0);

			int Solve((int, int) pos, int len)
			{
				if (visited.Contains(pos) || !IsOpen(map, pos))
				{
					return len - 1;
				}

				visited.Add(pos);

				return new[]
				{
					Solve(Step(pos, N), len + 1),
					Solve(Step(pos, S), len + 1),
					Solve(Step(pos, W), len + 1),
					Solve(Step(pos, E), len + 1),
				}.Max();
			}
		}

		private async Task<(Dictionary<(int x, int y), char>, (int x, int y))> GetMapAsync()
		{
			var map = new Dictionary<(int, int), char>();
			var pos = (x: 0, y: 0);
			var tar = pos;
			var dir = N;

			var intcode = new IntcodeComputer(_input)
			{
				Input = () => Task.FromResult((BigInteger)dir),
				Output = status =>
				{
					switch ((int)status)
					{
						case 0: // hit wall
							map[Step(pos, dir)] = '#';
							dir = dir switch
							{
								N => W,
								W => S,
								S => E,
								E => N,
								_ => throw new Exception("dir?"),
							};
							break;

						case 1: // moved
							pos = Step(pos, dir);
							map[pos] = '.';
							dir = dir switch
							{
								N when !IsWall(Step(pos, E)) => E,
								N => N,
								W when !IsWall(Step(pos, N)) => N,
								W => W,
								S when !IsWall(Step(pos, W)) => W,
								S => S,
								E when !IsWall(Step(pos, S)) => S,
								E => E,
								_ => throw new Exception("dir?"),
							};

							if (pos == default && tar != default)
							{
								throw new DoneException();
							}

							break;

						case 2: // found it
							tar = Step(pos, dir);
							goto case 1;
					}

					return Task.CompletedTask;
				},
			};

			try
			{
				await intcode.RunAsync();
			}
			catch (DoneException)
			{
				// not best practice
			}

			return (map, tar);

			bool IsWall((int, int) pos) => map.TryGetValue(pos, out var c) && c == '#';
		}

		private static bool IsOpen(Dictionary<(int, int), char> map, (int, int) pos) =>
			map.TryGetValue(pos, out var c) && c == '.';

		private static (int, int) Step((int x, int y) pos, int dir) => dir switch
		{
			N => (pos.x, pos.y + 1),
			S => (pos.x, pos.y - 1),
			W => (pos.x - 1, pos.y),
			E => (pos.x + 1, pos.y),
			_ => throw new Exception("dir?"),
		};

		private class DoneException : Exception
		{
		}
	}
}
