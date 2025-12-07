namespace AdventOfCode.Year2025;

public class Day7(string[] input)
{
	public int Part1()
	{
		var beams = new HashSet<int>() { input[0].IndexOf('S') };
		var count = 0;

		foreach (var line in input)
		{
			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] is '^' && beams.Remove(i))
				{
					beams.Add(i - 1);
					beams.Add(i + 1);
					count++;
				}
			}
		}

		return count;
	}

	public long Part2()
	{
		var beams = new Dictionary<int, long>() { [input[0].IndexOf('S')] = 1 };

		foreach (var line in input)
		{
			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] is '^' && beams.Remove(i, out var count))
				{
					beams[i - 1] = beams.GetValueOrDefault(i - 1) + count;
					beams[i + 1] = beams.GetValueOrDefault(i + 1) + count;
				}
			}
		}

		return beams.Values.Sum();
	}
}
