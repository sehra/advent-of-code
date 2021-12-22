using System.Numerics;

namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day22Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 22).ToLines();
	}

	[Benchmark]
	public BigInteger Part1() => new Day22(_input).Part1();

	[Benchmark]
	public BigInteger Part2() => new Day22(_input).Part2();
}
