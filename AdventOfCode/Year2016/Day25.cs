namespace AdventOfCode.Year2016;

public class Day25(string[] input)
{
	public int Part1()
	{
		var outs = new List<int>();
		var comp = new Computer(input)
		{
			Out = n => { outs.Add(n); return outs.Count is 12; },
		};
		comp.Run();
		var first = outs
			.AsEnumerable()
			.Reverse()
			.Aggregate((a, n) => a * 2 + n);

		return 0b1010_1010_1010 - first;
	}

	public string Part2()
	{
		return "get 49 stars";
	}

	private class Computer(string[] program)
	{
		private readonly string[][] _program = [.. program.Select(i => i.Split())];

		public int A { get; set; }
		public int B { get; set; }
		public int C { get; set; }
		public int D { get; set; }
		public Func<int, bool> Out { get; set; }

		public void Reset()
		{
			A = B = C = D = 0;
		}

		public void Run()
		{
			for (int pc = 0; pc < _program.Length; pc++)
			{
				var asm = _program[pc];

				switch (asm[0])
				{
					case "cpy":
						SetReg(asm[2], GetVal(asm[1]));
						break;

					case "inc":
						SetReg(asm[1], GetVal(asm[1]) + 1);
						break;

					case "dec":
						SetReg(asm[1], GetVal(asm[1]) - 1);
						break;

					case "jnz":
						pc += GetVal(asm[1]) != 0 ? GetVal(asm[2]) - 1 : 0;
						break;

					case "out":
						if (Out(GetVal(asm[1])))
						{
							return;
						}
						break;
				}
			}
		}

		private int GetVal(string val) => val[0] switch
		{
			'a' => A,
			'b' => B,
			'c' => C,
			'd' => D,
			_ => val.ToInt32(),
		};

		private void SetReg(string reg, int val)
		{
			switch (reg[0])
			{
				case 'a': A = val; break;
				case 'b': B = val; break;
				case 'c': C = val; break;
				case 'd': D = val; break;
			}
		}
	}
}
