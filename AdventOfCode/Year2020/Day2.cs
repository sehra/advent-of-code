namespace AdventOfCode.Year2020;

public class Day2
{
	private readonly string[] _input;

	public Day2(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var valid = 0;
		var regex = new Regex(@"^(\d+)-(\d+) (\w): (.*)$");

		foreach (var match in _input.Select(line => regex.Match(line)))
		{
			var lowest = match.Groups[1].Value.ToInt32();
			var highest = match.Groups[2].Value.ToInt32();
			var letter = match.Groups[3].Value[0];
			var password = match.Groups[4].Value;

			var count = password.Count(c => c == letter);

			if (count >= lowest && count <= highest)
			{
				valid++;
			}
		}

		return valid;
	}

	public int Part2()
	{
		var valid = 0;
		var regex = new Regex(@"^(\d+)-(\d+) (\w): (.*)$");

		foreach (var match in _input.Select(line => regex.Match(line)))
		{
			var index1 = match.Groups[1].Value.ToInt32() - 1;
			var index2 = match.Groups[2].Value.ToInt32() - 1;
			var letter = match.Groups[3].Value[0];
			var password = match.Groups[4].Value;

			if ((password[index1] == letter && password[index2] != letter) ||
				(password[index1] != letter && password[index2] == letter))
			{
				valid++;
			}
		}

		return valid;
	}
}
