namespace AdventOfCode.Year2017;

public class Day25(string[] input)
{
	public int Part1()
	{
		var (states, steps) = Parse();
		var memory = new DefaultDictionary<int, int>();
		var cursor = 0;
		var current = 'A';

		for (int i = 0; i < steps; i++)
		{
			var state = states[current];

			if (memory[cursor] is 0)
			{
				Update(state.If0);
			}
			else
			{
				Update(state.If1);
			}
		}

		return memory.Values.Count(v => v is 1);

		void Update(Action test)
		{
			memory[cursor] = test.Write;
			cursor += test.Move;
			current = test.Next;
		}
	}

	public string Part2()
	{
		return "get 49 stars";
	}

	private readonly record struct State(Action If0, Action If1);
	private readonly record struct Action(int Write, int Move, char Next);

	private class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		public new TValue this[TKey key]
		{
			get => TryGetValue(key, out var value) ? value : default;
			set => base[key] = value;
		}
	}

	private (Dictionary<char, State> States, int Steps) Parse()
	{
		var states = new Dictionary<char, State>();
		var steps = input[1].Split()[5].ToInt32();

		foreach (var chunk in input.Skip(2).Chunk(9))
		{
			var name = chunk[0][^2];
			states.Add(name, new(Parse(chunk[2..5]), Parse(chunk[6..9])));
		}

		return (states, steps);

		static Action Parse(string[] input)
		{
			var write = input[0].Split()[4].Trim('.').ToInt32();
			var move = input[1].Split()[6] is "right." ? 1 : -1;
			var next = input[2][^2];
			return new(write, move, next);
		}
	}
}
