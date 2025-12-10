using Microsoft.Z3;

namespace AdventOfCode.Year2025;

public partial class Day10(string[] input)
{
	public int Part1() => Parse()
		.Select(machine => Enumerable
			.Range(0, machine.Buttons.Length)
			.Select(count => machine.Buttons
				.Combinations(count)
				.Select(buttons => new
				{
					Count = count,
					Lights = buttons
						.Aggregate(
							new bool[machine.Lights.Length],
							(lights, toggles) => toggles
								.Aggregate(lights, (state, toggle) => 
								{
									state[toggle] = !state[toggle];
									return state;
								}))
				})
			)
			.SelectMany(results => results.Where(result => result.Lights.SequenceEqual(machine.Lights)))
			.First()
			.Count
		)
		.Sum();
	
	public int Part2()
	{
		using var ctx = new Context();
		var total = 0;

		foreach (var machine in Parse())
		{
			using var opt = ctx.MkOptimize();

			var buttons = new IntExpr[machine.Buttons.Length];

			for (int b = 0; b < machine.Buttons.Length; b++)
			{
				buttons[b] = ctx.MkIntConst($"b{b}");
				opt.Assert(buttons[b] >= 0);
			}

			for (int j = 0; j < machine.Joltages.Length; j++)
			{
				var joltages = new List<IntExpr>();

				for (int b = 0; b < machine.Buttons.Length; b++)
				{
					if (machine.Buttons[b].Contains(j))
					{
						joltages.Add(buttons[b]);
					}
				}

				var sum = ctx.MkAdd(joltages);
				var goal = ctx.MkInt(machine.Joltages[j]);
				opt.Assert(ctx.MkEq(sum, goal));
			}

			opt.MkMinimize(ctx.MkAdd(buttons));

			if (opt.Check() is Status.SATISFIABLE)
			{
				total += buttons.Sum(b => (opt.Model.Eval(b) as IntNum).Int);
			}
			else
			{
				throw new Exception("not found");
			}
		}

		return total;
	}

	private readonly record struct Machine(bool[] Lights, int[][] Buttons, int[] Joltages);

	private IEnumerable<Machine> Parse()
	{
		foreach (var line in input)
		{
			// find [...] part
			var lbeg = line.IndexOf('[');
			var lend = line.IndexOf(']');
			var lval = line[(lbeg + 1)..lend];
			var next = lend + 1;

			// parse lights
			var lights = new bool[lval.Length];

			for (var i = 0; i < lval.Length; i++)
			{
				lights[i] = lval[i] is '#';
			}

			// find (...) parts
			var bvals = new List<string>();

			while (true)
			{
				var bbeg = line.IndexOf('(', next);
				if (bbeg == -1) break;
				var bend = line.IndexOf(')', bbeg);
				var bval = line[(bbeg + 1)..bend];
				bvals.Add(bval);
				next = bend + 1;
			}

			// parse buttons
			var buttons = new int[bvals.Count][];

			for (var i = 0; i < bvals.Count; i++)
			{
				buttons[i] = bvals[i].Split(',').ToInt32();
			}

			// find {...} part
			var jbeg = line.IndexOf('{', next);
			var jend = line.IndexOf('}', jbeg);
			var jval = line[(jbeg + 1)..jend];

			// parse joltages
			var joltages = jval.Split(',').ToInt32();

			yield return new(lights, buttons, joltages);
		}
	}
}
