namespace AdventOfCode.Year2018;

using Insn = (string Name, int[] Code);
using Result = (int Reg, int Val);

public class Day19(string[] input)
{
	public int Part1()
	{
		var (ir, prog) = Parse();
		var regs = new int[6];
		var ip = 0;

		while (0 <= ip && ip < prog.Length)
		{
			var (name, code) = prog[ip];
			regs[ir] = ip;
			var (reg, val) = OpCodes[name](code, regs);
			regs[reg] = val;
			ip = regs[ir] + 1;
		}

		return regs[0];
	}

	public int Part2()
	{
		var (ir, prog) = Parse();
		var regs = new int[6];
		regs[0] = 1;
		var ip = 0;

		while (0 <= ip && ip < prog.Length)
		{
			if (ip is 1)
			{
				var a = 0;
				var n = regs[prog[33].Code[3]];

				for (int i = 1; i <= n; i++)
				{
					if (n % i is 0)
					{
						a += i;
					}
				}

				return a;
			}

			var (name, code) = prog[ip];
			regs[ir] = ip;
			var (reg, val) = OpCodes[name](code, regs);
			regs[reg] = val;
			ip = regs[ir] + 1;
		}

		return regs[0];
	}

	private static readonly Dictionary<string, Func<int[], int[], Result>> OpCodes = new()
	{
		["addr"] = static (code, regs) => (code[3], regs[code[1]] + regs[code[2]]),
		["addi"] = static (code, regs) => (code[3], regs[code[1]] + code[2]),
		["mulr"] = static (code, regs) => (code[3], regs[code[1]] * regs[code[2]]),
		["muli"] = static (code, regs) => (code[3], regs[code[1]] * code[2]),
		["banr"] = static (code, regs) => (code[3], regs[code[1]] & regs[code[2]]),
		["bani"] = static (code, regs) => (code[3], regs[code[1]] & code[2]),
		["borr"] = static (code, regs) => (code[3], regs[code[1]] | regs[code[2]]),
		["bori"] = static (code, regs) => (code[3], regs[code[1]] | code[2]),
		["setr"] = static (code, regs) => (code[3], regs[code[1]]),
		["seti"] = static (code, regs) => (code[3], code[1]),
		["gtir"] = static (code, regs) => (code[3], code[1] > regs[code[2]] ? 1 : 0),
		["gtri"] = static (code, regs) => (code[3], regs[code[1]] > code[2] ? 1 : 0),
		["gtrr"] = static (code, regs) => (code[3], regs[code[1]] > regs[code[2]] ? 1 : 0),
		["eqir"] = static (code, regs) => (code[3], code[1] == regs[code[2]] ? 1 : 0),
		["eqri"] = static (code, regs) => (code[3], regs[code[1]] == code[2] ? 1 : 0),
		["eqrr"] = static (code, regs) => (code[3], regs[code[1]] == regs[code[2]] ? 1 : 0),
	};

	private (int Ip, Insn[] Prog) Parse()
	{
		var ip = input[0][4..].ToInt32();
		var prog = input.Skip(1)
			.Select(line => line.Split())
			.Select(line => new Insn(line[0], [0, .. line[1..].ToInt32()]))
			.ToArray();

		return (ip, prog);
	}
}
