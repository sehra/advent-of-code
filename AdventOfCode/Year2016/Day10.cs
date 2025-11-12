namespace AdventOfCode.Year2016;

public partial class Day10(string[] input)
{
	public int Part1(int wlo = 17, int whi = 61)
	{
		var (bots, _) = Solve((wlo, whi));

		return bots.Single(b => b.Value.Me).Key;
	}

	public int Part2()
	{
		var (_, bins) = Solve();

		return bins[0] * bins[1] * bins[2];
	}

	private (Dictionary<int, Unit> Bots, Dictionary<int, Unit> Bins) Solve((int, int) watch = default)
	{
		var bots = new Dictionary<int, Unit>();
		var bins = new Dictionary<int, Unit>();

		foreach (var line in input.Where(line => line.StartsWith("bot")))
		{
			var split = line.Split();
			var bot = split[1].ToInt32();
			var lodst = split[5];
			var lonum = split[6].ToInt32();
			var hidst = split[10];
			var hinum = split[11].ToInt32();

			bots[bot] = new(watch)
			{
				Lo = new(() => lodst is "bot" ? bots[lonum] : bins[lonum]),
				Hi = new(() => hidst is "bot" ? bots[hinum] : bins[hinum]),
			};

			if (lodst is "output")
			{
				bins.TryAdd(lonum, new());
			}

			if (hidst is "output")
			{
				bins.TryAdd(hinum, new());
			}
		}

		foreach (var line in input.Where(line => line.StartsWith("value")))
		{
			var split = line.Split();
			var val = split[1].ToInt32();
			var bot = split[5].ToInt32();
			bots[bot].Give(val);
		}

		return (bots, bins);
	}

	private class Unit((int, int) watch = default)
	{
		private readonly List<int> _buf = [];

		public Lazy<Unit> Lo { get; set; }
		public Lazy<Unit> Hi { get; set; }
		public bool Me { get; private set; }

		public void Give(int chip)
		{
			_buf.Add(chip);

			if (Lo is null || Hi is null)
			{
				return;
			}

			if (_buf.Count is 2)
			{
				_buf.Sort();
				var lo = _buf[0];
				var hi = _buf[1];
				_buf.Clear();

				if ((lo, hi) == watch)
				{
					Me = true;
				}

				Lo.Value.Give(lo);
				Hi.Value.Give(hi);
			}
		}

		public static implicit operator int(Unit unit)
		{
			return unit._buf[0];
		}
	}
}
