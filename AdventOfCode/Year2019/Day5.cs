namespace AdventOfCode.Year2019;

public class Day5
{
	private readonly string _input;

	public Day5(string input)
	{
		_input = input;
	}

	public async Task<BigInteger> Part1()
	{
		var outputs = new List<BigInteger>();
		var intcode = new IntcodeComputer(_input)
		{
			Input = () => Task.FromResult((BigInteger)1),
			Output = value => { outputs.Add(value); return Task.CompletedTask; },
		};
		await intcode.RunAsync();

		return outputs[^1];
	}

	public async Task<BigInteger> Part2()
	{
		var outputs = new List<BigInteger>();
		var intcode = new IntcodeComputer(_input)
		{
			Input = () => Task.FromResult((BigInteger)5),
			Output = value => { outputs.Add(value); return Task.CompletedTask; },
		};
		await intcode.RunAsync();

		return outputs[^1];
	}
}
