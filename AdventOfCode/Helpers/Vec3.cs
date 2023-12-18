using System.Numerics;

namespace AdventOfCode;

public static class Vec3
{
	public static Vec3<T> Create<T>(T x, T y, T z) where T : INumber<T> =>
		new(x, y, z);

	public static Vec3<T> Create<T>((T, T, T) vec) where T : INumber<T> =>
		new(vec.Item1, vec.Item2, vec.Item3);

	public static Vec3<T> Create<T>(Vec2<T> vec, T z) where T : INumber<T> =>
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
}

public readonly record struct Vec3<T>(T X, T Y, T Z) : IComparable<Vec3<T>>
	where T : INumber<T>
{
	public double Abs() => Math.Sqrt(Double.CreateChecked(Norm()));

	public double Angle(Vec3<T> vec) =>
		Math.Acos(Double.CreateChecked(Dot(vec)) / Abs() / vec.Abs());

	public T Dot(Vec3<T> vec) =>
		X * vec.X + Y * vec.Y + Z * vec.Z;

	public T Norm() => Dot(this);

	public double Proj(Vec3<T> vec) =>
		Double.CreateChecked(Dot(vec)) / vec.Abs();

	public static Vec3<T> operator +(Vec3<T> a, Vec3<T> b) =>
		new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

	public static Vec3<T> operator -(Vec3<T> a, Vec3<T> b) =>
		new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

	public static Vec3<T> operator *(Vec3<T> vec, T val) =>
		new(vec.X * val, vec.Y * val, vec.Z * val);

	public static Vec3<T> operator /(Vec3<T> vec, T val) =>
		new(vec.X / val, vec.Y / val, vec.Z / val);

	public static Vec3<T> operator %(Vec3<T> vec, T val) =>
		new(vec.X % val, vec.Y % val, vec.Z % val);

	public static Vec3<T> operator -(Vec3<T> vec) =>
		new(-vec.X, -vec.Y, -vec.Z);

	public int CompareTo(Vec3<T> other)
	{
		var cmp = X.CompareTo(other.X);
		if (cmp != 0) return cmp;
		cmp = Y.CompareTo(other.Y);
		if (cmp != 0) return cmp;
		return Z.CompareTo(other.Z);
	}
}
