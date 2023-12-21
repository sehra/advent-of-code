namespace AdventOfCode;

public static class Vec3
{
	public static Vec3<T> Create<T>(T x, T y, T z)
		where T : INumber<T> =>
		new(x, y, z);

	public static Vec3<T> Create<T>((T, T, T) vec)
		where T : INumber<T> =>
		new(vec.Item1, vec.Item2, vec.Item3);

	public static Vec3<T> Create<T>(Vec2<T> vec, T z)
		where T : INumber<T> =>
		new(vec.X, vec.Y, z);

	public static Vec3<T> Create<T>(ReadOnlySpan<T> span)
		where T : INumber<T>
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(span.Length, 3);

		return new(span[0], span[1], span[2]);
	}

	public static bool TryCreate<T>(ReadOnlySpan<T> span, out Vec3<T> vec)
		where T : INumber<T>
	{
		if (span.Length < 3)
		{
			vec = default;
			return false;
		}

		vec = Create(span);
		return true;
	}

	public static Vec3<T> Intersect<T>(Vec3<T> a1, Vec3<T> d1, Vec3<T> a2, Vec3<T> d2, Vec3<T> a3, Vec3<T> d3)
		where T : INumber<T>
	{
		var x = Create(d1.X, d2.X, d3.X);
		var y = Create(d1.Y, d2.Y, d3.Y);
		var z = Create(d1.Z, d2.Z, d3.Z);
		var d = Create(a1.Dot(d1), a2.Dot(d2), a3.Dot(d3));

		return Create(d.Triple(y, z), x.Triple(d, z), x.Triple(y, d)) / d1.Triple(d2, d3);
	}
}

public readonly record struct Vec3<T>(T X, T Y, T Z) : IComparable<Vec3<T>>
	where T : INumber<T>
{
	public static Vec3<T> Zero => default;
	public static Vec3<T> One => new(T.One, T.One, T.One);

	public double Abs() =>
		Math.Sqrt(Double.CreateChecked(Norm()));

	public double Angle(Vec3<T> vec) =>
		Math.Acos(Double.CreateChecked(Dot(vec)) / Abs() / vec.Abs());

	public Vec3<T> Cross(Vec3<T> vec) =>
		new(Y * vec.Z - Z * vec.Y, Z * vec.X - X * vec.Z, X * vec.Y - Y - vec.X);

	public T Dot(Vec3<T> vec) =>
		X * vec.X + Y * vec.Y + Z * vec.Z;

	public T Norm() => Dot(this);

	public double Proj(Vec3<T> vec) =>
		Double.CreateChecked(Dot(vec)) / vec.Abs();

	public T Triple(Vec3<T> b, Vec3<T> c) => Dot(b.Cross(c));

	public static Vec3<T> operator +(Vec3<T> a, Vec3<T> b) =>
		new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

	public static Vec3<T> operator -(Vec3<T> a, Vec3<T> b) =>
		new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

	public static Vec3<T> operator *(Vec3<T> vec, T val) =>
		new(vec.X * val, vec.Y * val, vec.Z * val);

	public static Vec3<T> operator *(T val, Vec3<T> vec) =>
		vec * val;

	public static Vec3<T> operator /(Vec3<T> vec, T val) =>
		new(vec.X / val, vec.Y / val, vec.Z / val);

	public static Vec3<T> operator %(Vec3<T> vec, T val) =>
		new(vec.X % val, vec.Y % val, vec.Z % val);

	public static Vec3<T> operator -(Vec3<T> vec) =>
		new(-vec.X, -vec.Y, -vec.Z);

	public static implicit operator Vec3<T>((T x, T y, T z) val) =>
		new(val.x, val.y, val.z);

	public int CompareTo(Vec3<T> other)
	{
		var cmp = X.CompareTo(other.X);
		if (cmp != 0) return cmp;
		cmp = Y.CompareTo(other.Y);
		if (cmp != 0) return cmp;
		return Z.CompareTo(other.Z);
	}
}
