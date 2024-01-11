namespace AdventOfCode.Year2018;

using Insn = (string Name, long[] Code);
using Result = (long Reg, long Val);

public class Day21(string[] input)
{
	public long Part1()
	{
		var (ir, prog) = Parse();
		var regs = new long[6];
		var ip = 0L;

		while (0 <= ip && ip < prog.Length)
		{
			var (name, code) = prog[ip];
			regs[ir] = ip;
			var (reg, val) = OpCodes[name](code, regs);
			regs[reg] = val;
			ip = regs[ir] + 1;

			if (name is "eqrr" && code[2] is 0)
			{
				return regs[code[1]];
			}
		}

		throw new Exception("not found");
	}

	public long Part2()
	{
		var (ir, prog) = Parse();
		var regs = new long[6];
		var ip = 0L;

		var seen = new HashSet<long>();

		while (0 <= ip && ip < prog.Length)
		{
			var (name, code) = prog[ip];
			regs[ir] = ip;
			var (reg, val) = OpCodes[name](code, regs);
			regs[reg] = val;
			ip = regs[ir] + 1;

			if (name is "eqrr" && code[2] is 0)
			{
				if (!seen.Add(regs[code[1]]))
				{
					return seen.Last();
				}
			}
		}

		throw new Exception("not found");
	}

	private static readonly Dictionary<string, Func<long[], long[], Result>> OpCodes = new()
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
			.Select(line => new Insn(line[0], [0, .. line[1..].ToInt64()]))
			.ToArray();

		return (ip, prog);
	}
}
