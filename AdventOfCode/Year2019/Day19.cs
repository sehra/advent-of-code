namespace AdventOfCode.Year2019;

public class Day19
{
	private readonly BigInteger[] _input;

	public Day19(string input)
	{
		_input = input.Split(',').Select(BigInteger.Parse).ToArray();
	}

	public async Task<int> Part1()
	{
		var count = 0;

		for (int x = 0; x < 50; x++)
		{
			for (int y = 0; y < 50; y++)
			{
				if (await ScanAsync(x, y))
				{
					count++;
				}
			}
		}

		return count;
	}

	public async Task<int> Part2()
	{
		for (int x = 99, y = 0; x < 10000; x++)
		{
			while (!await ScanAsync(x, y))
			{
				y++;
			}

			if (await ScanAsync(x - 99, y + 99))
			{
				return ((x - 99) * 10000) + y;
			}
		}

		throw new Exception("not found");
	}

	private async Task<bool> ScanAsync(int x, int y)
	{
		Debug.Assert(x >= 0);
		Debug.Assert(y >= 0);

		var first = true;
		var output = 0;

		var intcode = new IntcodeComputer(_input.ToArray())
		{
			Input = () =>
			{
				if (first)
				{
					first = false;
					return Task.FromResult<BigInteger>(x);
				}
				else
				{
					return Task.FromResult<BigInteger>(y);
				}
			},
			Output = value =>
			{
				output = (int)value;

				return Task.CompletedTask;
			},
		};
		await intcode.RunAsync();

		return output == 1;
	}
}
