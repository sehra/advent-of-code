namespace AdventOfCode.Year2018;

public class Day2(string[] input)
{
	public int Part1()
	{
		var count2 = 0;
		var count3 = 0;

		foreach (var line in input)
		{
			var counts = line
				.Group()
				.Select(g => g.Count())
				.ToList();

			if (counts.Contains(2))
			{
				count2++;
			}

			if (counts.Contains(3))
			{
				count3++;
			}
		}

		return count2 * count3;
	}

	public string Part2()
	{
		for (int i = 0; i < input.Length; i++)
		{
			for (int j = i + 1; j < input.Length; j++)
			{
				var a = input[i];
				var b = input[j];

				var check = a.Zip(b)
					.Count(p => p.First != p.Second);

				if (check is 1)
				{
					return new([.. a.Zip(b).Where(p => p.First == p.Second).Select(p => p.First)]);
				}
			}
		}

		throw new Exception("not found");
	}
}
