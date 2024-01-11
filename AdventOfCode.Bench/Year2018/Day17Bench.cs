namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day17Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 17).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day17(_input).Part1();

	[Benchmark]
	public int Part2() => new Day17(_input).Part2();
}
