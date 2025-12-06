namespace AdventOfCode.Year2025;

[SkipInputTrim]
public class Day6(string input)
{
	public long Part1() => Parse()
		.Sum(x => x.Oper switch
		{
			'+' => x.Grid.Select(row => row.ToInt64()).Sum(),
			'*' => x.Grid.Select(row => row.ToInt64()).Multiply(),
			_ => throw new Exception("oper?"),
		});

	public long Part2() => Parse()
		.Sum(x =>
		{
			var nums = Enumerable.Range(0, x.Grid[0].Length)
				.Select(col => String.Concat(x.Grid.Select(row => row[col])).ToInt64());

			return x.Oper switch
			{
				'+' => nums.Sum(),
				'*' => nums.Multiply(),
				_ => throw new Exception("oper?"),
			};
		});

	private (string[] Grid, char Oper)[] Parse()
	{
		var lines = input.ToLines(StringSplitOptions.RemoveEmptyEntries);

		return [.. lines
			.Last()
			.Index()
			.Where(x => x.Item != ' ')
			.Select(x => x.Index)
			.Append(lines.Last().Length + 1)
			.TupleWindow2()
			.Select(pair =>
			{
				var (prev, curr) = pair;
				var grid = lines
					.SkipLast(1)
					.Select(line => line[prev..(curr - 1)])
					.ToArray();
				var oper = lines.Last()[prev];
				return (grid, oper);
			})];
	}
}
