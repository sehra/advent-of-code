namespace AdventOfCode.Year2023;

public class Day3(string[] input)
{
	public int Part1()
	{
		var (numbers, symbols) = Parse();
		var result = 0;

		foreach (var (position, symbol) in symbols)
		{
			foreach (var (x, y) in Adjacent(position))
			{
				var range = numbers[y].Find(r => r.Start.Value <= x && x < r.End.Value);

				if (!range.Equals(default))
				{
					result += input[y].AsSpan(range).ToInt32();
					numbers[y].Remove(range);
				}
			}
		}

		return result;
	}

	public int Part2()
	{
		var (numbers, symbols) = Parse();
		var result = 0;

		foreach (var (position, symbol) in symbols.Where(kv => kv.Value is '*'))
		{
			var found = new HashSet<(int Y, Range Range)>();

			foreach (var (x, y) in Adjacent(position))
			{
				var range = numbers[y].Find(r => r.Start.Value <= x && x < r.End.Value);

				if (!range.Equals(default))
				{
					found.Add((y, range));
				}
			}

			if (found.Count is 2)
			{
				result += found.Select(num => input[num.Y].AsSpan(num.Range).ToInt32()).Multiply();
			}
		}

		return result;
	}

	private static IEnumerable<(int X, int Y)> Adjacent((int X, int Y) p)
	{
		yield return (p.X - 1, p.Y - 1);
		yield return (p.X - 1, p.Y);
		yield return (p.X - 1, p.Y + 1);
		yield return (p.X, p.Y - 1);
		yield return (p.X, p.Y + 1);
		yield return (p.X + 1, p.Y - 1);
		yield return (p.X + 1, p.Y);
		yield return (p.X + 1, p.Y + 1);
	}

	private (Dictionary<int, List<Range>> Numbers, Dictionary<(int X, int Y), char> Symbols) Parse()
	{
		var numbers = new Dictionary<int, List<Range>>();
		var symbols = new Dictionary<(int X, int Y), char>();

		for (int y = 0; y < input.Length; y++)
		{
			var ranges = new List<Range>();

			for (int x = 0; x < input[y].Length; x++)
			{
				var span = input[y].AsSpan(x);

				if (Char.IsDigit(span[0]))
				{
					var length = span.IndexOfAnyExceptInRange('0', '9');

					if (length is -1)
					{
						length = span.Length;
					}

					ranges.Add(new(x, x + length));
					x += length - 1;
				}
				else if (span[0] is not '.')
				{
					symbols.Add((x, y), span[0]);
				}
			}

			numbers.Add(y, ranges);
		}

		return (numbers, symbols);
	}
}
