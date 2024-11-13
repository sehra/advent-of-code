namespace AdventOfCode.Year2017;

using Vec = Vec3<int>;

public class Day20(string[] input)
{
	public int Part1()
	{
		var particles = Parse();
		var distances = new int[particles.Count];

		// seems to work
		for (int n = 0; n < 1_000; n++)
		{
			for (int i = 0; i < particles.Count; i++)
			{
				var p = particles[i];
				p = p with { Vel = p.Vel + p.Acc };
				p = p with { Pos = p.Pos + p.Vel };
				particles[i] = p;
				distances[i] = Math.Abs(p.Pos.X) + Math.Abs(p.Pos.Y) + Math.Abs(p.Pos.Z);
			}
		}

		return distances.Index().MinBy(d => d.Item).Index;
	}

	public int Part2()
	{
		var particles = Parse();

		// seems to work
		for (int n = 0; n < 1_000; n++)
		{
			for (int i = 0; i < particles.Count; i++)
			{
				var p = particles[i];
				p = p with { Vel = p.Vel + p.Acc };
				p = p with { Pos = p.Pos + p.Vel };
				particles[i] = p;
			}

			var destroyed = particles
				.GroupBy(p => p.Pos)
				.Where(g => g.Count() > 1)
				.SelectMany(p => p)
				.ToArray();

			foreach (var particle in destroyed)
			{
				particles.Remove(particle);
			}
		}

		return particles.Count;
	}

	private readonly record struct Particle(Vec Pos, Vec Vel, Vec Acc);

	private List<Particle> Parse() => input
		.Select(line => line.Split(" pva=<,>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToInt32())
		.Select(line => new Particle
		(
			new(line[0], line[1], line[2]),
			new(line[3], line[4], line[5]),
			new(line[6], line[7], line[8])
		))
		.ToList();
}
