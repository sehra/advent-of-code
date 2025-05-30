namespace AdventOfCode.Year2016;

[MemoryDiagnoser]
public class Day4Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2016, 4).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day4(_input).Part1();

	[Benchmark]
	public int Part2() => new Day4(_input).Part2();
}
