using System;
using System.Linq;
using System.Threading.Tasks;

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

		public Func<Task<int>> Input { get; set; }
		public Func<int, Task> Output { get; set; }

		public int Get(int address)
		{
			return _memory[address];
		}

		public void Set(int address, int value)
		{
			_memory[address] = value;
		}

		public async Task RunAsync()
		{
			while (true)
			{
				var opcode = _memory[_counter] % 100;
				var modes = _memory[_counter] / 100;

				switch (opcode)
				{
					case 1:
						_memory[_memory[_counter + 3]] = Memory(1, modes) + Memory(2, modes);
						_counter += 4;
						break;
					case 2:
						_memory[_memory[_counter + 3]] = Memory(1, modes) * Memory(2, modes);
						_counter += 4;
						break;
					case 3:
						_memory[_memory[_counter + 1]] = await Input();
						_counter += 2;
						break;
					case 4:
						await Output(Memory(1, modes));
						_counter += 2;
						break;
					case 5:
						_counter = Memory(1, modes) != 0 ? Memory(2, modes) : _counter + 3;
						break;
					case 6:
						_counter = Memory(1, modes) == 0 ? Memory(2, modes) : _counter + 3;
						break;
					case 7:
						_memory[_memory[_counter + 3]] = Memory(1, modes) < Memory(2, modes) ? 1 : 0;
						_counter += 4;
						break;
					case 8:
						_memory[_memory[_counter + 3]] = Memory(1, modes) == Memory(2, modes) ? 1 : 0;
						_counter += 4;
						break;
					case 99:
						return;
					default:
						throw new InvalidOperationException();
				}
			}
		}

		private int Memory(int offset, int modes)
		{
			return (modes / (int)Math.Pow(10, offset - 1) % 10) switch
			{
				0 => _memory[_memory[_counter + offset]],
				1 => _memory[_counter + offset],
				_ => throw new NotSupportedException(),
			};
		}
	}
}
