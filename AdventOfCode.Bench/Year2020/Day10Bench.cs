using System.IO;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2020
{
	[MemoryDiagnoser]
	public class Day10Bench
	{
		private string _input;

		[GlobalSetup]
		public void Setup()
		{
			using var stream = typeof(Day10).Assembly
				.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day10.txt");
			using var reader = new StreamReader(stream);
			_input = reader.ReadToEnd();
		}

		[Benchmark]
		public int Part1() => new Day10(_input).Part1();

		[Benchmark]
		public long Part2() => new Day10(_input).Part2();
	}
}
