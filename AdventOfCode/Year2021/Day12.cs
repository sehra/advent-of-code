namespace AdventOfCode.Year2021;

public class Day12
{
	private readonly string[] _input;

	public Day12(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		return Solve(true);
	}

	public int Part2()
	{
		return Solve(false);
	}

	public int Solve(bool part1)
	{
		var caves = Parse();
		var count = 0;

		var work = new Queue<(string Node, HashSet<string> Seen, string Once)>();
		work.Enqueue(("start", ["start"], null));

		while (work.TryDequeue(out var item))
		{
			var (node, seen, once) = item;

			if (node is "end")
			{
				count++;
				continue;
			}

			foreach (var cave in caves[node])
			{
				var copy = false;

				if (IsSmall(cave))
				{
					if (part1 && seen.Contains(cave))
					{
						continue;
					}

					if (cave == once || cave is "start")
					{
						continue;
					}

					if (seen.Contains(cave))
					{
						if (once is not null)
						{
							continue;
						}

						copy = true;
					}
				}

				work.Enqueue((cave, new(seen) { cave }, copy ? cave : once));
			}
		}

		return count;
	}

	private static bool IsSmall(string cave) => Char.IsLower(cave[0]);

	private Dictionary<string, List<string>> Parse()
	{
		var caves = new Dictionary<string, List<string>>();

		foreach (var line in _input.Select(line => line.Split('-')))
		{
			var a = line[0];
			var b = line[1];

			if (caves.TryGetValue(a, out var links))
			{
				links.Add(b);
			}
			else
			{
				caves.Add(a, [b]);
			}

			if (caves.TryGetValue(b, out links))
			{
				links.Add(a);
			}
			else
			{
				caves.Add(b, [a]);
			}
		}

		return caves;
	}
}
