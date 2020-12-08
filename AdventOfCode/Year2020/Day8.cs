using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020
{
	public class Day8
	{
		private readonly string[] _input;

		public Day8(string input)
		{
			_input = input.ToLines();
		}

		public int Part1()
		{
			var (acc, _) = Execute(_input);

			return acc;
		}

		public int Part2()
		{
			for (int i = 0; i < _input.Length; i++)
			{
				if (_input[i].StartsWith("acc"))
				{
					continue;
				}

				var prg = _input.ToArray();

				if (prg[i].StartsWith("nop"))
				{
					prg[i] = "jmp" + prg[i][3..];
				}
				else if (prg[i].StartsWith("jmp"))
				{
					prg[i] = "nop" + prg[i][3..];
				}

				var (acc, hlt) = Execute(prg);

				if (hlt)
				{
					return acc;
				}
			}

			throw new Exception("not found");
		}

		private static (int acc, bool hlt) Execute(string[] prg)
		{
			var seen = new HashSet<int>();

			var inp = 0;
			var acc = 0;

			while (true)
			{
				if (inp == prg.Length)
				{
					return (acc, true);
				}
				else if (!seen.Add(inp))
				{
					return (acc, false);
				}

				var opc = prg[inp];

				if (opc.StartsWith("acc"))
				{
					acc += opc.AsSpan(4).ToInt32();
				}
				else if (opc.StartsWith("jmp"))
				{
					inp += opc.AsSpan(4).ToInt32();
					continue;
				}

				inp++;
			}
		}
	}
}
