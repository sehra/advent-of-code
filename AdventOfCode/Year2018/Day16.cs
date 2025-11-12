namespace AdventOfCode.Year2018;

using Result = (int Reg, int Val);
using Sample = (int[] Before, int[] Code, int[] After);

public class Day16(string[] input)
{
	public int Part1()
	{
		var (samples, _) = Parse();

		return samples.Count(sample => Matches(sample).Count() >= 3);
	}

	public int Part2()
	{
		var (samples, program) = Parse();
		var matches = samples
			.SelectMany(Matches)
			.GroupBy(result => result.Name)
			.ToDictionary(g => g.Key, g => g.Select(m => m.Code).ToHashSet());

		var mapping = new Dictionary<int, string>();

		while (matches.Values.Any(m => m.Count > 0))
		{
			var curr = matches.First(m => m.Value.Count is 1);
			var code = curr.Value.Single();
			mapping.Add(code, curr.Key);

			foreach (var match in matches.Values)
			{
				match.Remove(code);
			}
		}

		var regs = new int[4];

		foreach (var code in program)
		{
			var (reg, val) = OpCodes[mapping[code[0]]](code, regs);
			regs[reg] = val;
		}

		return regs[0];
	}

	private static IEnumerable<(string Name, int Code)> Matches(Sample sample)
	{
		foreach (var (name, func) in OpCodes)
		{
			var regs = sample.Before.ToArray();
			var (reg, val) = func(sample.Code, sample.Before);
			regs[reg] = val;

			if (sample.After.SequenceEqual(regs))
			{
				yield return (name, sample.Code[0]);
			}
		}
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

	private (List<Sample> Samples, List<int[]> Program) Parse()
	{
		var samples = new List<Sample>();
		var program = new List<int[]>();

		for (int i = 0; i < input.Length; i++)
		{
			if (input[i].StartsWith("Before"))
			{
				var bef = input[i + 0][9..^1].Split(',').ToInt32();
				var ins = input[i + 1].Split().ToInt32();
				var aft = input[i + 2][9..^1].Split(',').ToInt32();

				samples.Add((bef, ins, aft));
				i += 2;
			}
			else
			{
				program.Add(input[i].Split().ToInt32());
			}
		}

		return (samples, program);
	}
}
