namespace AdventOfCode.Year2017;

public class Day10(string input)
{
	public int Part1(int size = 256)
	{
		var hash = KnotHash(size, input.Split(',').ToInt32(), 1);

		return hash[0] * hash[1];
	}

	public string Part2() =>
		KnotHash(256, [.. input.Select(c => (int)c).Concat([17, 31, 73, 47, 23])], 64)
			.Chunk(16)
			.Select(chunk => chunk.Aggregate((a, b) => a ^ b))
			.ToString((sb, value) => sb.Append($"{value:x2}"));

	private static int[] KnotHash(int size, int[] lenghts, int rounds)
	{
		var hash = Enumerable.Range(0, size).ToArray();
		var curr = 0;
		var skip = 0;

		for (int round = 0; round < rounds; round++)
		{
			foreach (var length in lenghts)
			{
				foreach (var (index, value) in hash.Repeat().Skip(curr).Take(length).Reverse().Index())
				{
					hash[(curr + index) % hash.Length] = value;
				}

				curr = (curr + length + skip) % hash.Length;
				skip++;
			}
		}

		return hash;
	}
}
