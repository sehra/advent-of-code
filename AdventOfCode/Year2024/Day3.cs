namespace AdventOfCode.Year2024;

public partial class Day3(string input)
{
	public int Part1()
	{
		var result = 0;

		foreach (Match match in MulRegex().Matches(input))
		{
			var a = match.Groups["a"].ValueSpan.ToInt32();
			var b = match.Groups["b"].ValueSpan.ToInt32();
			result += a * b;
		}

		return result;
	}

	public int Part2()
	{
		var result = 0;
		var enabled = true;

		foreach (Match match in InsRegex().Matches(input))
		{
			if (enabled && match.Groups["m"].Success)
			{
				var a = match.Groups["a"].ValueSpan.ToInt32();
				var b = match.Groups["b"].ValueSpan.ToInt32();
				result += a * b;
			}
			else if (match.Groups["e"].Success)
			{
				enabled = true;
			}
			else if (match.Groups["d"].Success)
			{
				enabled = false;
			}
		}

		return result;
	}

	[GeneratedRegex(@"mul\((?<a>\d{1,3}),(?<b>\d{1,3})\)")]
	private static partial Regex MulRegex();

	[GeneratedRegex(@"(?<m>mul\((?<a>\d{1,3}),(?<b>\d{1,3})\))|(?<e>do\(\))|(?<d>don't\(\))")]
	private static partial Regex InsRegex();
}
