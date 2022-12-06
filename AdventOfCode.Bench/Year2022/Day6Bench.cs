namespace AdventOfCode.Year2022;

[MemoryDiagnoser]
public class Day6Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2022, 6);
	}

	[Benchmark]
	public int Part1() => new Day6(_input).Part1();

	[Benchmark]
	public int Part2() => new Day6(_input).Part2();
}
