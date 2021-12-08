namespace AdventOfCode.Year2021;

public class Day8
{
	private readonly string[] _input;

	public Day8(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		return _input
			.SelectMany(line => line.Split(" | ")[1].Split(' '))
			.Count(part => part.Length is 2 or 3 or 4 or 7);
	}

	public int Part2()
	{
		return _input
			.Select(line => line.Split(" | "))
			.Select(line =>
			{
				var inputs = line[0].Split(' ');
				var wires1 = inputs.Single(x => x.Length is 2);
				var wires4 = inputs.Single(x => x.Length is 4);

				return line[1].Split(' ')
					.Aggregate(0, (number, digit) =>
					{
						var length = digit.Length;
						var match1 = digit.Count(x => wires1.Contains(x));
						var match4 = digit.Count(x => wires4.Contains(x));

						return number * 10 + (length, match4, match1) switch
						{
							(2, _, _) => 1,
							(3, _, _) => 7,
							(4, _, _) => 4,
							(7, _, _) => 8,
							(5, 2, _) => 2,
							(5, 3, 1) => 5,
							(5, 3, 2) => 3,
							(6, 4, _) => 9,
							(6, 3, 1) => 6,
							(6, 3, 2) => 0,
							_ => throw new Exception("digit?"),
						};
					});
			})
			.Sum();
	}
}
