namespace AdventOfCode.Year2016;

public class Day19(string input)
{
	public int Part1()
	{
		var nums = input.ToInt32();
		var root = new Elf(1);
		var prev = root;

		for (int i = 1; i < nums; i++)
		{
			prev = prev.Next = new Elf(i + 1) { Prev = prev };
		}

		prev.Next = root;
		root.Prev = prev;

		var curr = root;

		while (curr.Next != curr)
		{
			var next = curr.Next;
			next.Prev.Next = next.Next;
			next.Next.Prev = next.Prev;

			curr = curr.Next;
		}

		return curr.Index;
	}

	public int Part2()
	{
		var nums = input.ToInt32();
		var root = new Elf(1);
		var half = root;
		var prev = root;

		for (int i = 1; i < nums; i++)
		{
			prev = prev.Next = new Elf(i + 1) { Prev = prev };

			if (nums / 2 == i)
			{
				half = prev;
			}
		}

		prev.Next = root;
		root.Prev = prev;

		var curr = root;
		var skip = nums % 2 == 1;

		while (curr.Next != curr)
		{
			half.Prev.Next = half.Next;
			half.Next.Prev = half.Prev;

			half = skip ? half.Next.Next : half.Next;
			skip = !skip;

			curr = curr.Next;
		}

		return curr.Index;
	}

	private class Elf(int index)
	{
		public int Index { get; set; } = index;
		public Elf Prev { get; set; }
		public Elf Next { get; set; }
	}
}
