using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2020
{
	public class Day7
	{
		private readonly string[] _input;

		public Day7(string input)
		{
			_input = input.ToLines();
		}

		public int Part1()
		{
			var rules = new Dictionary<string, HashSet<string>>();

			foreach (var rule in _input)
			{
				var nameMatch = Regex.Match(rule, @"^(?<name>\w+ \w+) bags contain (?<rest>.*)$");
				var name = nameMatch.Groups["name"].Value;
				var rest = nameMatch.Groups["rest"].Value;

				foreach (Match match in Regex.Matches(rest, @"(?:\d+) (?<name>\w+ \w+) bags?[,\.]"))
				{
					rules.Upsert(match.Groups["name"].Value, hs => hs.Add(name), () => new() { name });
				}
			}

			var hasgold = new HashSet<string>();
			Check("shiny gold");

			void Check(string name)
			{
				if (rules.TryGetValue(name, out var bags))
				{
					foreach (var bag in bags)
					{
						hasgold.Add(bag);
						Check(bag);
					}
				}
			}

			return hasgold.Count;
		}

		public int Part2()
		{
			var rules = new Dictionary<string, Dictionary<string, int>>();

			foreach (var rule in _input)
			{
				var bags = new Dictionary<string, int>();
				var nameMatch = Regex.Match(rule, @"^(?<name>\w+ \w+) bags contain (?<rest>.*)$");
				var name = nameMatch.Groups["name"].Value;
				var rest = nameMatch.Groups["rest"].Value;

				foreach (Match match in Regex.Matches(rest, @"(?<count>\d+) (?<name>\w+ \w+) bags?[,\.]"))
				{
					bags.Add(match.Groups["name"].Value, match.Groups["count"].Value.ToInt32());
				}

				rules.Add(name, bags);
			}

			return Count("shiny gold");

			int Count(string name)
			{
				var total = 0;

				if (rules.TryGetValue(name, out var bags))
				{
					foreach (var bag in bags)
					{
						total += bag.Value;
						total += bag.Value * Count(bag.Key);
					}
				}

				return total;
			}
		}
	}
}
