namespace AdventOfCode.Year2021;

public class Day24
{
	private readonly string[] _input;

	public Day24(string[] input)
	{
		_input = input;
	}

	public long Part1()
	{
		return Solve(new long[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
	}

	public long Part2()
	{
		return Solve(new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
	}

	private long Solve(long[] numbers)
	{
		var program = Parse();
		var visited = new HashSet<(int, Registers)>();

		return Find(0, default, 13);

		long Find(int counter, Registers registers, int depth)
		{
			if (visited.Contains((counter, registers)))
			{
				return 0;
			}

			var savedCounter = counter;
			var savedRegisters = registers;

			foreach (var number in numbers)
			{
				counter = savedCounter;
				registers = program[counter++].Execute(savedRegisters, number);

				while (counter < program.Length && program[counter].Mnemonic is not "inp")
				{
					registers = program[counter++].Execute(registers, 0);
				}

				if (counter == program.Length)
				{
					if (registers.Z is 0)
					{
						return number;
					}
					else
					{
						visited.Add((counter, registers));
						continue;
					}
				}

				var value = Find(counter, registers, depth - 1);

				if (value > 0)
				{
					var factor = (long)Math.Pow(10, depth);
					return number * factor + value;
				}
			}

			visited.Add((savedCounter, savedRegisters));
			return 0;
		}
	}

	private readonly record struct Instruction(string Mnemonic, Operand A, Operand B)
	{
		public Registers Execute(Registers regs, long input)
		{
			return Mnemonic switch
			{
				"inp" => Set(regs, A, input),
				"add" => Set(regs, A, Get(regs, A) + Get(regs, B)),
				"mul" => Set(regs, A, Get(regs, A) * Get(regs, B)),
				"div" => Set(regs, A, Get(regs, A) / Get(regs, B)),
				"mod" => Set(regs, A, Get(regs, A) % Get(regs, B)),
				"eql" => Set(regs, A, Get(regs, A) == Get(regs, B) ? 1 : 0),
				_ => throw new Exception("mnemonic?"),
			};

			long Get(Registers regs, Operand oper) => oper switch
			{
				('w', _) => regs.W,
				('x', _) => regs.X,
				('y', _) => regs.Y,
				('z', _) => regs.Z,
				('i', long imm) => imm,
			};

			Registers Set(Registers regs, Operand oper, long value) => oper.Register switch
			{
				'w' => regs with { W = value },
				'x' => regs with { X = value },
				'y' => regs with { Y = value },
				'z' => regs with { Z = value },
				_ => throw new Exception("register?"),
			};
		}
	}

	private readonly record struct Operand(char Register, long Immediate)
	{
		public static Operand Parse(string value) => value[0] switch
		{
			'w' => new('w', 0),
			'x' => new('x', 0),
			'y' => new('y', 0),
			'z' => new('z', 0),
			_ => new('i', value.ToInt64()),
		};
	}

	private readonly record struct Registers(long W, long X, long Y, long Z);

	private Instruction[] Parse() => _input
		.Select(l => l.Split(' '))
		.Select(s => new Instruction(s[0], Operand.Parse(s[1]), s.Length is 3 ? Operand.Parse(s[2]) : default))
		.ToArray();
}
