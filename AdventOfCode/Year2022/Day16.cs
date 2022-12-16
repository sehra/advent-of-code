namespace AdventOfCode.Year2022;

public class Day16
{
	private readonly string[] _input;

	public Day16(string[] input)
	{
		_input = input;
	}

	public int Part1() => Solve(false);

	public int Part2() => Solve(true);

	private int Solve(bool elephant)
	{
		var scanned = Parse();
		var valves = scanned.Where(x => x.Value.FlowRate > 0).Select(x => x.Key).ToArray();
		var shortest = new Dictionary<(string, string), int>();

		foreach (var (valve, _) in scanned)
		{
			var done = new HashSet<string>() { valve };
			var work = new PriorityQueue<string, int>(new[] { (valve, 0) });

			while (work.TryDequeue(out var node, out var dist))
			{
				foreach (var next in scanned[node].Tunnels)
				{
					if (done.Add(next))
					{
						shortest[(valve, next)] = dist + 1;
						work.Enqueue(next, dist + 1);
					}
				}
			}
		}

		return !elephant
			? Find(0, 0, 0, "AA", valves, 30)
			: Enumerable.Range(1, valves.Length / 2)
				.AsParallel()
				.SelectMany(count => valves.Combinations(count))
				.Select(open => Find(0, 0, 0, "AA", open, 26) + Find(0, 0, 0, "AA", valves.Except(open), 26))
				.Max();

		int Find(int minute, int pressure, int flow, string here, IEnumerable<string> valves, int limit)
		{
			var max = pressure + (limit - minute) * flow;

			foreach (var valve in valves)
			{
				var duration = shortest[(here, valve)] + 1;

				if (minute + duration < limit)
				{
					var newMinute = minute + duration;
					var newPressure = pressure + duration * flow;
					var newFlow = flow + scanned[valve].FlowRate;
					var newRemaining = valves.Except(valve).ToArray();
					max = Math.Max(max, Find(newMinute, newPressure, newFlow, valve, newRemaining, limit));
				}
			}

			return max;
		}
	}

	private Dictionary<string, (int FlowRate, string[] Tunnels)> Parse()
	{
		var result = new Dictionary<string, (int FlowRate, string[] Tunnels)>();

		foreach (var line in _input)
		{
			var match = Regex.Match(line, @"Valve (\w+) has flow rate=(\d+); tunnels? leads? to valves? (.+)");
			var valve = match.Groups[1].Value;
			result[valve] = (match.Groups[2].Value.ToInt32(), match.Groups[3].Value.Split(',', StringSplitOptions.TrimEntries).ToArray());
		}

		return result;
	}
}
