namespace AdventOfCode.Year2020;

public class Day13
{
	private readonly string[] _input;

	public Day13(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var ts = _input[0].ToInt32();
		var bus = _input[1].Split(',')
			.Where(id => id != "x")
			.Select(Int32.Parse)
			.Select(id => (id, delay: id - (ts % id)))
			.OrderBy(bus => bus.delay)
			.First();

		return bus.id * bus.delay;
	}

	public long Part2()
	{
		var busses = _input[1].Split(',')
			.Select((id, i) => (id, i))
			.Where(bus => bus.id != "x")
			.Select(bus => (id: bus.id.ToInt32(), delta: bus.i))
			.ToArray();

		var time = 0L;
		var jump = busses[0].id;

		foreach (var (id, delta) in busses.Skip(1))
		{
			while ((time + delta) % id != 0)
			{
				time += jump;
			}

			jump *= id;
		}

		return time;
	}
}
