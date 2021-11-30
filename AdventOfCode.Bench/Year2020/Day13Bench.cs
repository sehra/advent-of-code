namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day13Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day13).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day13.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd();
	}

	[Benchmark]
	public int Part1() => new Day13(_input).Part1();

	[Benchmark]
	public long Part2() => new Day13(_input).Part2();
}
