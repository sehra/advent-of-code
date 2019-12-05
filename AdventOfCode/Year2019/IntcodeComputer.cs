using System;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class IntcodeComputer
	{
		private readonly int[] _memory;
		private int _counter;

		public IntcodeComputer(string memory)
			: this(memory.Split(',').Select(Int32.Parse).ToArray())
		{
		}

		public IntcodeComputer(int[] memory)
		{
			_memory = memory;
		}

		public Func<int> Input { get; set; }
		public Action<int> Output { get; set; }

		public int Get(int address)
		{
			return _memory[address];
		}

		public void Set(int address, int value)
		{
			_memory[address] = value;
		}

		public void Run()
		{
			while (true)
			{
				var opcode = _memory[_counter] % 100;
				var modes = _memory[_counter] / 100;

				switch (opcode)
				{
					case 1:
						Memory(3, modes) = Memory(1, modes) + Memory(2, modes);
						_counter += 4;
						break;
					case 2:
						Memory(3, modes) = Memory(1, modes) * Memory(2, modes);
						_counter += 4;
						break;
					case 3:
						Memory(1, modes) = Input();
						_counter += 2;
						break;
					case 4:
						Output(Memory(1, modes));
						_counter += 2;
						break;
					case 5:
						_counter = Memory(1, modes) != 0 ? Memory(2, modes) : _counter + 3;
						break;
					case 6:
						_counter = Memory(1, modes) == 0 ? Memory(2, modes) : _counter + 3;
						break;
					case 7:
						Memory(3, modes) = Memory(1, modes) < Memory(2, modes) ? 1 : 0;
						_counter += 4;
						break;
					case 8:
						Memory(3, modes) = Memory(1, modes) == Memory(2, modes) ? 1 : 0;
						_counter += 4;
						break;
					case 99:
						return;
					default:
						throw new InvalidOperationException();
				}
			}
		}

		private ref int Memory(int offset, int modes)
		{
			switch ((modes / (int)Math.Pow(10, offset - 1)) % 10)
			{
				case 0: return ref _memory[_memory[_counter + offset]];
				case 1: return ref _memory[_counter + offset];
				default: throw new NotSupportedException();
			}
		}
	}
}
