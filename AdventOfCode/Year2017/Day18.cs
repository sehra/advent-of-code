using System.Threading.Channels;

namespace AdventOfCode.Year2017;

public class Day18(string[] input)
{
	public async Task<long> Part1()
	{
		var cts = new CancellationTokenSource();
		var sound = 0L;
		var comp = new Computer(input)
		{
			Halt = cts.Token,
			Snd = val => { sound = val; return ValueTask.CompletedTask; },
			Rcv = () => { cts.Cancel(); return ValueTask.FromResult(sound); },
		};
		await comp.RunAsync();

		return sound;
	}

	public async Task<int> Part2()
	{
		var count = 0;
		var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
		var chan01 = Channel.CreateUnbounded<long>();
		var chan10 = Channel.CreateUnbounded<long>();
		var comp0 = new Computer(input)
		{
			Snd = val => chan01.Writer.WriteAsync(val),
			Rcv = () => chan10.Reader.ReadAsync(cts.Token),
		};
		comp0.Set("p", 0);
		var comp1 = new Computer(input)
		{
			Snd = val => { count++; return chan10.Writer.WriteAsync(val); },
			Rcv = () => chan01.Reader.ReadAsync(cts.Token),
		};
		comp1.Set("p", 1);

		try
		{
			await Task.WhenAll(comp0.RunAsync(), comp1.RunAsync());
		}
		catch (OperationCanceledException)
		{
		}

		return count;
	}

	private class Computer(string[] input)
	{
		private readonly DefaultDictionary<string, long> _regs = [];
		private readonly string[][] _prog = [.. input.Select(line => line.Split())];

        public CancellationToken Halt { get; set; }
        public Func<ValueTask<long>> Rcv { get; set; }
		public Func<long, ValueTask> Snd { get; set; }

		public async Task RunAsync()
		{
			for (int pc = 0; pc < _prog.Length && !Halt.IsCancellationRequested; pc++)
			{
				var insn = _prog[pc];

				switch (insn[0])
				{
					case "snd":
						await Snd(Get(insn[1]));
						break;

					case "set":
						_regs[insn[1]] = Get(insn[2]);
						break;

					case "add":
						_regs[insn[1]] += Get(insn[2]);
						break;

					case "mul":
						_regs[insn[1]] *= Get(insn[2]);
						break;

					case "mod":
						_regs[insn[1]] %= Get(insn[2]);
						break;

					case "rcv":
						_regs[insn[1]] = await Rcv();
						break;

					case "jgz":
						if (Get(insn[1]) > 0)
						{
							pc += (int)Get(insn[2]) - 1;
						}
						break;
				}
			}
		}

		public long Get(string reg)
		{
			if (Char.IsLetter(reg[0]))
			{
				return _regs[reg];
			}
			else
			{
				return reg.ToInt64();
			}
		}

		public void Set(string reg, long val)
		{
			_regs[reg] = val;
		}

		private class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
		{
			public new TValue this[TKey key]
			{
				get => TryGetValue(key, out var value) ? value : default;
				set => base[key] = value;
			}
		}
	}
}
