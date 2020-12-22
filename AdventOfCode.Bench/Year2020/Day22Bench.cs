using System.IO;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2020
{
	[MemoryDiagnoser]
	public class Day22Bench
	{
		private string _input;

		[GlobalSetup]
		public void Setup()
		{
			using var stream = typeof(Day22).Assembly
				.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day22.txt");
			using var reader = new StreamReader(stream);
			_input = reader.ReadToEnd();
		}

		[Benchmark]
		public int Part1() => new Day22(_input).Part1();

		[Benchmark]
		public int Part2() => new Day22(_input).Part2();
	}
}
