namespace AdventOfCode.Year2017;

public class Day8(string[] input)
{
	public int Part1() => Solve().MaxCurr;

	public int Part2() => Solve().MaxEver;

	private (int MaxCurr, int MaxEver) Solve()
	{
		var prog = Parse();
		var regs = new DefaultDictionary<string, int>();
		var high = Int32.MinValue;

		foreach (var (expr, cond) in prog)
		{
			var test = cond.Op switch
			{
				"==" => regs[cond.Reg] == cond.Val,
				"!=" => regs[cond.Reg] != cond.Val,
				"<" => regs[cond.Reg] < cond.Val,
				">" => regs[cond.Reg] > cond.Val,
				"<=" => regs[cond.Reg] <= cond.Val,
				">=" => regs[cond.Reg] >= cond.Val,
				_ => throw new Exception("op?"),
			};

			if (test)
			{
				regs[expr.Reg] = expr.Op switch
				{
					"inc" => regs[expr.Reg] + expr.Val,
					"dec" => regs[expr.Reg] - expr.Val,
					_ => throw new Exception("op?"),
				};
				high = Math.Max(high, regs[expr.Reg]);
			}
		}

		return (regs.Values.Max(), high);
	}

	private readonly record struct Insn(string Reg, string Op, int Val)
	{
		public static Insn Parse(string[] strs) =>
			new(strs[0], strs[1], strs[2].ToInt32());
	}

	private (Insn Expr, Insn Cond)[] Parse() => input
		.Select(line => line.Split())
		.Select(line => (Insn.Parse(line[..3]), Insn.Parse(line[4..])))
		.ToArray();

	private class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		public new TValue this[TKey key]
		{
			get => TryGetValue(key, out var value) ? value : default;
			set => base[key] = value;
		}
	}
}
