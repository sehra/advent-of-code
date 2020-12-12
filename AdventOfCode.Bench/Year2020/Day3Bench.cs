using System.IO;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2020
{
	[MemoryDiagnoser]
	public class Day3Bench
	{
		private string _input;

		[GlobalSetup]
		public void Setup()
		{
			using var stream = typeof(Day3).Assembly
				.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day3.txt");
			using var reader = new StreamReader(stream);
			_input = reader.ReadToEnd();
		}

		[Benchmark]
		public long Part1() => new Day3(_input).Part1();

		[Benchmark]
		public long Part2() => new Day3(_input).Part2();
	}
}
