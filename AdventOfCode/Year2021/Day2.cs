namespace AdventOfCode.Year2021;

public class Day2
{
	private readonly string[] _input;

	public Day2(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var (horiz, depth) = _input
			.Select(line => line.Split())
			.Select(line => (Command: line[0][0], Units: line[1].ToInt32()))
			.Aggregate(
				(Horiz: 0, Depth: 0),
				(acc, cmd) => cmd.Command switch
				{
					'f' => acc with { Horiz = acc.Horiz + cmd.Units },
					'd' => acc with { Depth = acc.Depth + cmd.Units },
					'u' => acc with { Depth = acc.Depth - cmd.Units },
					_ => throw new InvalidOperationException(),
				}
			);

		return horiz * depth;
	}

	public int Part2()
	{
		var (horiz, depth, _) = _input
			.Select(line => line.Split())
			.Select(line => (Command: line[0][0], Units: line[1].ToInt32()))
			.Aggregate(
				(Horiz: 0, Depth: 0, Aim: 0),
				(acc, cmd) => cmd.Command switch
				{
					'f' => acc with
					{
						Horiz = acc.Horiz + cmd.Units,
						Depth = acc.Depth + acc.Aim * cmd.Units,
					},
					'd' => acc with { Aim = acc.Aim + cmd.Units },
					'u' => acc with { Aim = acc.Aim - cmd.Units },
					_ => throw new InvalidOperationException(),
				}
			);

		return horiz * depth;
	}
}
