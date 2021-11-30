namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day16Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day16).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day16.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd();
	}

	[Benchmark]
	public int Part1() => new Day16(_input).Part1();

	[Benchmark]
	public long Part2() => new Day16(_input).Part2();
}
