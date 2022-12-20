namespace AdventOfCode.Year2022;

public class Day20
{
	private readonly string[] _input;

	public Day20(string[] input)
	{
		_input = input;
	}

	public long Part1() => Solve(1, 1);

	public long Part2() => Solve(10, 811589153);

	private long Solve(int rounds, long key)
	{
		var nums = new LinkedList<long>();
		var orig = new List<LinkedListNode<long>>();

		foreach (var value in _input.Select(x => x.ToInt64() * key))
		{
			orig.Add(nums.AddLast(value));
		}

		foreach (var _ in Enumerable.Range(0, rounds))
		{
			for (int i = 0; i < orig.Count; i++)
			{
				var node = orig[i];
				var steps = node.Value % (nums.Count - 1);

				if (steps < 0)
				{
					for (int j = 0; j < -steps; j++)
					{
						var temp = node.Previous ?? node.List.Last;
						nums.Remove(node);
						nums.AddBefore(temp, node);
					}
				}
				else if (steps > 0)
				{
					for (int j = 0; j < steps; j++)
					{
						var temp = node.Next ?? node.List.First;
						nums.Remove(node);
						nums.AddAfter(temp, node);
					}
				}
			}
		}

		var iter = orig.Single(x => x.Value is 0);
		var sum = 0L;

		for (int i = 0; i <= 3000; i++)
		{
			if (i is 1000 or 2000 or 3000)
			{
				sum += iter.Value;
			}

			iter = iter.Next ?? iter.List.First;
		}

		return sum;
	}
}
