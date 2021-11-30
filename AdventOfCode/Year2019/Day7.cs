using System.Numerics;
using System.Threading.Channels;

namespace AdventOfCode.Year2019;

public class Day7
{
	private readonly BigInteger[] _input;

	public Day7(string input)
	{
		_input = input.Split(',').Select(BigInteger.Parse).ToArray();
	}

	public async Task<BigInteger> Part1()
	{
		var results = new List<BigInteger>();

		foreach (var setting in new[] { 0, 1, 2, 3, 4 }.Permutations())
		{
			var stack = new Stack<BigInteger>();
			stack.Push(0);

			for (int i = 0, count = setting.Count(); i < count; i++)
			{
				stack.Push(setting.ElementAt(i));

				var intcode = new IntcodeComputer(_input.ToArray())
				{
					Input = () => Task.FromResult(stack.Pop()),
					Output = value => { stack.Push(value); return Task.CompletedTask; },
				};

				await intcode.RunAsync();
			}

			results.Add(stack.Peek());
		}

		return results.Max();
	}

	public async Task<BigInteger> Part2()
	{
		var results = new List<BigInteger>();

		foreach (var setting in new[] { 5, 6, 7, 8, 9 }.Permutations())
		{
			var channel = Channel.CreateUnbounded<BigInteger>();
			var feedback = channel;
			var intcodes = new List<Task>();

			for (int i = 0, count = setting.Count(); i < count; i++)
			{
				await channel.Writer.WriteAsync(setting.ElementAt(i));
				var input = channel.Reader;
				channel = Channel.CreateUnbounded<BigInteger>();
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
			results.Add(await feedback.Reader.ReadAsync());
		}

		return results.Max();
	}
}
