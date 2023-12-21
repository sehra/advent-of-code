using System.Collections.Concurrent;
using System.Threading.Channels;

namespace AdventOfCode.Year2019;

public class Day23
{
	private readonly string _input;

	public Day23(string input)
	{
		_input = input;
	}

	public async Task<BigInteger> Part1()
	{
		var cts = new CancellationTokenSource();
		var network = new ConcurrentDictionary<int, ConcurrentQueue<BigInteger>>();
		network[255] = new ConcurrentQueue<BigInteger>();

		for (int i = 0; i < 50; i++)
		{
			network[i] = new ConcurrentQueue<BigInteger>();
			network[i].Enqueue(i);
		}

		for (int i = 0; i < 50; i++)
		{
			var id = i;

			var output = Channel.CreateUnbounded<BigInteger>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = async () =>
				{
					if (network[id].TryDequeue(out var value))
					{
						return value;
					}

					await Task.Yield();

					return -1;
				},
				Output = value => output.Writer.WriteAsync(value).AsTask(),
			};
			_ = Task.Run(() => intcode.RunAsync(cts.Token));
			_ = Task.Run(async () =>
			{
				while (!cts.Token.IsCancellationRequested)
				{
					var a = await output.Reader.ReadAsync();
					var x = await output.Reader.ReadAsync();
					var y = await output.Reader.ReadAsync();

					var q = network[(int)a];
					q.Enqueue(x);
					q.Enqueue(y);
				}
			});
		}

		var nat = network[255];

		while (nat.Count < 2)
		{
			await Task.Yield();
		}

		cts.Cancel();
		nat.TryDequeue(out _);
		nat.TryDequeue(out var y);

		return y;
	}

	public async Task<BigInteger> Part2()
	{
		var cts = new CancellationTokenSource();
		var idle = new ConcurrentDictionary<int, int>();
		var network = new ConcurrentDictionary<int, ConcurrentQueue<BigInteger>>();
		network[255] = new ConcurrentQueue<BigInteger>();

		for (int i = 0; i < 50; i++)
		{
			idle[i] = 0;
			network[i] = new ConcurrentQueue<BigInteger>();
			network[i].Enqueue(i);
		}

		for (int i = 0; i < 50; i++)
		{
			var id = i;

			var output = Channel.CreateUnbounded<BigInteger>();
			var intcode = new IntcodeComputer(_input)
			{
				Input = async () =>
				{
					if (network[id].TryDequeue(out var value))
					{
						idle[id] = 0;
						return value;
					}

					idle[id]++;
					await Task.Yield();

					return -1;
				},
				Output = value => output.Writer.WriteAsync(value).AsTask(),
			};
			_ = Task.Run(() => intcode.RunAsync(cts.Token));
			_ = Task.Run(async () =>
			{
				while (!cts.Token.IsCancellationRequested)
				{
					var a = await output.Reader.ReadAsync();
					var x = await output.Reader.ReadAsync();
					var y = await output.Reader.ReadAsync();

					var q = network[(int)a];
					q.Enqueue(x);
					q.Enqueue(y);
				}
			});
		}

		var nat = network[255];
		var prev = (x: BigInteger.Zero, y: BigInteger.Zero);
		var curr = prev;

		while (true)
		{
			while (nat.Count < 2)
			{
				await Task.Yield();
			}

			// timing sensitivity knob
			while (idle.Any(kv => kv.Value < 10))
			{
				await Task.Yield();
			}

			while (nat.Count >= 2)
			{
				if (!nat.TryDequeue(out var x) || !nat.TryDequeue(out var y))
				{
					throw new Exception("nat?");
				}

				curr = (x, y);
			}

			if (curr.y == prev.y)
			{
				cts.Cancel();
				return curr.y;
			}

			network[0].Enqueue(curr.x);
			network[0].Enqueue(curr.y);
			prev = curr;
		}
	}
}
