namespace AdventOfCode.Year2022;

public class Day2
{
	private readonly string[] _input;

	public Day2(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var total = 0;

		foreach (var line in _input)
		{
			total += Score(Translate(line[0]), Translate(line[2]));
		}

		return total;
	}

	public int Part2()
	{
		var total = 0;

		foreach (var line in _input)
		{
			var player1 = Translate(line[0]);
			var player2 = line[2] switch
			{
				'X' => Lose(player1),
				'Y' => player1,
				'Z' => Win(player1),
				_ => throw new Exception("shape?"),
			};

			total += Score(player1, player2);
		}

		return total;

		static char Win(char c) => c switch
		{
			'R' => 'P',
			'P' => 'S',
			'S' => 'R',
			_ => throw new Exception("shape?"),
		};

		static char Lose(char c) => c switch
		{
			'R' => 'S',
			'P' => 'R',
			'S' => 'P',
			_ => throw new Exception("shape?"),
		};
	}

	private static char Translate(char shape) => shape switch
	{
		'A' => 'R',
		'B' => 'P',
		'C' => 'S',
		'X' => 'R',
		'Y' => 'P',
		'Z' => 'S',
		_ => throw new Exception("shape?"),
	};

	private static int Score(char player1, char player2) => (player1, player2) switch
	{
		('R', 'R') => 3 + 1,
		('R', 'P') => 6 + 2,
		('R', 'S') => 0 + 3,
		('P', 'R') => 0 + 1,
		('P', 'P') => 3 + 2,
		('P', 'S') => 6 + 3,
		('S', 'R') => 6 + 1,
		('S', 'P') => 0 + 2,
		('S', 'S') => 3 + 3,
		_ => throw new Exception("shape?"),
	};
}
