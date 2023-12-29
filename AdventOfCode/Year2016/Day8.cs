using System.Text;

namespace AdventOfCode.Year2016;

public class Day8(string[] input)
{
	public int Part1(int w = 50, int h = 6) =>
		Solve(w, h).Count(c => c is '#');

	public string Part2() => Solve(50, 6);

	private string Solve(int w = 50, int h = 6)
	{
		var display = new char[h, w];
		display.Fill('.');

		foreach (var line in input)
		{
			var nums = GetNums(line);

			if (line.StartsWith("rect"))
			{
				for (int r = 0; r < nums[1]; r++)
				{
					for (int c = 0; c < nums[0]; c++)
					{
						display[r, c] = '#';
					}
				}
			}
			else if (line.StartsWith("rotate row"))
			{
				var tmp = new char[w];

				for (int i = 0; i < w; i++)
				{
					tmp[i] = display[nums[0], (i + w - nums[1]) % w];
				}

				for (int i = 0; i < w; i++)
				{
					display[nums[0], i] = tmp[i];
				}
			}
			else if (line.StartsWith("rotate col"))
			{
				var tmp = new char[h];

				for (int i = 0; i < h; i++)
				{
					tmp[i] = display[(i + h - nums[1]) % h, nums[0]];
				}

				for (int i = 0; i < h; i++)
				{
					display[i, nums[0]] = tmp[i];
				}

			}
		}

		var sb = new StringBuilder();

		for (int r = 0; r < h; r++)
		{
			for (int c = 0; c < w; c++)
			{
				sb.Append(display[r, c]);
			}

			sb.AppendLine();
		}

		return sb.ToString();

		static int[] GetNums(string line) =>
			[.. Regex.Matches(line, @"(\d+)").Select(m => m.ValueSpan.ToInt32())];
	}
}
