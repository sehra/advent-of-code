namespace AdventOfCode.Year2017;

public class Day16(string input)
{
	public string Part1(int count = 16) => Dance("abcdefghijklmnop"[..count]);

	public string Part2(int count = 16)
	{
		const int n = 1_000_000_000;

		var state = "abcdefghijklmnop"[..count];
		var seen = new HashSet<string>();

		for (int i = 0; i < n; i++)
		{
			if (!seen.Add(state))
			{
				i = n - ((n - i) % i);
			}

			state = Dance(state);
		}

		return state;
	}

	private string Dance(string state)
	{
		var dance = state.ToCharArray();

		foreach (var move in input.Split(','))
		{
			if (move[0] is 's')
			{
				var skip = move.AsSpan(1).ToInt32();
				dance = [.. dance.Repeat().Skip(dance.Length - skip).Take(dance.Length)];
			}
			else if (move[0] is 'x')
			{
				var nums = move[1..].Split('/').ToInt32();
				var temp = dance[nums[0]];
				dance[nums[0]] = dance[nums[1]];
				dance[nums[1]] = temp;
			}
			else if (move[0] is 'p')
			{
				var a = Array.IndexOf(dance, move[1]);
				var b = Array.IndexOf(dance, move[3]);
				dance[a] = move[3];
				dance[b] = move[1];
			}
		}

		return new(dance);
	}
}
