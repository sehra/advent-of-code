using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2016;

public class Day14(string input)
{
	public int Part1() => Solve(GetHash);

	public int Part2() => Solve(GetStrechedHash);

	private static int Solve(Func<int, string> hasher) => Enumerable
		.Range(0, Int32.MaxValue)
		.Select(i => (Index: i, Hash: hasher(i)))
		.Window(1001)
		.Select(w => (w[0].Index, Hashes: w, Triple: FindTriple(w[0].Hash)))
		.Where(x => x.Triple.HasValue)
		.Where(x => x.Hashes.Skip(1).Any(y => HasFiveOf(y.Hash, x.Triple.Value)))
		.Take(64)
		.Last()
		.Index;

	private static char? FindTriple(string hash)
	{
		for (int i = 0; i < hash.Length - 2; i++)
		{
			if (hash[i] == hash[i + 1] &&
				hash[i] == hash[i + 2])
			{
				return hash[i];
			}
		}

		return null;
	}

	private static bool HasFiveOf(string hash, char c)
	{
		for (int i = 0; i < hash.Length - 4; i++)
		{
			if (hash[i] == c &&
				hash[i + 1] == c &&
				hash[i + 2] == c &&
				hash[i + 3] == c &&
				hash[i + 4] == c)
			{
				return true;
			}
		}

		return false;
	}

	private string GetStrechedHash(int value)
	{
		var hash = GetHash(value);

		for (int i = 0; i < 2016; i++)
		{
			var temp = MD5.HashData(Encoding.ASCII.GetBytes(hash));
			hash = Convert.ToHexString(temp).ToLowerInvariant();
		}

		return hash;
	}

	private string GetHash(int value)
	{
		var data = $"{input}{value}";
		var hash = MD5.HashData(Encoding.ASCII.GetBytes(data));

		return Convert.ToHexString(hash).ToLowerInvariant();
	}
}
