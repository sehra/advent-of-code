using System.Text;

namespace AdventOfCode.Year2022;

[SkipInputTrim]
public class Day5
{
	private readonly string[] _input;

	public Day5(string input)
	{
		_input = input.ToLines(StringSplitOptions.None);
	}

	public string Part1()
	{
		var (stacks, moves) = Parse();

		foreach (var move in moves)
		{
			for (int i = 0; i < move.Count; i++)
			{
				stacks[move.To].Push(stacks[move.From].Pop());
			}
		}

		return stacks.Aggregate(
			new StringBuilder(),
			(sb, c) => sb.Append(c.Peek()),
			sb => sb.ToString());
	}

	public string Part2()
	{
		var (stacks, moves) = Parse();
		var crane = new Stack<char>();

		foreach (var move in moves)
		{
			for (int i = 0; i < move.Count; i++)
			{
				crane.Push(stacks[move.From].Pop());
			}

			while (crane.TryPop(out var c))
			{
				stacks[move.To].Push(c);
			}
		}

		return stacks.Aggregate(
			new StringBuilder(),
			(sb, c) => sb.Append(c.Peek()),
			sb => sb.ToString());
	}

	private readonly record struct Move(int Count, int From, int To)
	{
		public static Move Parse(string line)
		{
			var m = Regex.Match(line, @"^move (\d+) from (\d+) to (\d+)$");
			var c = m.Groups[1].Value.ToInt32();
			var f = m.Groups[2].Value.ToInt32();
			var t = m.Groups[3].Value.ToInt32();

			return new(c, f - 1, t - 1);
		}
	}

	private (Stack<char>[], Move[]) Parse()
	{
		var sep = Array.IndexOf(_input, "");
		var num = _input[sep - 1]
			.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
			.Last()
			.ToInt32();

		var stacks = Enumerable.Range(0, num)
			.Select(x => new Stack<char>())
			.ToArray();

		for (int i = sep - 2; i >= 0; i--)
		{
			for (int n = 0; n < num; n++)
			{
				var c = _input[i][1 + n * 4];

				if (c != ' ')
				{
					stacks[n].Push(c);
				}
			}
		}

		var moves = _input
			.Where(line => line.StartsWith("move"))
			.Select(Move.Parse)
			.ToArray();

		return (stacks, moves);
	}
}
