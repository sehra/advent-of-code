using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2015;

public class Day4(string input)
{
	public int Part1() => Solve(5);

	public int Part2() => Solve(6);

	public int Solve(int count)
	{
		var data = new byte[input.Length + 10];
		var dlen = Encoding.ASCII.GetBytes(input, data);
		var hash = new byte[MD5.HashSizeInBytes];

		for (int i = 609043; i < Int32.MaxValue; i++)
		{
			i.TryFormat(data.AsSpan(dlen), out var ilen);
			MD5.HashData(data.AsSpan(0, dlen + ilen), hash);

			if (hash[0] is 0 && hash[1] is 0)
			{
				if (count is 5 && (hash[2] & 0xF0) == 0x00)
				{
					return i;
				}
				else if (count is 6 && hash[2] is 0)
				{
					return i;
				}
			}
		}

		throw new Exception("not found");
	}
}
