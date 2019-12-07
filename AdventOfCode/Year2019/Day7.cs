using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
	public class Day7
	{
		private readonly int[] _input;

		public Day7(string input)
		{
			_input = input.Split(',').Select(Int32.Parse).ToArray();
		}

		public int Part1()
		{
			return Permutations(new[] { 0, 1, 2, 3, 4 })
				.Max(setting => Run1(setting).GetAwaiter().GetResult());
		}

		public int Part2()
		{
			return Permutations(new[] { 5, 6, 7, 8, 9 })
				.Max(setting => Run2(setting).GetAwaiter().GetResult());
		}

		private async Task<int> Run1(IEnumerable<int> setting)
		{
			var stack = new Stack<int>();
			stack.Push(0);

			for (int i = 0, count = setting.Count(); i < count; i++)
			{
				stack.Push(setting.ElementAt(i));

				var intcode = new IntcodeComputer(_input.ToArray())
				{
					Input = () => Task.FromResult(stack.Pop()),
					Output = value => { stack.Push(value); return Task.CompletedTask; }
				};

				await intcode.RunAsync();
			}

			return stack.Peek();
		}

		private async Task<int> Run2(IEnumerable<int> setting)
		{
			var channel = Channel.CreateUnbounded<int>();
			var feedback = channel;
			var intcodes = new List<Task>();

			for (int i = 0, count = setting.Count(); i < count; i++)
			{
				await channel.Writer.WriteAsync(setting.ElementAt(i));
				var input = channel.Reader;
				channel = Channel.CreateUnbounded<int>();
				var output = (i == count - 1) ? feedback.Writer : channel.Writer;
				var intcode = new IntcodeComputer(_input.ToArray())
				{
					Input = () => input.ReadAsync().AsTask(),
					Output = value => output.WriteAsync(value).AsTask(),
				};
				intcodes.Add(intcode.RunAsync());
			}

			await feedback.Writer.WriteAsync(0);
			await Task.WhenAll(intcodes);

			return await feedback.Reader.ReadAsync();
		}

		private static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> items)
		{
			var count = items.Count();

			if (count == 1)
			{
				yield return items;
			}
			else
			{
				for (int i = 0; i < count; i++)
				{
					foreach (var permutation in Permutations(items.Take(i).Concat(items.Skip(i + 1))))
					{
						yield return items.Skip(i).Take(1).Concat(permutation);
					}
				}
			}
		}
	}
}
