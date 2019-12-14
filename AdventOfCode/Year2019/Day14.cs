using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class Day14
	{
		private readonly Dictionary<string, Reaction> _input;

		public Day14(string input)
		{
			_input = input.Split('\n')
				.Select(line => line.Split("=>"))
				.Select(line => new Reaction
				{
					Gives = Parse(line[1]),
					Needs = line[0].Split(',').Select(Parse).ToDictionary(x => x.Item1, x => x.Item2),
				})
				.ToDictionary(x => x.Gives.Item1);

			static (string, long) Parse(string v)
			{
				var split = v.Trim().Split(' ', 2);
				return (split[1], Int64.Parse(split[0]));
			}
		}

		public long Part1()
		{
			return NeededOre("FUEL", 1);
		}

		public long Part2()
		{
			const long trillion = 1_000_000_000_000;
			long lower = 1;
			long upper = 2;

			while (NeededOre("FUEL", upper) < trillion)
			{
				(lower, upper) = (upper, upper * 2);
			}

			while (upper - lower >= 2)
			{
				var guess = lower + ((upper - lower) / 2);

				if (NeededOre("FUEL", guess) > trillion)
				{
					upper = guess;
				}
				else
				{
					lower = guess;
				}
			}

			return lower;
		}

		private long NeededOre(string name, long amount)
		{
			return NeededOre(name, amount, new Dictionary<string, long>());

			long NeededOre(string name, long amount, Dictionary<string, long> surplus)
			{
				long result = 0;
				var reaction = _input.First(kv => kv.Value.Gives.Name == name);
				var multiple = (amount + reaction.Value.Gives.Amount - 1) / reaction.Value.Gives.Amount;

				foreach (var need in reaction.Value.Needs)
				{
					if (need.Key == "ORE")
					{
						result += multiple * need.Value;
					}
					else
					{
						if (!surplus.ContainsKey(need.Key))
						{
							surplus[need.Key] = 0;
						}

						if (surplus[need.Key] < multiple * need.Value)
						{
							result += NeededOre(need.Key, multiple * need.Value - surplus[need.Key], surplus);
						}

						surplus[need.Key] -= multiple * need.Value;
					}
				}

				if (!surplus.ContainsKey(reaction.Value.Gives.Name))
				{
					surplus[reaction.Value.Gives.Name] = 0;
				}

				surplus[reaction.Value.Gives.Name] += multiple * reaction.Value.Gives.Amount;

				return result;
			}
		}

		private class Reaction
		{
			public (string Name, long Amount) Gives { get; set; }
			public Dictionary<string, long> Needs { get; set; }
		}
	}
}
