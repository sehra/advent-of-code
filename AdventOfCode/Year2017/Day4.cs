namespace AdventOfCode.Year2017;

public class Day4(string[] input)
{
	public int Part1()
	{
		return input
			.Select(line => line.Split())
			.Where(words => words.Group().All(group => group.Count() is 1))
			.Count();
	}

	public int Part2()
	{
		return input
			.Select(line => line.Split())
			.Count(IsValid);

		static bool IsValid(string[] words)
		{
			for (int i = 0; i < words.Length; i++)
			{
				foreach (var perm in words[i].Permutations())
				{
					for (int j = i + 1; j < words.Length; j++)
					{
						if (perm.SequenceEqual(words[j]))
						{
							return false;
						}
					}
				}
			}

			return true;
		}
	}
}
