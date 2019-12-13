using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
	public class Day13
	{
		private readonly string _input;

		public Day13(string input)
		{
			_input = input;
		}

		public async Task<int> Part1()
		{
			var outputs = new List<int>();
			var intcode = new IntcodeComputer(_input)
			{
				Output = value => { outputs.Add((int)value); return Task.CompletedTask; }
			};
			await intcode.RunAsync();

			return outputs
				.Select((o, i) => (o, i))
				.GroupBy(v => v.i % 3)
				.First(g => g.Key == 2)
				.Count(v => v.o == 2);
		}

		public async Task<int> Part2()
		{
			var score = 0;
			var input = Channel.CreateUnbounded<BigInteger>();
			var output = Channel.CreateUnbounded<BigInteger>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = () => input.Reader.ReadAsync().AsTask(),
				Output = value => output.Writer.WriteAsync(value).AsTask(),
			};
			intcode.Set(0, 2);

			await Task.WhenAll(new[]
			{
				Task.Run(async () =>
				{
					await intcode.RunAsync();
					output.Writer.Complete();
				}),
				Task.Run(async () =>
				{
					int? bx = null;
					int? px = null;

					while (await output.Reader.WaitToReadAsync())
					{
						var x = (int)await output.Reader.ReadAsync();
						var y = (int)await output.Reader.ReadAsync();
						var v = (int)await output.Reader.ReadAsync();

						if (x == -1 && y == 0)
						{
							score = v;
						}
						else
						{
							if (v == 3)
							{
								px = x;
							}
							else if (v == 4)
							{
								bx = x;
							}
						}

						if (bx.HasValue && px.HasValue)
						{
							var direction = Math.Clamp(bx.Value.CompareTo(px.Value), -1, 1);

							if (px != bx)
							{
								bx = null;
								px = null;
							}
							else
							{
								bx = null;
							}

							await input.Writer.WriteAsync(direction);
						}
					}
				}),
			});

			return score;
		}
	}
}
