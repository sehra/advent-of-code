namespace AdventOfCode.Year2022;

public class Day21
{
	private readonly string[] _input;

	public Day21(string[] input)
	{
		_input = input;
	}

	public long Part1() => Solve(false);

	public long Part2() => Solve(true);

	private long Solve(bool part2)
	{
		var monkeys = new Dictionary<string, Func<long>>();
		var check1 = "";
		var check2 = "";

		foreach (var line in _input)
		{
			var name = line[..4];

			if (part2 && name is "humn")
			{
				continue;
			}

			var expr = line[6..].Split();

			if (part2 && name is "root")
			{
				check1 = expr[0];
				check2 = expr[2];
				continue;
			}

			if (expr.Length is 1)
			{
				var value = expr[0].ToInt64();
				monkeys[name] = () => value;
			}
			else if (expr.Length is 3)
			{
				monkeys[name] = () =>
				{
					var lhs = monkeys[expr[0]]();
					var rhs = monkeys[expr[2]]();

					return expr[1][0] switch
					{
						'+' => lhs + rhs,
						'-' => lhs - rhs,
						'*' => lhs * rhs,
						'/' => lhs / rhs,
						_ => throw new Exception("oper?"),
					};
				};
			}
		}

		if (!part2)
		{
			return monkeys["root"]();
		}

		long human = 0;
		monkeys["humn"] = () => human;

		while (true)
		{
			var value1 = monkeys[check1]();
			var value2 = monkeys[check2]();

			if (value1 == value2)
			{
				return human;
			}

			var diff = value1 - value2;

			if (diff < 100)
			{
				human++;
			}
			else
			{
				human += diff / 100;
			}
		}
	}
}
