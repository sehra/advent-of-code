namespace AdventOfCode.Year2015;

public class Day11(string input)
{
	public string Part1() => Solve(input);

	public string Part2() => Solve(Solve(input));

	private static string Solve(string input)
	{
		const int max = 'z' - 'a';
		var password = input.Select(c => c - 'a').ToArray();

		while (Increment() && !IsValid())
		{
			// loop
		}

		return new string([.. password.Select(c => (char)(c + 'a'))]);

		bool IsValid()
		{
			var cond1 = password.Window(3).Any(g => g[0] + 1 == g[1] && g[1] + 1 == g[2]);
			var cond2 = !password.Any(c => c == 'i' - 'a' || c == 'o' - 'a' || c == 'l' - 'a');
			var cond3 = 0;

			for (int i = 0; i < password.Length - 1; i++)
			{
				if (password[i] == password[i + 1])
				{
					cond3++;
					i++;
				}

				if (cond3 == 2)
				{
					break;
				}
			}

			return cond1 && cond2 && cond3 == 2;
		}

		bool Increment()
		{
			password[^1]++;

			for (var i = password.Length - 1; i >= 0; i--)
			{
				if (password[i] > max)
				{
					password[i - 1] += password[i] - max;
					password[i] = 0;
				}
				else
				{
					break;
				}
			}

			return true;
		}
	}
}
