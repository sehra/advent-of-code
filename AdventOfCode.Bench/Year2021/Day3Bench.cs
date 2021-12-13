namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day3Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 3).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day3(_input).Part1();

	[Benchmark]
	public int Part2() => new Day3(_input).Part2();
}
