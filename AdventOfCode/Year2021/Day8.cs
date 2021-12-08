namespace AdventOfCode.Year2021;

public class Day8
{
	private readonly string[] _input;

	public Day8(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		return _input
			.SelectMany(line => line.Split(" | ")[1].Split(' '))
			.Count(part => part.Length is 2 or 3 or 4 or 7);
	}

	public int Part2()
	{
		//  aaaa
		// b    c
		// b    c
		//  dddd
		// e    f
		// e    f
		//  gggg

		var digits = new (int Value, string Wires)[]
		{
			(0, "abcefg"),
			(1, "cf"),
			(2, "acdeg"),
			(3, "acdfg"),
			(4, "bcdf"),
			(5, "abdfg"),
			(6, "abdefg"),
			(7, "acf"),
			(8, "abcdefg"),
			(9, "abcdfg"),
		};

		return _input
			.Select(line => line.Split(" | "))
			.Select(line =>
			{
				// inputs grouped by segment count
				var inputs = line[0].Split(' ').ToLookup(x => x.Length);

				// CF from 1, A from 7-CF, F from 6 (length 6, have F but not C), C from CF-F
				var cf = inputs[2].Single();
				var a = inputs[3].Single().Except(cf).Single();
				var f = inputs[6].Select(x => x.Intersect(cf)).Single(x => x.Count() is 1).Single();
				var c = cf.Single(x => x != f);

				// BD from 4-CF, B from 0 (length 6, have B but not D), D from BD-D
				var bd = inputs[4].Single().Except(cf);
				var b = inputs[6].Select(x => x.Intersect(bd)).Single(x => x.Count() is 1).Single();
				var d = bd.Single(x => x != b);

				// EG from 8-AFCBD, G from 9 (length 6, have G but not E), E from EG-G
				var eg = inputs[7].Single().Except(new[] { a, f, c, b, d });
				var g = inputs[6].Select(x => x.Intersect(eg)).Single(x => x.Count() is 1).Single();
				var e = eg.Single(x => x != g);

				var mapping = new Dictionary<char, char>()
				{
					[a] = 'a',
					[b] = 'b',
					[c] = 'c',
					[d] = 'd',
					[e] = 'e',
					[f] = 'f',
					[g] = 'g',
				};

				return line[1].Split(' ')
					.Select(wires => wires.Select(wire => mapping[wire]).OrderBy(x => x).ToArray())
					.Select(wires => digits.Single(x => x.Wires.SequenceEqual(wires)).Value)
					.Aggregate(0, (a, n) => a * 10 + n);
			})
			.Sum();
	}
}
