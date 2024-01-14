namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day15Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 15).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day15(_input).Part1();

	[Benchmark]
	public int Part2() => new Day15(_input).Part2();
}
