using System.Text;

namespace AdventOfCode.Year2023;

public class Day20(string[] input)
{
	public int Part1()
	{
		var (nodes, edges) = Parse();
		var state = nodes.ToDictionary(x => x.Key, _ => 0);

		var count0 = 0;
		var count1 = 0;

		for (int i = 0; i < 1000; i++)
		{
			var (lo, hi) = PushButton(nodes, edges, state);
			count0 += lo;
			count1 += hi;
		}

		return count0 * count1;
	}

	public long Part2()
	{
		var (nodes, edges) = Parse();
		var state = nodes.ToDictionary(x => x.Key, _ => 0);

		// rx parent is a nand with four incoming edges
		var watch = edges[edges["rx"][0]].ToHashSet();
		var cycles = new Dictionary<string, long>();
		var done = false;

		for (int cycle = 1; !done; cycle++)
		{
			PushButton(nodes, edges, state, (src, sig) =>
			{
				if (watch.Contains(src) && sig is 0)
				{
					cycles.TryAdd(src, cycle);

					if (cycles.Count == watch.Count)
					{
						done = true;
					}
				}
			});
		}

		return cycles.Values.Aggregate(MathFunc.Lcm);
	}

	private static (int, int) PushButton(Dictionary<string, (char, string[])> nodes,
		Dictionary<string, string[]> edges, Dictionary<string, int> state,
		Action<string, int> recv = null)
	{
		var count0 = 0;
		var count1 = 0;

		var work = new Queue<(string, int)>();
		work.Enqueue(("button", 0));

		while (work.TryDequeue(out var curr))
		{
			var (src, sig) = curr;
			recv?.Invoke(src, sig);

			if (!nodes.TryGetValue(src, out var node))
			{
				continue;
			}

			var (type, dsts) = node;

			if (type is '%')
			{
				if (sig is 1)
				{
					continue;
				}

				Send(dsts, state[src] = state[src] is 0 ? 1 : 0);
			}
			else if (type is '&')
			{
				var any0 = edges[src].Any(dst => state[dst] is 0);
				Send(dsts, state[src] = any0 ? 1 : 0);
			}
			else if (type is 'b')
			{
				Send(dsts, state[src] = sig);
			}
		}

		return (count0, count1);

		void Send(string[] dsts, int sig)
		{
			foreach (var dst in dsts)
			{
				if (sig is 0)
				{
					count0++;
				}
				else
				{
					count1++;
				}

				work.Enqueue((dst, sig));
			}
		}
	}

	private static string GraphViz(Dictionary<string, (char, string[])> nodes)
	{
		var sb = new StringBuilder();
		sb.AppendLine("digraph G {");

		foreach (var (src, (type, dsts)) in nodes)
		{
			var color = type switch
			{
				'%' => "red",
				'&' => "blue",
				_ => "black",
			};

			sb.Append(src).Append(" -> {").AppendJoin(',', dsts).Append("} ");
			sb.Append("[color=").Append(color).AppendLine("]");
		}

		return sb.Append('}').ToString();
	}

	private (Dictionary<string, (char, string[])>, Dictionary<string, string[]>) Parse()
	{
		var nodes = new Dictionary<string, (char Type, string[] Dsts)>()
		{
			["button"] = ('b', ["broadcaster"]),
		};

		foreach (var line in input)
		{
			var type = line[0];
			var split = line[1..].Split("->", StringSplitOptions.TrimEntries);
			var src = split[0];
			var dsts = split[1].Split(',', StringSplitOptions.TrimEntries);

			if (type == 'b')
			{
				src = "broadcaster";
			}

			nodes.Add(src, (type, dsts));
		}

		var edges = nodes
			.SelectMany(kv => kv.Value.Dsts.Select(dst => (Src: kv.Key, Dst: dst)))
			.GroupBy(e => e.Dst)
			.ToDictionary(g => g.Key, g => g.Select(x => x.Src).ToArray());

		return (nodes, edges);
	}
}
