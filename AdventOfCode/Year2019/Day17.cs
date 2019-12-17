using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
	public class Day17
	{
		private readonly string _input;

		public Day17(string input)
		{
			_input = input;
		}

		public async Task<int> Part1()
		{
			var (map, _) = await GetMapAsync();
			var sum = 0;

			var xmax = map.Max(pos => pos.x) - 1;
			var ymax = map.Max(pos => pos.y) - 1;

			for (int x = 0; x < xmax; x++)
			{
				for (int y = 0; y < ymax; y++)
				{
					var pos = (x, y);

					if ("NSEW".Select(dir => Step(pos, dir)).Append(pos).All(pos => map.Contains(pos)))
					{
						sum += x * y;
					}
				}
			}

			return sum;
		}

		public async Task<BigInteger> Part2()
		{
			var (map, bot) = await GetMapAsync();
			var dir = bot.dir;

			var cardinal = PathToEnd(map, bot.pos)
				.GroupWhile((prev, item) => prev == item)
				.Select(steps => (dir: steps.First(), num: steps.Count()));
			var relative = new List<(char, int)>();

			foreach (var step in cardinal)
			{
				relative.Add((ToRelative(dir, step.dir), step.num));
				dir = step.dir;
			}

			var (main, a, b, c) = GetRoutines(relative);
			var input = Channel.CreateUnbounded<BigInteger>();
			var output = default(BigInteger);
			var intcode = new IntcodeComputer(_input)
			{
				Input = () => input.Reader.ReadAsync().AsTask(),
				Output = value => { output = value; return Task.CompletedTask; },
			};

			await InputAsync(main);
			await InputAsync(a);
			await InputAsync(b);
			await InputAsync(c);
			await InputAsync("n");

			intcode.Set(0, 2);
			await intcode.RunAsync();

			return output;

			async Task InputAsync(string value)
			{
				foreach (var c in Encoding.ASCII.GetBytes(value))
				{
					await input.Writer.WriteAsync(c);
				}

				await input.Writer.WriteAsync('\n');
			}
		}

		private async Task<(HashSet<(int x, int y)> map, ((int, int) pos, char dir) bot)> GetMapAsync()
		{
			var map = new HashSet<(int, int)>();
			var pos = (x: 0, y: 0);
			var bot = (pos, '?');

			var intcode = new IntcodeComputer(_input)
			{
				Output = value =>
				{
					var c = (char)value;

					if (c == '\n')
					{
						pos = (0, pos.y + 1);
					}
					else
					{
						if (c == '^' || c == 'v' || c == '<' || c == '>')
						{
							bot = (pos, c);
						}

						if (c != '.')
						{
							map.Add(pos);
						}

						pos = (pos.x + 1, pos.y);
					}

					return Task.CompletedTask;
				},
			};
			await intcode.RunAsync();

			return (map, bot);
		}

		private static IEnumerable<char> PathToEnd(HashSet<(int, int)> map, (int, int) pos)
		{
			var dir = "NSEW".Single(dir => map.Contains(Step(pos, dir)));

			while (true)
			{
				if (!map.Contains(Step(pos, dir)))
				{
					dir = "NSEW".SingleOrDefault(c => c != Reverse(dir) && map.Contains(Step(pos, c)));

					if (dir == default)
					{
						yield break;
					}
				}

				yield return dir;
				pos = Step(pos, dir);
			}

			static char Reverse(char dir) => dir switch
			{
				'N' => 'S',
				'S' => 'N',
				'W' => 'E',
				'E' => 'W',
				_ => throw new Exception("dir?"),
			};
		}

		private static (string, string, string, string) GetRoutines(List<(char dir, int num)> steps)
		{
			var whitelist = new[] { 'A', 'B', 'C', ',' };
			var original = String.Join(',', steps.Select(step => $"{step.dir}-{step.num}"));
			var split = original.Split(',');
			var tests = from alen in Enumerable.Range(2, 5)
						from blen in Enumerable.Range(2, 5)
						from clen in Enumerable.Range(2, 5)
						from coff in Enumerable.Range(1, 10)
						select (alen, blen, clen, coff);

			foreach (var (alen, blen, clen, coff) in tests)
			{
				var atry = String.Join(',', split.Take(alen));
				var btry = String.Join(',', split.Skip(alen).Take(blen));
				var ctry = String.Join(',', split.Skip(alen + blen + coff).Take(clen));

				if (atry.Length > 20 || btry.Length > 20 || ctry.Length > 20)
				{
					continue;
				}

				var test = original.Replace(atry, "A").Replace(btry, "B").Replace(ctry, "C");

				if (!test.Except(whitelist).Any())
				{
					return (test, atry.Replace('-', ','), btry.Replace('-', ','), ctry.Replace('-', ','));
				}
			}

			throw new Exception("no solution found");
		}

		private static (int, int) Step((int x, int y) pos, char dir) => dir switch
		{
			'N' => (pos.x, pos.y - 1),
			'S' => (pos.x, pos.y + 1),
			'E' => (pos.x + 1, pos.y),
			'W' => (pos.x - 1, pos.y),
			_ => throw new Exception("dir?"),
		};

		private static char ToRelative(char prev, char item) => (prev, item) switch
		{
			('N', 'E') => 'R',
			('N', 'W') => 'L',
			('S', 'W') => 'R',
			('S', 'E') => 'L',
			('W', 'N') => 'R',
			('W', 'S') => 'L',
			('E', 'S') => 'R',
			('E', 'N') => 'L',
			('^', 'E') => 'R',
			('^', 'W') => 'L',
			('v', 'W') => 'R',
			('v', 'E') => 'L',
			('<', 'N') => 'R',
			('<', 'S') => 'L',
			('>', 'S') => 'R',
			('>', 'N') => 'L',
			_ => throw new Exception("dir?"),
		};
	}
}
