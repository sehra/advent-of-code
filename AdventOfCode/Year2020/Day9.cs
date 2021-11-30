namespace AdventOfCode.Year2020;

public class Day9
{
	private readonly long[] _input;

	public Day9(string input)
	{
		_input = input.ToLines().Select(Int64.Parse).ToArray();
	}

	public long Part1(int size = 25)
	{
		foreach (var window in _input.Window(size + 1))
		{
			var target = window.Last();

			if (!HasSum(target))
			{
				return target;
			}

			bool HasSum(long sum)
			{
				for (int i = 0; i < size; i++)
				{
					for (int j = 0; j < size; j++)
					{
						var a = window[i];
						var b = window[j];

						if (a != b && (a + b == sum))
						{
							return true;
						}
					}
				}

				return false;
			}
		}

		throw new Exception("not found");
	}

	public long Part2(int size = 25)
	{
		var target = Part1(size);

		for (int i = 0; i < _input.Length; i++)
		{
			var sum = _input[i];

			for (int j = i + 1; j < _input.Length; j++)
			{
				sum += _input[j];

				if (sum > target)
				{
					break;
				}
				else if (sum == target)
				{
					var slice = _input.Skip(i).Take(j - i);
					return slice.Min() + slice.Max();
				}
			}
		}

		throw new Exception("not found");
	}
}
