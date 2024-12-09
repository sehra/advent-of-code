namespace AdventOfCode.Year2024;

public class Day9(string input)
{
	public long Part1()
	{
		var blocks = new List<int>();

		for (int i = 0, id = 0; i < input.Length; i++)
		{
			var n = input[i] - '0';

			if (i % 2 == 0)
			{
				blocks.AddRange(Enumerable.Repeat(id++, n));
			}
			else
			{
				blocks.AddRange(Enumerable.Repeat(-1, n));
			}
		}

		var head = 0;
		var tail = blocks.Count - 1;

		while (true)
		{
			while (head < tail && blocks[head] != -1)
			{
				head++;
			}

			if (head >= tail)
			{
				break;
			}

			(blocks[head], blocks[tail]) = (blocks[tail], blocks[head]);
			tail--;
		}

		var check = 0L;

		for (int i = 0; i < blocks.Count; i++)
		{
			if (blocks[i] != -1)
			{
				check += i * blocks[i];
			}
		}

		return check;
	}

	public long Part2()
	{
		var files = new List<(int Pos, int Len, int Id)>();
		var frees = new List<(int Pos, int Len)>();

		for (int i = 0, pos = 0, id = 0; i < input.Length; i++)
		{
			var n = input[i] - '0';

			if (i % 2 == 0)
			{
				files.Add((pos, n, id++));
			}
			else
			{
				frees.Add((pos, n));
			}

			pos += n;
		}

		for (int i = files.Count - 1; i >= 0; i--)
		{
			var file = files[i];

			for (int j = 0; j < frees.Count; j++)
			{
				var free = frees[j];

				if (free.Pos > file.Pos)
				{
					break;
				}

				if (free.Len >= file.Len)
				{
					files[i] = files[i] with { Pos = free.Pos };

					if (free.Len == file.Len)
					{
						frees.RemoveAt(j);
					}
					else
					{
						frees[j] = (free.Pos + file.Len, free.Len - file.Len);
					}

					break;
				}
			}
		}

		var check = 0L;

		foreach (var (pos, len, id) in files)
		{
			for (int i = 0; i < len; i++)
			{
				check += (pos + i) * id;
			}
		}

		return check;
	}
}
