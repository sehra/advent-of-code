namespace AdventOfCode.Year2017;

public class Day23(string[] input)
{
	public int Part1()
	{
		var comp = new Computer(input);
		comp.Run();

		return comp.MulInvoked;
	}

	public int Part2()
	{
		var x = input[0].Split()[2].ToInt32();

		var b = x * 100 + 100_000;
		var c = b + 17_000;
		var h = 0;

		for (; b <= c; b += 17)
		{
			if (IsPrime(b))
			{
				h++;
			}
		}

		return h;

		static bool IsPrime(int n)
		{
			for (int i = 2; i < n / 2; i++)
			{
				if (n % i is 0)
				{
					return true;
				}
			}

			return false;
		}
	}

	private class Computer(string[] input)
	{
		private readonly DefaultDictionary<string, long> _regs = [];
		private readonly string[][] _prog = [.. input.Select(line => line.Split())];

		public int MulInvoked { get; private set; }

		public void Run()
		{
			for (int pc = 0; pc < _prog.Length; pc++)
			{
				var insn = _prog[pc];

				switch (insn[0])
				{
					case "set":
						_regs[insn[1]] = Get(insn[2]);
						break;

					case "sub":
						_regs[insn[1]] -= Get(insn[2]);
						break;

					case "mul":
						_regs[insn[1]] *= Get(insn[2]);
						MulInvoked++;
						break;

					case "jnz":
						if (Get(insn[1]) != 0)
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
