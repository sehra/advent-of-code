namespace AdventOfCode.Year2024;

using Graph = Dictionary<string, (string, string, string)>;

public class Day24(string[] input)
{
	public long Part1()
	{
		var graph = Parse();

		return graph.Keys
			.Where(key => key.StartsWith('z'))
			.OrderDescending()
			.Aggregate(0L, (acc, key) => acc * 2 + Eval(graph, key));

		static int Eval(Graph graph, string wire) => graph[wire] switch
		{
			("0", _, _) => 0,
			("1", _, _) => 1,
			("AND", var src1, var src2) => Eval(graph, src1) & Eval(graph, src2),
			("OR", var src1, var src2) => Eval(graph, src1) | Eval(graph, src2),
			("XOR", var src1, var src2) => Eval(graph, src1) ^ Eval(graph, src2),
			_ => throw new Exception("kind?"),
		};
	}

	public string Part2()
	{
		var graph = Parse()
			.Where(kv => kv.Value is not ("0" or "1", _, _))
			.ToDictionary(kv => kv.Value, kv => kv.Key);
		var bits = graph.Values
			.Where(val => val.StartsWith('z'))
			.Order().Last().AsSpan(1).ToInt32();
		var zlast = $"z{bits:00}";
		var swaps = new List<(string A, string B)>();
		string c = null;

		for (int n = 0; n < bits; n++)
		{
			// half adder (bit 0)
			// z{n} = x{n} xor y{n}
			// c{n} = x{n} and y{n}

			// full adder (bit 1+)
			// s0 = x{n} xor y{n}
			// c1 = x{n} and y{n}
			// c0 = c{n-1} and s0
			// z{n} = c{n-1} xor s0
			// c{n} = c0 or c1

			var xn = $"x{n:00}";
			var yn = $"y{n:00}";

			var s0 = Name("XOR", xn, yn);
			var c1 = Name("AND", xn, yn);

			if (n is 0)
			{
				c = c1;
			}
			else
			{
				var c0 = Name("AND", c, s0);

				if (c0 is null)
				{
					swaps.Add((s0, c1) = (c1, s0));
					c0 = Name("AND", c, s0);
				}

				var zn = Name("XOR", c, s0);

				if (s0 is ['z', ..])
				{
					swaps.Add((s0, zn) = (zn, s0));
				}

				if (c0 is ['z', ..])
				{
					swaps.Add((c0, zn) = (zn, c0));
				}

				if (c1 is ['z', ..])
				{
					swaps.Add((c1, zn) = (zn, c1));
				}

				var cn = Name("OR", c0, c1);

				if (cn is ['z', ..] && cn != zlast)
				{
					swaps.Add((cn, zn) = (zn, cn));
				}

				c = cn;
			}
		}

		return String.Join(',', swaps.SelectMany(s => new[] { s.A, s.B }).Order());

		string Name(string op, string a, string b) =>
			graph.TryGetValue((op, a, b), out var name) || graph.TryGetValue((op, b, a), out name) ? name : null;
	}

	private Graph Parse()
	{
		var graph = new Graph();

		foreach (var line in input)
		{
			var split = line.Split();

			if (split is [[.. var wire, ':'], var value])
			{
				graph[wire] = (value, null, null);
			}
			else if (split is [var src1, var kind, var src2, "->", var name])
			{
				graph[name] = (kind, src1, src2);
			}
		}

		return graph;
	}
}
