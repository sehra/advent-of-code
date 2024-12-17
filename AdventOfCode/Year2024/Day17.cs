namespace AdventOfCode.Year2024;

public class Day17(string[] input)
{
	public string Part1()
	{
		var (program, a, b, c) = Parse();
		var output = Run(program, a, b, c);

		return String.Join(',', output);
	}

	public long Part2(bool testing = false)
	{
		/*
		 * do {
		 *   b = a & 7        // bst 4
		 *   b = b ^ 1        // bxl 1
		 *   c = a / (1 << b) // cdv 5
		 *   a = a >> 3       // adv 3
		 *   b = b ^ 4        // bxl 4
		 *   b = b ^ c        // bxc 5
		 *   out(b)           // out 5
		 * } while (a != 0);  // jnz 0
		 */

		var (program, _, b, c) = Parse();

		for (long a = 1; true; a++)
		{
			var output = Run(program, a, b, c);

			if (program.SequenceEqual(output))
			{
				return a;
			}

			if (!testing && program.TakeLast(output.Count).SequenceEqual(output))
			{
				a = (a << 3) - 1;
			}
		}
	}

	private static List<long> Run(long[] program, long a, long b, long c)
	{
		var output = new List<long>();

		for (long i = 0; i < program.Length; i += 2)
		{
			var operand = program[i + 1];

			switch (program[i])
			{
				case 0: // adv
					a = a / (1 << (int)Combo(operand));
					break;

				case 1: // bxl
					b ^= operand;
					break;

				case 2: // bst
					b = Combo(operand) & 7;
					break;

				case 3: // jnz
					if (a != 0) i = operand - 2;
					break;

				case 4: // bxc
					b ^= c;
					break;

				case 5: // out
					output.Add(Combo(operand) & 7);
					break;

				case 6: // bdv
					b = a / (1 << (int)Combo(operand));
					break;

				case 7: // cdv
					c = a / (1 << (int)Combo(operand));
					break;

				default:
					throw new Exception("opcode?");
			}
		}

		return output;

		long Combo(long operand) => operand switch
		{
			0 or 1 or 2 or 3 => operand,
			4 => a,
			5 => b,
			6 => c,
			_ => throw new Exception("operand?"),
		};
	}

	private (long[], long, long, long) Parse()
	{
		var a = input[0].AsSpan(12).ToInt64();
		var b = input[1].AsSpan(12).ToInt64();
		var c = input[2].AsSpan(12).ToInt64();
		var p = input[3][9..].Split(',').ToInt64();

		return (p, a, b, c);
	}
}
