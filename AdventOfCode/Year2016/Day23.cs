namespace AdventOfCode.Year2016;

public class Day23(string[] input)
{
	public int Part1(int a = 7)
	{
		var comp = new Computer(input)
		{
			A = a,
		};
		comp.Run();

		return comp.A;
	}

	public long Part2()
	{
		var p = input
			.Select(line => line.Split())
			.ToArray();
		var a = p.Last(asm => asm is ["cpy", _, "c"])[1].ToInt64();
		var b = p.Last(asm => asm is ["jnz", _, "d"])[1].ToInt64();

		return a * b + MathFunc.Fac(12);
	}

	private class Computer(string[] program)
	{
		private readonly string[][] _program = [.. program.Select(i => i.Split())];

		public int A { get; set; }
		public int B { get; set; }
		public int C { get; set; }
		public int D { get; set; }

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

					case "tgl":
						var loc = pc + GetVal(asm[1]);
						if (0 <= loc && loc < _program.Length)
						{
							_program[loc] = Toggle(_program[loc]);
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

		private string[] Toggle(string[] asm)
		{
			var args = asm.AsSpan(1);

			return (asm[0], asm.Length) switch
			{
				("inc", _) => ["dec", .. args],
				("jnz", _) => ["cpy", .. args],
				(_, 2) => ["inc", .. args],
				(_, 3) => ["jnz", .. args],
				_ => throw new Exception("insn?"),
			};
		}
	}
}
