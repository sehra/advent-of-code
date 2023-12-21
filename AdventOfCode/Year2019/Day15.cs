using System.Threading.Channels;

namespace AdventOfCode.Year2019;

public class Day15
{
	private const int N = 1;
	private const int S = 2;
	private const int W = 3;
	private const int E = 4;

	private readonly string _input;

	public Day15(string input)
	{
		_input = input;
	}

	public async Task<int> Part1()
	{
		var (map, dst) = await GetMapAsync();
		var dist = 0;

		var done = new HashSet<(int, int)> { (0, 0) };
		var next = new Queue<((int, int) pos, int dist)>();
		next.Enqueue(((0, 0), 0));

		while (next.TryDequeue(out var node))
		{
			if (node.pos == dst)
			{
				dist = node.dist;
				break;
			}

			foreach (var dir in new[] { N, S, W, E })
			{
				var test = Step(node.pos, dir);

				if (!done.Contains(test) && IsOpen(map, test))
				{
					done.Add(test);
					next.Enqueue((test, node.dist + 1));
				}
			}
		}

		return dist;
	}

	public async Task<int> Part2()
	{
		var (map, src) = await GetMapAsync();
		var dist = 0;

		var done = new HashSet<(int, int)> { src };
		var next = new Queue<((int, int) pos, int dist)>();
		next.Enqueue((src, 0));

		while (next.TryDequeue(out var node))
		{
			dist = Math.Max(node.dist, dist);

			foreach (var dir in new[] { N, S, W, E })
			{
				var test = Step(node.pos, dir);

				if (!done.Contains(test) && IsOpen(map, test))
				{
					done.Add(test);
					next.Enqueue((test, node.dist + 1));
				}
			}
		}

		return dist;
	}

	private async Task<(Dictionary<(int, int), char>, (int, int))> GetMapAsync()
	{
		var map = new Dictionary<(int, int), char>();
		var pos = (0, 0);
		var tar = pos;
		var dir = N;

		var input = Channel.CreateUnbounded<BigInteger>();
		var intcode = new IntcodeComputer(_input)
		{
			Input = () => input.Reader.ReadAsync().AsTask()
		};
		intcode.Output = async status =>
		{
			switch ((int)status)
			{
				case 0: // hit wall
					map[Step(pos, dir)] = '#';
					dir = dir switch
					{
						N => W,
						W => S,
						S => E,
						E => N,
						_ => throw new Exception("dir?"),
					};
					await input.Writer.WriteAsync(dir);
					break;
				case 1: // moved
					pos = Step(pos, dir);
					map[pos] = '.';
					dir = dir switch
					{
						N when !IsWall(Step(pos, E)) => E,
						N => N,
						W when !IsWall(Step(pos, N)) => N,
						W => W,
						S when !IsWall(Step(pos, W)) => W,
						S => S,
						E when !IsWall(Step(pos, S)) => S,
						E => E,
						_ => throw new Exception("dir?"),
					};
					await input.Writer.WriteAsync(dir);
					if (pos == default && tar != default)
					{
						intcode.Halt();
					}
					break;
				case 2: // found it
					tar = Step(pos, dir);
					goto case 1;
			}
		};

		await input.Writer.WriteAsync(dir);
		await intcode.RunAsync();

		return (map, tar);

		bool IsWall((int, int) pos) => map.TryGetValue(pos, out var c) && c == '#';
	}

	private static bool IsOpen(Dictionary<(int, int), char> map, (int, int) pos) =>
		map.TryGetValue(pos, out var c) && c == '.';

	private static (int, int) Step((int x, int y) pos, int dir) => dir switch
	{
		N => (pos.x, pos.y + 1),
		S => (pos.x, pos.y - 1),
		W => (pos.x - 1, pos.y),
		E => (pos.x + 1, pos.y),
		_ => throw new Exception("dir?"),
	};
}
