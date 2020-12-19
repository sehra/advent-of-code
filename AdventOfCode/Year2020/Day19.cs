using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2020
{
	public class Day19
	{
		private readonly string[] _input;

		public Day19(string input)
		{
			_input = input.ToLines();
		}

		public int Part1()
		{
			return Solve(false);
		}

		public int Part2()
		{
			return Solve(true);
		}

		private int Solve(bool part2)
		{
			var rules = new Rules(part2);
			var tests = new List<string>();

			foreach (var line in _input)
			{
				if (line.Contains(':'))
				{
					rules.AddRule(line);
				}
				else
				{
					tests.Add(line);
				}
			}

			var regex = new Regex($"^{rules.GetRegex(0)}$", RegexOptions.Compiled);

			return tests.Count(regex.IsMatch);
		}

		private class Rules
		{
			private readonly Dictionary<int, Func<string>> _rules = new();
			private readonly Dictionary<int, string> _cache = new();
			private readonly bool _part2;

			public Rules(bool part2)
			{
				_part2 = part2;
			}

			public void AddRule(string line)
			{
				var rule = line[..line.IndexOf(':')].ToInt32();

				if (line.Contains('|'))
				{
					var rest = line[(line.IndexOf(':') + 2)..];
					var option1 = rest[..(rest.IndexOf('|') - 1)].Split(' ').Select(Int32.Parse);
					var option2 = rest[(rest.IndexOf('|') + 2)..].Split(' ').Select(Int32.Parse);
					AddRule(rule, option1.ToArray(), option2.ToArray());
				}
				else if (line.Contains('"'))
				{
					var start = line.IndexOf('"');
					var end = line.IndexOf('"', start + 1);
					AddRule(rule, line.Substring(start + 1, end - start - 1));
				}
				else
				{
					var parts = line[(line.IndexOf(':') + 2)..].Split(' ').Select(Int32.Parse);
					AddRule(rule, parts.ToArray());
				}
			}

			public string GetRegex(int rule)
			{
				if (_cache.TryGetValue(rule, out var value))
				{
					return value;
				}

				if (_part2)
				{
					if (rule == 8)
					{
						return _cache[8] = $"{GetRegex(42)}+";
					}
					else if (rule == 11)
					{
						var r42 = GetRegex(42);
						var r31 = GetRegex(31);
						var alt = Enumerable.Range(1, 10).Select(n => $"{r42}{{{n}}}{r31}{{{n}}}");

						return _cache[11] = $"(?:{String.Join('|', alt)})";
					}
				}

				return _cache[rule] = _rules[rule]();
			}

			private void AddRule(int rule, string value)
			{
				_rules[rule] = () => value;
			}

			private void AddRule(int rule, int[] option1, int[] option2)
			{
				_rules[rule] = () =>
				{
					var opt1 = option1.Select(GetRegex);
					var opt2 = option2.Select(GetRegex);

					return $"(?:{String.Concat(opt1)}|{String.Concat(opt2)})";
				};
			}

			private void AddRule(int rule, int[] rules)
			{
				_rules[rule] = () => String.Concat(rules.Select(GetRegex));
			}
		}
	}
}
