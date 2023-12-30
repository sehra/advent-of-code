using System.Text;

namespace AdventOfCode.Year2016;

public class Day16(string input)
{
	public string Part1(int length = 272) => Solve(length);

	public string Part2() => Solve(35651584);

	private string Solve(int length)
	{
		var value = DragonCurve(input);

		while (value.Length < length)
		{
			value = DragonCurve(value);
		}

		var checksum = Checksum(value[..length]);

		while (checksum.Length % 2 == 0)
		{
			checksum = Checksum(checksum);
		}

		return checksum;
	}

	private static string DragonCurve(string a)
	{
		var b = a.Reverse().Select(c => c is '1' ? '0' : '1');

		return new string([.. a, '0', .. b]);
	}

	private static string Checksum(string a)
	{
		var sb = new StringBuilder();

		for (var i = 0; i < a.Length - 1; i += 2)
		{
			sb.Append(a[i] == a[i + 1] ? '1' : '0');
		}

		return sb.ToString();
	}
}
