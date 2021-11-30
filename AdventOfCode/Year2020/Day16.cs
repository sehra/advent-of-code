namespace AdventOfCode.Year2020;

public class Day16
{
	private readonly string _input;

	public Day16(string input)
	{
		_input = input;
	}

	public int Part1()
	{
		var input = Parse(_input, false);

		return input.NearbyTickets
			.SelectMany(x => x)
			.Where(f => !input.FieldRules.SelectMany(r => r.Value).Any(IsMatch(f)))
			.Sum();
	}

	public long Part2()
	{
		var input = Parse(_input, true);
		var matches = new Dictionary<string, List<int>>();

		foreach (var (name, rules) in input.FieldRules)
		{
			matches.Add(name, new());

			for (int i = 0; i < input.YourTicket.Count; i++)
			{
				if (input.NearbyTickets.Select(t => t[i]).All(f => rules.Any(IsMatch(f))))
				{
					matches[name].Add(i);
				}
			}
		}

		var done = new HashSet<string>();

		while (matches.Any(match => match.Value.Count > 1))
		{
			var current = matches.First(m => !done.Contains(m.Key) && m.Value.Count == 1);
			var value = current.Value[0];

			foreach (var match in matches.Except(current).Where(m => m.Value.Contains(value)))
			{
				match.Value.Remove(value);
			}

			done.Add(current.Key);
		}

		return matches
			.Where(m => m.Key.StartsWith("departure"))
			.Select(m => input.YourTicket[m.Value[0]])
			.Aggregate(1L, (acc, val) => acc * val);
	}

	private static Func<Rule, bool> IsMatch(int value) =>
		(rule) => rule.Low <= value && value <= rule.High;

	private record Rule(int Low, int High);

	private class ParseResult
	{
		public Dictionary<string, List<Rule>> FieldRules { get; } = new();
		public List<int> YourTicket { get; } = new();
		public List<List<int>> NearbyTickets { get; } = new();
	}

	private static ParseResult Parse(string input, bool onlyValid)
	{
		var result = new ParseResult();
		var state = 0;

		foreach (var line in input.ToLines())
		{
			if (line.StartsWith("your ticket"))
			{
				state = 1;
				continue;
			}
			else if (line.StartsWith("nearby tickets"))
			{
				state = 2;
				continue;
			}

			if (state == 0)
			{
				var name = line[0..line.IndexOf(':')];
				var rules = Regex.Matches(line, @"\b(\d+)-(\d+)\b").Cast<Match>()
					.Select(m => new Rule(m.Groups[1].Value.ToInt32(), m.Groups[2].Value.ToInt32()));
				result.FieldRules.Add(name, rules.ToList());
			}
			else if (state == 1)
			{
				result.YourTicket.AddRange(line.Split(',').Select(Int32.Parse));
			}
			else if (state == 2)
			{
				var ticket = line.Split(',').Select(Int32.Parse).ToList();

				if (onlyValid)
				{
					if (!ticket.All(f => result.FieldRules.SelectMany(r => r.Value).Any(IsMatch(f))))
					{
						continue;
					}
				}

				result.NearbyTickets.Add(ticket);
			}
		}

		return result;
	}
}
