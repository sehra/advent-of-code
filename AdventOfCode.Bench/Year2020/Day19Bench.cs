namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day19Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day19).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day19.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd();
	}

	[Benchmark]
	public int Part1() => new Day19(_input).Part1();

	[Benchmark]
	public int Part2() => new Day19(_input).Part2();
}
