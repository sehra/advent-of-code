namespace AdventOfCode.Year2015;

public class Day6(string[] input)
{
	public int Part1() => Solve<bool>(_ => true, _ => false, v => !v, v => v ? 1 : 0);

	public int Part2() => Solve<int>(v => v + 1, v => Math.Max(0, v - 1), v => v + 2, v => v);

	private int Solve<T>(Func<T, T> turnOn, Func<T, T> turnOff, Func<T, T> toggle, Func<T, int> count)
	{
		var lights = new T[1000, 1000];

		foreach (var line in input)
		{
			var nums = Regex
				.Matches(line, @"\d+")
				.Select(m => m.ValueSpan.ToInt32())
				.ToArray();

			if (line.StartsWith("turn on"))
			{
				Do(nums[0], nums[2], nums[1], nums[3], turnOn);
			}
			else if (line.StartsWith("turn off"))
			{
				Do(nums[0], nums[2], nums[1], nums[3], turnOff);
			}
			else if (line.StartsWith("toggle"))
			{
				Do(nums[0], nums[2], nums[1], nums[3], toggle);
			}
		}

		var level = 0;

		for (int x = 0; x < lights.GetLength(0); x++)
		{
			for (int y = 0; y < lights.GetLength(1); y++)
			{
				level += count(lights[x, y]);
			}
		}

		return level;

		void Do(int xmin, int xmax, int ymin, int ymax, Func<T, T> func)
		{
			for (int x = xmin; x <= xmax; x++)
			{
				for (int y = ymin; y <= ymax; y++)
				{
					lights[x, y] = func(lights[x, y]);
				}
			}
		}
	}
}
