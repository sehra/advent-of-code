namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day25Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day25).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day25.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd();
	}

	[Benchmark]
	public long Part1() => new Day25(_input).Part1();

	[Benchmark]
	public string Part2() => new Day25(_input).Part2();
}
