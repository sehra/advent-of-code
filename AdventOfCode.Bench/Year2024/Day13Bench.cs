namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day13Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 13).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day13(_input).Part1();

	[Benchmark]
	public long Part2() => new Day13(_input).Part2();
}
