namespace AdventOfCode.Year2021;

public class Day10
{
	private readonly string[] _input;

	public Day10(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var total = 0;

		foreach (var line in _input)
		{
			var (stack, corrupt) = Parse(line);

			if (corrupt)
			{
				total += stack.Peek() switch
				{
					')' => 3,
					']' => 57,
					'}' => 1197,
					'>' => 25137,
					_ => throw new Exception("char?"),
				};
			}
		}

		return total;
	}

	public long Part2()
	{
		var scores = new List<long>();

		foreach (var line in _input)
		{
			var (stack, corrupt) = Parse(line);

			if (!corrupt)
			{
				long score = 0;

				while (stack.TryPop(out var c))
				{
					score *= 5;
					score += c switch
					{
						'(' => 1,
						'[' => 2,
						'{' => 3,
						'<' => 4,
						_ => throw new Exception("char?"),
					};
				}

				scores.Add(score);
			}
		}

		scores.Sort();

		return scores[scores.Count / 2];
	}

	private static (Stack<char> Stack, bool Corrupt) Parse(string line)
	{
		var stack = new Stack<char>();
		var corrupt = false;
		
		foreach (var c in line)
		{
			if (c is '(' or '[' or '{' or '<')
			{
				stack.Push(c);
			}
			else
			{
				corrupt = (stack.Peek(), c) switch
				{
					('(', ')') => false,
					('[', ']') => false,
					('{', '}') => false,
					('<', '>') => false,
					_ => true,
				};

				if (corrupt)
				{
					stack.Push(c);
					break;
				}

				stack.Pop();
			}
		}

		return (stack, corrupt);
	}
}
