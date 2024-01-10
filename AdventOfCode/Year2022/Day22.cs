namespace AdventOfCode.Year2022;

using Vec2 = Vec2<int>;
using Vec3 = Vec3<int>;

[SkipInputTrim]
public class Day22(string input)
{
	public int Part1()
	{
		var (grid, path, pos) = Parse();
		var dir = 0;

		foreach (var insn in Regex.Split(path, "([LR])"))
		{
			if (insn is "L")
			{
				dir = (dir + 3) % 4;
			}
			else if (insn is "R")
			{
				dir = (dir + 1) % 4;
			}
			else
			{
				for (int i = 0, steps = insn.ToInt32(); i < steps; i++)
				{
					var next = pos + dir switch
					{
						0 => (+1, 0),
						1 => (0, +1),
						2 => (-1, 0),
						3 => (0, -1),
						_ => throw new Exception("dir?"),
					};

					if (!grid.ContainsKey(next))
					{
						var row = grid.Keys.Where(p => p.Y == next.Y);
						var col = grid.Keys.Where(p => p.X == next.X);
						next = dir switch
						{
							0 => row.MinBy(p => p.X),
							1 => col.MinBy(p => p.Y),
							2 => row.MaxBy(p => p.X),
							3 => col.MaxBy(p => p.Y),
							_ => throw new Exception("dir?"),
						};
					}

					if (grid[next] is '#')
					{
						break;
					}

					pos = next;
				}
			}
		}

		return 1000 * (pos.Y + 1) + 4 * (pos.X + 1) + dir;
	}

	public int Part2()
	{
		var (grid, path, start) = Parse();
		var (cube, size) = Fold(grid);
		var face = cube
			.Where(f => f.Pos.X <= start.X && start.X < f.Pos.X + size)
			.Where(f => f.Pos.Y <= start.Y && start.Y < f.Pos.Y + size)
			.Single();
		var pos = (start - face.Pos).X * face.U + (start - face.Pos).Y * face.V;
		var dir = face.U;

		foreach (var insn in Regex.Split(path, "([LR])"))
		{
			if (insn is "L")
			{
				dir = face.N.Cross(dir);
			}
			else if (insn is "R")
			{
				dir = dir.Cross(face.N);
			}
			else
			{
				for (int i = 0, steps = insn.ToInt32(); i < steps; i++)
				{
					var copy = (face, dir);
					var next = face.Project(pos + dir, size);

					var l = next.X < 0;
					var r = next.X >= size;
					var u = next.Y < 0;
					var d = next.Y >= size;
					var jump = l || r || u || d;

					if (jump)
					{
						dir = -face.N;

						if (l)
						{
							face = cube.Single(f => f.N == -face.U);
						}
						else if (r)
						{
							face = cube.Single(f => f.N == face.U);
						}
						else if (u)
						{
							face = cube.Single(f => f.N == -face.V);
						}
						else if (d)
						{
							face = cube.Single(f => f.N == face.V);
						}

						next = face.Project(pos, size);
					}

					if (grid[next + face.Pos] is '#')
					{
						(face, dir) = copy;
						break;
					}

					if (!jump)
					{
						pos += dir;
					}
				}
			}
		}

		var epos = face.Project(pos, size);
		var edir = face.Project(pos + dir, size) - epos;
		epos += face.Pos;
		var dirs = new Vec2[] { (1, 0), (0, 1), (-1, 0), (0, -1) };

		return 1000 * (epos.Y + 1) + 4 * (epos.X + 1) + Array.IndexOf(dirs, edir);
	}

	private static (List<Face> Cube, int Size) Fold(Dictionary<Vec2, char> grid)
	{
		var faces = new List<Face>();
		var size = (int)Math.Sqrt(grid.Count / 6);

		var start = grid.Keys.OrderBy(p => p.Y).ThenBy(p => p.X).First();
		var seen = new HashSet<Vec2>();
		var work = new Queue<Face>();
		work.Enqueue(new(start, new(1, 0, 0), new(0, 1, 0), new(0, 0, -1)));

		while (work.TryDequeue(out var face))
		{
			var l = face.Pos + new Vec2(-size, 0);
			var r = face.Pos + new Vec2(+size, 0);
			var u = face.Pos + new Vec2(0, -size);
			var d = face.Pos + new Vec2(0, +size);

			if (grid.ContainsKey(l) && seen.Add(l))
			{
				var f = new Face(l, face.N, face.V, -face.U);
				faces.Add(f);
				work.Enqueue(f);
			}

			if (grid.ContainsKey(r) && seen.Add(r))
			{
				var f = new Face(r, -face.N, face.V, face.U);
				faces.Add(f);
				work.Enqueue(f);
			}

			if (grid.ContainsKey(u) && seen.Add(u))
			{
				var f = new Face(u, face.U, face.N, -face.V);
				faces.Add(f);
				work.Enqueue(f);
			}

			if (grid.ContainsKey(d) && seen.Add(d))
			{
				var f = new Face(d, face.U, -face.N, face.V);
				faces.Add(f);
				work.Enqueue(f);
			}
		}

		return (faces, size);
	}

	private record class Face(Vec2 Pos, Vec3 U, Vec3 V, Vec3 N)
	{
		public Vec2 Project(Vec3 pos, int size)
		{
			var proj = new Vec2(pos.Dot(U), pos.Dot(V));

			if (Min(U) < 0)
			{
				proj = proj with { X = size - 1 + proj.X };
			}

			if (Min(V) < 0)
			{
				proj = proj with { Y = size - 1 + proj.Y };
			}

			return proj;
		}

		static int Min(Vec3 vec) => Math.Min(vec.X, Math.Min(vec.Y, vec.Z));
	}

	private (Dictionary<Vec2, char> Grid, string Path, Vec2 Start) Parse()
	{
		var lines = input.ToLines(StringSplitOptions.RemoveEmptyEntries);
		var grid = new Dictionary<Vec2, char>();

		for (int y = 0; y < lines.Length - 1; y++)
		{
			for (int x = 0; x < lines[y].Length; x++)
			{
				var c = lines[y][x];

				if (c != ' ')
				{
					grid.Add((x, y), c);
				}
			}
		}

		return (grid, lines[^1], new(lines[0].IndexOf('.'), 0));
	}
}
