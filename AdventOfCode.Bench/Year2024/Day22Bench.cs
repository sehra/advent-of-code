namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day22Bench
{
	private int[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 22).ToLines().ToInt32();
	}

	[Benchmark]
	public long Part1() => new Day22(_input).Part1();

	[Benchmark]
	public long Part2() => new Day22(_input).Part2();
}
