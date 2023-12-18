using System.Numerics;

namespace AdventOfCode;

public static class Vec4
{
	public static Vec4<T> Create<T>(T x, T y, T z, T w) where T : INumber<T> =>
		new(x, y, z, w);

	public static Vec4<T> Create<T>((T, T, T, T) vec) where T : INumber<T> =>
		new(vec.Item1, vec.Item2, vec.Item3, vec.Item4);

	public static Vec4<T> Create<T>(Vec2<T> xy, T z, T w) where T : INumber<T> =>
		new(xy.X, xy.Y, z, w);

	public static Vec4<T> Create<T>(Vec3<T> xyz, T w) where T : INumber<T> =>
		new(xyz.X, xyz.Y, xyz.Z, w);

	public static Vec4<T> Create<T>(ReadOnlySpan<T> span)
		where T : INumber<T>
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(span.Length, 4);

		return new(span[0], span[1], span[2], span[3]);
	}

	public static bool TryCreate<T>(ReadOnlySpan<T> span, out Vec4<T> vec)
		where T : INumber<T>
	{
		if (span.Length < 4)
		{
			vec = default;
			return false;
		}

		vec = Create(span);
		return true;
	}
}

public readonly record struct Vec4<T>(T X, T Y, T Z, T W) : IComparable<Vec4<T>>
	where T : INumber<T>
{
	public double Abs() => Math.Sqrt(Double.CreateChecked(Norm()));

	public T Dot(Vec4<T> vec) =>
		X * vec.X + Y * vec.Y + Z * vec.Z + W * vec.W;

	public T Norm() => Dot(this);

	public double Proj(Vec4<T> vec) =>
		Double.CreateChecked(Dot(vec)) / vec.Abs();

	public static Vec4<T> operator +(Vec4<T> a, Vec4<T> b) =>
		new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);

	public static Vec4<T> operator -(Vec4<T> a, Vec4<T> b) =>
		new(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);

	public static Vec4<T> operator *(Vec4<T> vec, T val) =>
		new(vec.X * val, vec.Y * val, vec.Z * val, vec.W * val);

	public static Vec4<T> operator /(Vec4<T> vec, T val) =>
		new(vec.X / val, vec.Y / val, vec.Z / val, vec.W / val);

	public static Vec4<T> operator %(Vec4<T> vec, T val) =>
		new(vec.X % val, vec.Y % val, vec.Z % val, vec.W % val);

	public static Vec4<T> operator -(Vec4<T> vec) =>
		new(-vec.X, -vec.Y, -vec.Z, -vec.W);

	public int CompareTo(Vec4<T> other)
	{
		var cmp = X.CompareTo(other.X);
		if (cmp != 0) return cmp;
		cmp = Y.CompareTo(other.Y);
		if (cmp != 0) return cmp;
		cmp = Z.CompareTo(other.Z);
		if (cmp != 0) return cmp;
		return W.CompareTo(other.W);
	}
}
