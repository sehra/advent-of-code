using System.Data;

namespace AdventOfCode.Year2015;

public class Day8(string[] input)
{
	public int Part1()
	{
		var code = 0;
		var data = 0;

		foreach (var line in input)
		{
			var span = line.AsSpan();
			code += span.Length;

			for (int i = 1; i < span.Length - 1; i++)
			{
				if (span[i] is '\\')
				{
					if (span[i + 1] is 'x')
					{
						data++;
						i += 3;
					}
					else
					{
						data++;
						i++;
					}
				}
				else
				{
					data++;
				}
			}
		}

		return code - data;
	}

	public int Part2()
	{
		var code = 0;
		var data = 0;

		foreach (var line in input)
		{
			var span = line.AsSpan();
			data += span.Length;
			code += 2 + span.Length + span.Count('"') + span.Count('\\');
		}

		return code - data;
	}
}
