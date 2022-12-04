namespace AdventOfCode.Year2022;

public class Day3
{
	private readonly string[] _input;

	public Day3(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var total = 0;

		foreach (var line in _input)
		{
			var a = line[..(line.Length / 2)];
			var b = line[(line.Length / 2)..];
			var v = a.Intersect(b).Single();

			total += Score(v);
		}

		return total;
	}

	public int Part2()
	{
		var total = 0;

		for (int i = 0; i < _input.Length; i += 3)
		{
			var a = _input[i + 0];
			var b = _input[i + 1];
			var c = _input[i + 2];
			var v = a.Intersect(b).Intersect(c).Single();

			total += Score(v);
		}

		return total;
	}

	private static int Score(char value) => value switch
	{
		>= 'a' and <= 'z' => value - 'a' + 1,
		>= 'A' and <= 'Z' => value - 'A' + 27,
		_ => throw new Exception("value?"),
	};
}
