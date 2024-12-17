namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day17Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 17).ToLines();
	}

	[Benchmark]
	public string Part1() => new Day17(_input).Part1();

	[Benchmark]
	public long Part2() => new Day17(_input).Part2();
}
