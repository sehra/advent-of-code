namespace AdventOfCode.Year2015;

[MemoryDiagnoser]
public class Day7Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2015, 7).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day7(_input).Part1();

	[Benchmark]
	public int Part2() => new Day7(_input).Part2();
}
