namespace AdventOfCode.Year2017;

public class Day14(string input)
{
	public int Part1() => Enumerable
		.Range(0, 128)
		.Select(i => KnotHash($"{input}-{i}"))
		.Sum(hash => hash.Count(c => c is '1'));

	public int Part2()
	{
		var grid = Enumerable
			.Range(0, 128)
			.Select(i => KnotHash($"{input}-{i}").ToCharArray())
			.ToArray();
		var count = 0;

		for (int r = 0; r < grid.Length; r++)
		{
			for (int c = 0; c < grid[r].Length; c++)
			{
				if (grid[r][c] is '1')
				{
					foreach (var (sr, sc) in Flood(new(r, c)))
					{
						grid[sr][sc] = '0';
					}

					count++;
				}
			}
		}

		return count;

		HashSet<Point> Flood(Point start)
		{
			var seen = new HashSet<Point>();
			var work = new Queue<Point>();
			work.Enqueue(start);

			while (work.TryDequeue(out var curr))
			{
				if (!seen.Add(curr))
				{
					continue;
				}

				foreach (var dir in "UDLR")
				{
					var next = curr.Step(dir);

					if (0 <= next.Row && next.Row < grid.Length &&
						0 <= next.Col && next.Col < grid[next.Row].Length &&
						grid[next.Row][next.Col] is '1')
					{
						work.Enqueue(next);
					}
				}
			}

			return seen;
		}
	}

	private readonly record struct Point(int Row, int Col)
	{
		public Point Step(char dir) => dir switch
		{
			'U' => new(Row - 1, Col),
			'D' => new(Row + 1, Col),
			'L' => new(Row, Col - 1),
			'R' => new(Row, Col + 1),
			_ => throw new Exception("dir?"),
		};
	}

	private static string KnotHash(string input)
	{
		var hash = Enumerable.Range(0, 256).ToArray();
		var curr = 0;
		var skip = 0;

		for (int round = 0; round < 64; round++)
		{
			foreach (var length in input.Select(c => (int)c).Concat([17, 31, 73, 47, 23]))
			{
				foreach (var (index, value) in hash.Repeat().Skip(curr).Take(length).Reverse().Index())
				{
					hash[(curr + index) % hash.Length] = value;
				}

				curr = (curr + length + skip) % hash.Length;
				skip++;
			}
		}

		return hash
			.Chunk(16)
			.Select(chunk => chunk.Aggregate((a, b) => a ^ b))
			.ToString((sb, value) => sb.Append($"{value:B8}"));
	}
}
