using System.Diagnostics;

namespace AdventOfCode.Year2022;

public class Day7
{
	private readonly string[] _input;

	public Day7(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var root = Parse();

		var total = 0;
		Walk(root);

		return total;

		void Walk(Entry current)
		{
			if (current.Size is 0)
			{
				var size = current.TotalSize();

				if (size <= 100_000)
				{
					total += size;
				}
			}

			foreach (var entry in current.Entries.Values)
			{
				Walk(entry);
			}
		}
	}

	public int Part2()
	{
		var root = Parse();
		var free = 70_000_000 - root.TotalSize();
		var need = 30_000_000 - free;

		var sizes = new List<int>();
		Walk(root);

		return sizes.Order().First(x => x >= need);

		void Walk(Entry current)
		{
			if (current.Size is 0)
			{
				sizes.Add(current.TotalSize());
			}

			foreach (var entry in current.Entries.Values)
			{
				Walk(entry);
			}
		}
	}

	private Entry Parse()
	{
		var root = new Entry() { Name = "/" };
		var path = new Stack<Entry>();

		foreach (var line in _input)
		{
			var cmd = line.Split();

			if (cmd[0] is "$")
			{
				if (cmd[1] is "cd")
				{
					if (cmd[2] is "/")
					{
						path.Clear();
						path.Push(root);
					}
					else if (cmd[2] is "..")
					{
						path.Pop();
					}
					else
					{
						var next = path.Peek().Entries[cmd[2]];
						path.Push(next);
					}
				}
			}
			else if (cmd[0] is "dir")
			{
				path.Peek().Entries[cmd[1]] = new(cmd[1]);
			}
			else
			{
				var size = cmd[0].ToInt32();
				var name = cmd[1];
				path.Peek().Entries[name] = new(name, size);
			}
		}

		return root;
	}

	[DebuggerDisplay("{Name} {Size}")]
	private class Entry
	{
		public Entry(string name = null, int size = 0)
		{
			Name = name;
			Size = size;
		}

		public string Name { get; set; }
		public int Size { get; set; }
		public Dictionary<string, Entry> Entries { get; set; } = [];

		public int TotalSize()
		{
			var total = Size;

			foreach (var (_, entry) in Entries)
			{
				total += entry.TotalSize();
			}

			return total;
		}
	}
}
