namespace AdventOfCode.Year2015;

public partial class Day14(string[] input)
{
	public int Part1(int seconds = 2503)
	{
		var raindeers = Parse();

		for (int i = 0; i < seconds; i++)
		{
			for (int j = 0; j < raindeers.Length; j++)
			{
				raindeers[j].Tick();
			}
		}

		return raindeers.Max(r => r.Distance);
	}

	public int Part2(int seconds = 2503)
	{
		var raindeers = Parse();

		for (int i = 0; i < seconds; i++)
		{
			for (int j = 0; j < raindeers.Length; j++)
			{
				raindeers[j].Tick();
			}

			foreach (var raindeer in raindeers.MaxByWithTies(r => r.Distance))
			{
				raindeer.Score++;
			}
		}

		return raindeers.Max(r => r.Score);
	}

	private record class Raindeer(string Name, int TopSpeed, int FlyTime, int RestTime)
	{
		private int _state;
		private int _delay;

		public int Distance { get; private set; }
		public int Score { get; set; }

		public void Tick()
		{
			(_state, _delay, Distance) = (_state, _delay) switch
			{
				(0, 0) => (1, FlyTime - 1, Distance + TopSpeed),
				(1, 0) => (0, RestTime - 1, Distance),
				(0, _) => (0, _delay - 1, Distance),
				(1, _) => (1, _delay - 1, Distance + TopSpeed),
				_ => throw new Exception("state?"),
			};
		}
	}

	private Raindeer[] Parse() => input
		.Select(line => line.Split())
		.Select(line => new Raindeer(line[0], line[3].ToInt32(), line[6].ToInt32(), line[13].ToInt32()))
		.ToArray();
}
