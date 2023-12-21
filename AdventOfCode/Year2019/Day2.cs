namespace AdventOfCode.Year2019;

public class Day2
{
	private readonly string _input;

	public Day2(string input)
	{
		_input = input;
	}

	public async Task<BigInteger> Part1()
	{
		var intcode = new IntcodeComputer(_input);
		intcode.Set(1, 12);
		intcode.Set(2, 2);
		await intcode.RunAsync();

		return intcode.Get(0);
	}

	public async Task<int> Part2()
	{
		for (int noun = 0; noun < 100; noun++)
		{
			for (int verb = 0; verb < 100; verb++)
			{
				var intcode = new IntcodeComputer(_input);
				intcode.Set(1, noun);
				intcode.Set(2, verb);
				await intcode.RunAsync();

				if (intcode.Get(0) == 19690720)
				{
					return (noun * 100) + verb;
				}
			}
		}

		throw new Exception("not found");
	}
}
