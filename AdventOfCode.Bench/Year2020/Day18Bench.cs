namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day18Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day18).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day18.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd();
	}

	[Benchmark]
	public long Part1() => new Day18(_input).Part1();

	[Benchmark]
	public long Part2() => new Day18(_input).Part2();
}
