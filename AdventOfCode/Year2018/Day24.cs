namespace AdventOfCode.Year2018;

public class Day24(string[] input)
{
	public int Part1() => Simulate(Parse()).Sum(g => g.Units);

	public int Part2()
	{
		var boost = 0;

		while (true)
		{
			var groups = Simulate(Parse(), boost++);

			if (groups.All(g => g.Army is "Immune System"))
			{
				return groups.Sum(g => g.Units);
			}
		}
	}

	private static List<Group> Simulate(List<Group> groups, int boost = 0)
	{
		foreach (var group in groups.Where(g => g.Army is "Immune System"))
		{
			group.Damage += boost;
		}

		var alive = groups.Where(g => g.Units > 0);

		while (alive.Distinct(g => g.Army).Count() > 1)
		{
			var attacks = new List<(Group Source, Group Target)>();
			var sources = alive
				.OrderByDescending(g => g.EffectivePower)
				.ThenByDescending(g => g.Initiative);

			foreach (var source in sources)
			{
				var target = alive
					.Where(g => g.Army != source.Army)
					.Except(attacks.Select(g => g.Target))
					.Where(g => !g.Immune.Contains(source.Type))
					.OrderByDescending(g => DamageDealt(source, g))
					.ThenByDescending(g => g.EffectivePower)
					.ThenByDescending(g => g.Initiative)
					.FirstOrDefault();

				if (target is { })
				{
					attacks.Add((source, target));
				}
			}

			attacks.Sort((a, b) => b.Source.Initiative.CompareTo(a.Source.Initiative));
			var total = 0;

			foreach (var (source, target) in attacks)
			{
				var killed = Math.Clamp(DamageDealt(source, target) / target.Health, 0, target.Units);
				target.Units -= killed;
				total += killed;
			}

			if (total is 0)
			{
				break;
			}
		}

		return alive.ToList();

		static int DamageDealt(Group source, Group target) =>
			source.EffectivePower *
			(target.Immune.Contains(source.Type) ? 0 : 1) *
			(target.Weak.Contains(source.Type) ? 2 : 1);
	}

	private class Group
	{
		public string Army { get; init; }
		public int Units { get; set; }
		public int Health { get; init; }
		public int Damage { get; set; }
		public string Type { get; init; }
		public int Initiative { get; init; }
		public List<string> Immune { get; } = [];
		public List<string> Weak { get; } = [];
		public int EffectivePower => Units * Damage;
	}

	private List<Group> Parse()
	{
		var groups = new List<Group>();
		var army = "";

		foreach (var line in input.Select(l => l.Contains('(') ? l : l.Replace("points", "points ()")))
		{
			if (line.EndsWith(':'))
			{
				army = line[..^1];
			}
			else
			{
				var split = line.Split('(', ')');
				var part1 = split[0].Split();
				var part2 = split[1].Split(';', StringSplitOptions.TrimEntries);
				var part3 = split[2].Split();
				var group = new Group()
				{
					Army = army,
					Units = part1[0].ToInt32(),
					Health = part1[4].ToInt32(),
					Damage = part3[6].ToInt32(),
					Type = part3[7],
					Initiative = part3[11].ToInt32(),
				};

				foreach (var part in part2)
				{
					if (part.StartsWith("weak to"))
					{
						group.Weak.AddRange(part[8..].Split(',', StringSplitOptions.TrimEntries));
					}
					else if (part.StartsWith("immune to"))
					{
						group.Immune.AddRange(part[10..].Split(',', StringSplitOptions.TrimEntries));
					}
				}

				groups.Add(group);
			}
		}

		return groups;
	}
}
