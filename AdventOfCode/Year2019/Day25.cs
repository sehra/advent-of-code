using System.Text;
using System.Threading.Channels;

namespace AdventOfCode.Year2019;

public class Day25
{
	private readonly string _input;

	public Day25(string input)
	{
		_input = input;
	}

	public async Task<int> Part1()
	{
		var signal = new SemaphoreSlim(0);
		var input = Channel.CreateUnbounded<BigInteger>();
		var output = new List<char>();
		var intcode = new IntcodeComputer(_input)
		{
			Input = () => input.Reader.ReadAsync().AsTask(),
			Output = value => { output.Add((char)value); return Task.CompletedTask; },
		};

		var commands = new[]
		{
			"east",
			"take whirled peas",
			"north",
			"west",
			"south",
			"take antenna",
			"north",
			"east",
			"south",
			"east",
			"north",
			"take prime number",
			"south",
			"west",
			"west",
			"north",
			"take fixed point",
			"north",
			"east",
			"south",
		};

		foreach (var command in commands)
		{
			foreach (var c in Encoding.ASCII.GetBytes(command))
			{
				input.Writer.TryWrite(c);
			}

			input.Writer.TryWrite('\n');
		}

		await intcode.RunAsync();

		return Int32.Parse(Regex.Match(new string(output.ToArray()), @"(\d{7})").Value);
	}
}
