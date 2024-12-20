using Microsoft.Z3;

namespace AdventOfCode.Year2024;

public class Day17(string[] input)
{
	public string Part1()
	{
		var (program, a, b, c) = Parse();
		var output = new List<long>();

		for (long i = 0; i < program.Length; i += 2)
		{
			var operand = program[i + 1];

			switch (program[i])
			{
				case 0: // adv
					a = a >> (int)Combo(operand);
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
					b = a >> (int)Combo(operand);
					break;

				case 7: // cdv
					c = a >> (int)Combo(operand);
					break;

				default:
					throw new Exception("opcode?");
			}
		}

		long Combo(long operand) => operand switch
		{
			0 or 1 or 2 or 3 => operand,
			4 => a,
			5 => b,
			6 => c,
			_ => throw new Exception("operand?"),
		};

		return String.Join(',', output);
	}

	public long Part2(bool testing = false)
	{
		/*
		 * do {
		 *   b = a & 7      // bst 4
		 *   b = b ^ 1      // bxl 1
		 *   c = a >> b     // cdv 5
		 *   a = a >> 3     // adv 3
		 *   b = b ^ 4      // bxl 4
		 *   b = b ^ c      // bxc 5
		 *   out(b & 7)     // out 5
		 * } while (a != 0) // jnz 0
		 */

		var (program, _, _, _) = Parse();

		var ctx = new Context();
		var a = ctx.MkBVConst("a", 64);
		var b = ctx.MkBVConst("b", 64);
		var c = ctx.MkBVConst("c", 64);
		var opt = ctx.MkOptimize();
		var res = a;

		foreach (var n in program)
		{
			for (int i = 0; i < program.Length; i += 2)
			{
				var operand = program[i + 1];

				switch (program[i])
				{
					case 0: // adv
						a = ctx.MkBVASHR(a, Combo(operand));
						break;

					case 1: // bxl
						b = ctx.MkBVXOR(b, ctx.MkBV(operand, 64));
						break;

					case 2: // bst
						b = ctx.MkBVAND(Combo(operand), ctx.MkBV(7, 64));
						break;

					case 3: // jnz
						break;

					case 4: // bxc
						b = ctx.MkBVXOR(b, c);
						break;

					case 5: // out
						opt.Assert(ctx.MkEq(ctx.MkBVAND(Combo(operand), ctx.MkBV(7, 64)), ctx.MkBV(n, 64)));
						break;

					case 6: // bdv
						b = ctx.MkBVASHR(a, Combo(operand));
						break;

					case 7: // cdv
						c = ctx.MkBVASHR(a, Combo(operand));
						break;

					default:
						throw new Exception("opcode?");
				}

				BitVecExpr Combo(long operand) => operand switch
				{
					0 or 1 or 2 or 3 => ctx.MkBV(operand, 64),
					4 => a,
					5 => b,
					6 => c,
					_ => throw new Exception("operand?"),
				};
			}
		}

		opt.Assert(ctx.MkEq(a, ctx.MkBV(0, 64)));
		opt.MkMinimize(res);

		if (opt.Check() is Status.SATISFIABLE)
		{
			return (opt.Model.Eval(res) as BitVecNum).Int64;
		}

		throw new Exception("unsatisfiable");
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
