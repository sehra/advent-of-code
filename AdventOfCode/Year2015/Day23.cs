namespace AdventOfCode.Year2015;

public class Day23(string[] input)
{
	public uint Part1()
	{
		var comp = new Computer(input);
		comp.Run();

		return comp.B;
	}

	public uint Part2()
	{
		var comp = new Computer(input)
		{
			A = 1
		};
		comp.Run();

		return comp.B;
	}

	public class Computer(string[] insns)
	{
		private readonly List<Insn> _prog = [.. insns.Select(Insn.Parse)];

		public uint A { get; set; }
		public uint B { get; set; }

		public void Run()
		{
			for (int pc = 0; pc < _prog.Count; pc++)
			{
				pc += _prog[pc].Execute(this) - 1;
			}
		}

		private abstract record Insn
		{
			public abstract int Execute(Computer comp);

			protected static uint GetReg(Computer comp, char reg) => reg is 'a' ? comp.A : comp.B;

			protected static int SetReg(Computer comp, char reg, uint val)
			{
				if (reg is 'a')
				{
					comp.A = val;
				}
				else
				{
					comp.B = val;
				}

				return 1;
			}

			public static Insn Parse(string insn)
			{
				return insn switch
				{
					['h', 'l', 'f', ' ', var reg] => new Hlf(reg),
					['t', 'p', 'l', ' ', var reg] => new Tpl(reg),
					['i', 'n', 'c', ' ', var reg] => new Inc(reg),
					['j', 'm', 'p', ' ', .. var rel] => new Jmp(rel.ToInt32()),
					['j', 'i', 'e', ' ', var reg, ',', ' ', .. var rel] => new Jie(reg, rel.ToInt32()),
					['j', 'i', 'o', ' ', var reg, ',', ' ', .. var rel] => new Jio(reg, rel.ToInt32()),
					_ => throw new Exception("insn?"),
				};
			}
		}

		private record Hlf(char Reg) : Insn
		{
			public override int Execute(Computer comp) => SetReg(comp, Reg, GetReg(comp, Reg) / 2);
		}

		private record Tpl(char Reg) : Insn
		{
			public override int Execute(Computer comp) => SetReg(comp, Reg, GetReg(comp, Reg) * 3);
		}

		private record Inc(char Reg) : Insn
		{
			public override int Execute(Computer comp) => SetReg(comp, Reg, GetReg(comp, Reg) + 1);
		}

		private record Jmp(int Rel) : Insn
		{
			public override int Execute(Computer comp) => Rel;
		}

		private record Jie(char Reg, int Rel) : Insn
		{
			public override int Execute(Computer comp) => GetReg(comp, Reg) % 2 == 0 ? Rel : 1;
		}

		private record Jio(char Reg, int Rel) : Insn
		{
			public override int Execute(Computer comp) => GetReg(comp, Reg) == 1 ? Rel : 1;
		}
	}
}
