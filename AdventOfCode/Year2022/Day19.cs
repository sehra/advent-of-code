namespace AdventOfCode.Year2022;

public class Day19
{
	private readonly string[] _input;

	public Day19(string[] input)
	{
		_input = input;
	}

	public int Part1() => Parse().Select(bp => bp.Id * Solve(bp, 24)).Sum();

	public int Part2() => Parse().Take(3).Select(bp => Solve(bp, 32)).Multiply();

	private static int Solve(Blueprint blueprint, int minutes)
	{
		var yield = 0;
		var maxOreCost = new[] { blueprint.OreRobotOreCost, blueprint.ClayRobotOreCost, blueprint.ObsidianRobotOreCost, blueprint.GeodeRobotOreCost }.Max();

		var done = new HashSet<State>();
		var work = new Queue<State>();
		work.Enqueue(new() { Minute = minutes, OreRobots = 1 });

		while (work.TryDequeue(out var state))
		{
			if (state.Minute is 0)
			{
				yield = Math.Max(yield, state.GeodeCount);
				continue;
			}

			// throw away excess robots
			state = state with
			{
				OreRobots = Math.Min(state.OreRobots, maxOreCost),
				ClayRobots = Math.Min(state.ClayRobots, blueprint.ObsidianRobotClayCost),
				ObsidianRobots = Math.Min(state.ObsidianRobots, blueprint.GeodeRobotObsidianCost),
			};

			// throw away excess ore
			state = state with
			{
				OreCount = Math.Min(state.OreCount, state.Minute * maxOreCost - state.OreRobots * (state.Minute - 1)),
				ClayCount = Math.Min(state.ClayCount, state.Minute * blueprint.ObsidianRobotClayCost - state.ClayRobots * (state.Minute - 1)),
				ObsidianCount = Math.Min(state.ObsidianCount, state.Minute * blueprint.GeodeRobotObsidianCost - state.ObsidianRobots * (state.Minute - 1)),
			};

			if (done.Add(state))
			{
				state = state with { Minute = state.Minute - 1 };

				// no robot
				work.Enqueue(state with
				{
					OreCount = state.OreCount + state.OreRobots,
					ClayCount = state.ClayCount + state.ClayRobots,
					ObsidianCount = state.ObsidianCount + state.ObsidianRobots,
					GeodeCount = state.GeodeCount + state.GeodeRobots,
				});

				// make ore robot
				if (state.OreCount >= blueprint.OreRobotOreCost)
				{
					work.Enqueue(state with
					{
						OreCount = state.OreCount + state.OreRobots - blueprint.OreRobotOreCost,
						ClayCount = state.ClayCount + state.ClayRobots,
						ObsidianCount = state.ObsidianCount + state.ObsidianRobots,
						GeodeCount = state.GeodeCount + state.GeodeRobots,
						OreRobots = state.OreRobots + 1,
					});
				}

				// make clay robot
				if (state.OreCount >= blueprint.ClayRobotOreCost)
				{
					work.Enqueue(state with
					{
						OreCount = state.OreCount + state.OreRobots - blueprint.ClayRobotOreCost,
						ClayCount = state.ClayCount + state.ClayRobots,
						ObsidianCount = state.ObsidianCount + state.ObsidianRobots,
						GeodeCount = state.GeodeCount + state.GeodeRobots,
						ClayRobots = state.ClayRobots + 1,
					});
				}

				// make obsidian robot
				if (state.OreCount >= blueprint.ObsidianRobotOreCost && state.ClayCount >= blueprint.ObsidianRobotClayCost)
				{
					work.Enqueue(state with
					{
						OreCount = state.OreCount + state.OreRobots - blueprint.ObsidianRobotOreCost,
						ClayCount = state.ClayCount + state.ClayRobots - blueprint.ObsidianRobotClayCost,
						ObsidianCount = state.ObsidianCount + state.ObsidianRobots,
						GeodeCount = state.GeodeCount + state.GeodeRobots,
						ObsidianRobots = state.ObsidianRobots + 1,
					});
				}

				// make geode robot
				if (state.OreCount >= blueprint.GeodeRobotOreCost && state.ObsidianCount >= blueprint.GeodeRobotObsidianCost)
				{
					work.Enqueue(state with
					{
						OreCount = state.OreCount + state.OreRobots - blueprint.GeodeRobotOreCost,
						ClayCount = state.ClayCount + state.ClayRobots,
						ObsidianCount = state.ObsidianCount + state.ObsidianRobots - blueprint.GeodeRobotObsidianCost,
						GeodeCount = state.GeodeCount + state.GeodeRobots,
						GeodeRobots = state.GeodeRobots + 1,
					});
				}
			}
		}

		return yield;
	}

	private readonly record struct State(
		int Minute,
		int OreCount,
		int ClayCount,
		int ObsidianCount,
		int GeodeCount,
		int OreRobots,
		int ClayRobots,
		int ObsidianRobots,
		int GeodeRobots
	);

	private IEnumerable<Blueprint> Parse() => _input.Select(Blueprint.Parse);

	private readonly record struct Blueprint(
		int Id,
		int OreRobotOreCost,
		int ClayRobotOreCost,
		int ObsidianRobotOreCost,
		int ObsidianRobotClayCost,
		int GeodeRobotOreCost,
		int GeodeRobotObsidianCost
	)
	{
		public static Blueprint Parse(string line)
		{
			var split = line.Split(' ', ':');

			return new(split[1].ToInt32(), split[7].ToInt32(), split[13].ToInt32(),
				split[19].ToInt32(), split[22].ToInt32(), split[28].ToInt32(), split[31].ToInt32());
		}
	}
}
