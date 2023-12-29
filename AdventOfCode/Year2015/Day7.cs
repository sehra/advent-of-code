namespace AdventOfCode.Year2015;

public class Day7(string[] input)
{
	public int Part1(string wire = "a") => Parse()[wire].Value;

	public int Part2()
	{
		var fst = Parse();
		var a = fst["a"].Value;

		var snd = Parse();
		snd["b"] = new(a);

		return snd["a"].Value;
	}

	private Dictionary<string, Lazy<ushort>> Parse()
	{
		var circuit = new Dictionary<string, Lazy<ushort>>();

		foreach (var line in input)
		{
			var split1 = line.Split("->", StringSplitOptions.TrimEntries);
			var dst = split1[1];
			var src = split1[0].Split(' ', StringSplitOptions.TrimEntries);
			
			Lazy<ushort> func = src switch
			{
				[var lhs, "AND", var rhs] => new(() => (ushort)(GetVal(lhs)() & GetVal(rhs)())),
				[var lhs, "OR", var rhs] => new(() => (ushort)(GetVal(lhs)() | GetVal(rhs)())),
				[var lhs, "LSHIFT", var rhs] => new(() => (ushort)(GetVal(lhs)() << GetVal(rhs)())),
				[var lhs, "RSHIFT", var rhs] => new(() => (ushort)(GetVal(lhs)() >> GetVal(rhs)())),
				["NOT", var arg] => new(() => (ushort)(~GetVal(arg)() & 0xFFFF)),
				[var arg] => new(() => GetVal(arg)()),
				_ => throw new Exception("ins?"),
			};

			circuit[dst] = func;

			Func<ushort> GetVal(string val)
			{
				if (Char.IsDigit(val[0]))
				{
					var v = UInt16.Parse(val);
					return () => v;
				}
				else
				{
					var v = val;
					return () => circuit[v].Value;
				}
			}
		}

		return circuit;
	}
}
