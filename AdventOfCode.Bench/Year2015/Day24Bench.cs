namespace AdventOfCode.Year2015;

[MemoryDiagnoser]
public class Day24Bench
{
	private long[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2015, 24).ToLines().ToInt64();
	}

	[Benchmark]
	public long Part1() => new Day24(_input).Part1();

	[Benchmark]
	public long Part2() => new Day24(_input).Part2();
}
