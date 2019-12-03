using System;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class Day2
	{
		private readonly int[] _input;

		public Day2(string input)
		{
			_input = input.Split(',').Select(Int32.Parse).ToArray();
		}

		public int Part1()
		{
			var intcode = new Computer(_input);
			intcode.Set(1, 12);
			intcode.Set(2, 2);
			intcode.Run();

			return intcode.Get(0);
		}

		public int Part2()
		{
			for (int noun = 0; noun < 100; noun++)
			{
				for (int verb = 0; verb < 100; verb++)
				{
					try
					{
						var intcode = new Computer(_input.ToArray());
						intcode.Set(1, noun);
						intcode.Set(2, verb);
						intcode.Run();

						if (intcode.Get(0) == 19690720)
						{
							return (noun * 100) + verb;
						}
					}
					catch
					{
						// ignore
					}
				}
			}

			throw new Exception("not found");
		}

		public class Computer
		{
			private readonly int[] _memory;
			private int _counter;

			public Computer(int[] memory)
			{
				_memory = memory;
			}

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
					if (_memory[_counter] == 99)
					{
						return;
					}

					var pos1 = _memory[_counter + 1];
					var pos2 = _memory[_counter + 2];
					var pos3 = _memory[_counter + 3];

					switch (_memory[_counter])
					{
						case 1:
							_memory[pos3] = _memory[pos1] + _memory[pos2];
							break;
						case 2:
							_memory[pos3] = _memory[pos1] * _memory[pos2];
							break;
						default:
							throw new InvalidOperationException();
					}

					_counter += 4;
				}
			}
		}
	}
}
