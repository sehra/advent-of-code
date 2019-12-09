using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace AdventOfCode.Year2019
{
	public class IntcodeComputer
	{
		private BigInteger[] _memory;
		private int _counter;
		private int _relbase;

		public IntcodeComputer(string memory)
			: this(memory.Split(',').Select(BigInteger.Parse).ToArray())
		{
		}

		public IntcodeComputer(BigInteger[] memory)
		{
			_memory = memory;
		}

		public Func<Task<BigInteger>> Input { get; set; }
		public Func<BigInteger, Task> Output { get; set; }

		public BigInteger Get(int address)
		{
			return _memory[address];
		}

		public void Set(int address, BigInteger value)
		{
			_memory[address] = value;
		}

		public async Task RunAsync()
		{
			while (true)
			{
				var opcode = (int)(_memory[_counter] % 100);
				var modes = (int)(_memory[_counter] / 100);

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
						var input = await Input();
						Memory(1, modes) = input;
						_counter += 2;
						break;
					case 4:
						await Output(Memory(1, modes));
						_counter += 2;
						break;
					case 5:
						_counter = Memory(1, modes) != 0 ? (int)Memory(2, modes) : _counter + 3;
						break;
					case 6:
						_counter = Memory(1, modes) == 0 ? (int)Memory(2, modes) : _counter + 3;
						break;
					case 7:
						Memory(3, modes) = Memory(1, modes) < Memory(2, modes) ? 1 : 0;
						_counter += 4;
						break;
					case 8:
						Memory(3, modes) = Memory(1, modes) == Memory(2, modes) ? 1 : 0;
						_counter += 4;
						break;
					case 9:
						_relbase += (int)Memory(1, modes);
						_counter += 2;
						break;
					case 99:
						return;
					default:
						throw new InvalidOperationException();
				}
			}
		}

		private ref BigInteger Memory(int offset, int modes)
		{
			switch (modes / (int)Math.Pow(10, offset - 1) % 10)
			{
				case 0:
				{
					var address = _counter + offset;
					EnsureMemory(address);
					address = (int)_memory[address];
					EnsureMemory(address);
					return ref _memory[address];
				}
				case 1:
				{
					var address = _counter + offset;
					EnsureMemory(address);
					return ref _memory[address];
				}
				case 2:
				{
					var address = _counter + offset;
					EnsureMemory(address);
					address = _relbase + (int)_memory[address];
					EnsureMemory(address);
					return ref _memory[address];
				}
				default: throw new NotSupportedException();
			}
		}

		private void EnsureMemory(int address)
		{
			if (address < _memory.Length)
			{
				return;
			}

			var memory = new BigInteger[address + 1];
			_memory.AsSpan().CopyTo(memory);
			_memory = memory;
		}
	}
}
