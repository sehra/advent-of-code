using System.Runtime.InteropServices;

namespace AdventOfCode.Year2015;

public class Day19(string[] input)
{
	public int Part1()
	{
		var (maps, mol) = Parse();
		var seen = new HashSet<string>();

		foreach (var (src, dst) in maps)
		{
			var length = src.Length;
			var offset = 0;

			while ((offset = mol.IndexOf(src, offset)) != -1)
			{
				seen.Add(mol.Remove(offset, length).Insert(offset, dst));
				offset += length;
			}
		}

		return seen.Count;
	}

	public int Part2()
	{
		var (maps, mol) = Parse();
		var target = mol;
		var count = 0;

		while (target != "e")
		{
			var start = target;

			foreach (var (src, dst) in maps)
			{
				var index = target.IndexOf(dst);

				if (index != -1)
				{
					target = target.Remove(index, dst.Length).Insert(index, src);
					count++;
				}
			}

			if (target == start)
			{
				Random.Shared.Shuffle(CollectionsMarshal.AsSpan(maps));
				target = mol;
				count = 0;
			}
		}

		return count;
	}

	private (List<(string Src, string Dst)>, string Mol) Parse()
	{
		var mapping = new List<(string, string)>();

		foreach (var line in input)
		{
			if (line.Contains("=>"))
			{
				var split = line.Split("=>", StringSplitOptions.TrimEntries);
				mapping.Add((split[0], split[1]));
			}
		}

		return (mapping, input[^1]);
	}
}
