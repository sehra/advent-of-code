namespace AdventOfCode.Year2023;

public class Day1(string[] input)
{
	public int Part1() => input
		.Select(line =>
		{
			var nums = new List<int>();

			foreach (var c in line.Where(c => c is >= '1' and <= '9'))
			{
				nums.Add(c - '0');
			}

			return nums.First() * 10 + nums.Last();
		})
		.Sum();

	public int Part2() => input
		.Select(line =>
		{
			var nums = new List<int>();

			for (int i = 0; i < line.Length; i++)
			{
				var num = line.AsSpan(i) switch
				{
					['1', ..] or ['o', 'n', 'e', ..] => 1,
					['2', ..] or ['t', 'w', 'o', ..] => 2,
					['3', ..] or ['t', 'h', 'r', 'e', 'e', ..] => 3,
					['4', ..] or ['f', 'o', 'u', 'r', ..] => 4,
					['5', ..] or ['f', 'i', 'v', 'e', ..] => 5,
					['6', ..] or ['s', 'i', 'x', ..] => 6,
					['7', ..] or ['s', 'e', 'v', 'e', 'n', ..] => 7,
					['8', ..] or ['e', 'i', 'g', 'h', 't', ..] => 8,
					['9', ..] or ['n', 'i', 'n', 'e', ..] => 9,
					_ => 0,
				};

				if (num > 0)
				{
					nums.Add(num);
				}
			}

			return nums.First() * 10 + nums.Last();
		})
		.Sum();
}
