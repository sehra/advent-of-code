namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day10Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 10).ToLines();
	}

	[Benchmark]
	public string Part1() => new Day10(_input).Part1();

	[Benchmark]
	public int Part2() => new Day10(_input).Part2();
}
