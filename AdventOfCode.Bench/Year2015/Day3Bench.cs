namespace AdventOfCode.Year2015;

[MemoryDiagnoser]
public class Day3Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2015, 3);
	}

	[Benchmark]
	public int Part1() => new Day3(_input).Part1();

	[Benchmark]
	public int Part2() => new Day3(_input).Part2();
}
