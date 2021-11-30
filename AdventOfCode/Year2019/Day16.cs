namespace AdventOfCode.Year2019;

public class Day16
{
	private readonly string _input;

	public Day16(string input)
	{
		_input = input;
	}

	public string Part1(int phases = 100)
	{
		var pattern = new[] { 0, 1, 0, -1 };
		var result = _input.Select(CharToInt).ToArray();

		for (int phase = 0; phase < phases; phase++)
		{
			for (int i = 0; i < result.Length; i++)
			{
				var sum = 0;

				for (int j = 0; j < result.Length; j++)
				{
					sum += result[j] * pattern[(j + 1) / (i + 1) % 4];
				}

				result[i] = Math.Abs(sum) % 10;
			}
		}

		return new string(result.Take(8).Select(IntToChar).ToArray());
	}

	public string Part2()
	{
		var offset = Int32.Parse(_input.AsSpan(0, 7));
		var result = _input.Repeat(10000).Skip(offset).Select(CharToInt).ToArray();

		for (int phase = 0; phase < 100; phase++)
		{
			var sum = result.Sum();

			for (int i = 0; i < result.Length; i++)
			{
				var prev = sum;
				sum -= result[i];
				result[i] = prev % 10;
			}
		}

		return new string(result.Take(8).Select(IntToChar).ToArray());
	}

	static int CharToInt(char v) => v - '0';
	static char IntToChar(int v) => (char)(v + '0');
}
