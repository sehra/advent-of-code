using System.Globalization;

namespace AdventOfCode.Year2023;

public class Day18(string[] input)
{
	public long Part1() => Solve(false);

	public long Part2() => Solve(true);

	private long Solve(bool part2)
	{
		// https://en.wikipedia.org/wiki/Green%27s_theorem

		var pos = (x: 0L, y: 0L);
		var perim = 0L;
		var area = 0L;

		foreach (var (dir, len) in Parse(part2))
		{
			var (dx, dy) = dir switch
			{
				'U' or '3' => (0, +len),
				'D' or '1' => (0, -len),
				'L' or '2' => (-len, 0),
				'R' or '0' => (+len, 0),
				_ => throw new Exception("dir?"),
			};

			pos = (pos.x + dx, pos.y + dy);
			perim += len;
			area += pos.y * dx;
		}

		return Math.Abs(area) + perim / 2 + 1;
	}

	private IEnumerable<(char Dir, int Len)> Parse(bool part2) => input
		.Select(line => line.Split())
		.Select(line => part2
			? (line[2][^2], line[2][2..^2].ToInt32(NumberStyles.HexNumber))
			: (line[0][0], line[1].ToInt32()));
}
