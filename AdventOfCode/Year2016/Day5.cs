using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2016;

public class Day5(string input)
{
	public string Part1()
	{
		var buffer = new byte[input.Length + 10];
		var offset = Encoding.ASCII.GetBytes(input, buffer);
		var password = new char[8];
		var hash = new byte[MD5.HashSizeInBytes];

		for (int index = 0, position = 0; position < 8; index++)
		{
			index.TryFormat(buffer.AsSpan(offset), out var written);
			MD5.HashData(buffer.AsSpan(0, offset + written), hash);

			if (hash[0] == 0 && hash[1] == 0 && (hash[2] & 0xF0) == 0)
			{
				password[position++] = "0123456789abcdef"[hash[2] & 0xF];
			}
		}

		return new string(password);
	}

	public string Part2()
	{
		var buffer = new byte[input.Length + 10];
		var offset = Encoding.ASCII.GetBytes(input, buffer);
		var password = new char[8];
		var hash = new byte[MD5.HashSizeInBytes];

		for (int index = 0, count = 0; count < 8; index++)
		{
			index.TryFormat(buffer.AsSpan(offset), out var written);
			MD5.HashData(buffer.AsSpan(0, offset + written), hash);

			if (hash[0] == 0 && hash[1] == 0 && (hash[2] & 0xF0) == 0)
			{
				var position = hash[2] & 0xF;

				if (position < 8 && password[position] == 0)
				{
					password[position] = "0123456789abcdef"[(hash[3] & 0xF0) >> 4];
					count++;
				}
			}
		}

		return new string(password);
	}
}
