namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day21Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2020, 21);
	}

	[Benchmark]
	public int Part1() => new Day21(_input).Part1();

	[Benchmark]
	public string Part2() => new Day21(_input).Part2();
}
