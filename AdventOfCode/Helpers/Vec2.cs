namespace AdventOfCode;

public static class Vec2
{
	public static Vec2<T> Create<T>(T x, T y)
		where T : INumber<T> =>
		new(x, y);

	public static Vec2<T> Create<T>((T, T) vec)
		where T : INumber<T> =>
		new(vec.Item1, vec.Item2);

	public static Vec2<T> Create<T>(ReadOnlySpan<T> span)
		where T : INumber<T>
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(span.Length, 2);

		return new(span[0], span[1]);
	}

	public static bool TryCreate<T>(ReadOnlySpan<T> span, out Vec2<T> vec)
		where T : INumber<T>
	{
		if (span.Length < 2)
		{
			vec = default;
			return false;
		}

		vec = Create(span);
		return true;
	}

	public static Vec2<T> Intersect<T>(Vec2<T> a1, Vec2<T> d1, Vec2<T> a2, Vec2<T> d2)
		where T : INumber<T> =>
		a1 + (a2 - a1).Cross(d2) / d1.Cross(d2) * d1;
}

public readonly record struct Vec2<T>(T X, T Y) : IComparable<Vec2<T>>
	where T : INumber<T>
{
	public static Vec2<T> Zero => default;
	public static Vec2<T> One => new(T.One, T.One);

	public double Abs() =>
		Math.Sqrt(Double.CreateChecked(Norm()));

	public double Angle(Vec2<T> vec) =>
		Math.Acos(Double.CreateChecked(Dot(vec)) / Abs() / vec.Abs());

	public T Cross(Vec2<T> vec) =>
		X * vec.Y - Y * vec.X;

	public T Dot(Vec2<T> vec) =>
		X * vec.X + Y * vec.Y;

	public T Norm() => Dot(this);

	public double Proj(Vec2<T> vec) =>
		Double.CreateChecked(Dot(vec)) / vec.Abs();

	public static Vec2<T> operator +(Vec2<T> a, Vec2<T> b) =>
		new(a.X + b.X, a.Y + b.Y);

	public static Vec2<T> operator -(Vec2<T> a, Vec2<T> b) =>
		new(a.X - b.X, a.Y - b.Y);

	public static Vec2<T> operator *(Vec2<T> vec, T val) =>
		new(vec.X * val, vec.Y * val);

	public static Vec2<T> operator *(T val, Vec2<T> vec) =>
		vec * val;

	public static Vec2<T> operator /(Vec2<T> vec, T val) =>
		new(vec.X / val, vec.Y / val);

	public static Vec2<T> operator %(Vec2<T> vec, T val) =>
		new(vec.X % val, vec.Y % val);

	public static Vec2<T> operator -(Vec2<T> vec) =>
		new(-vec.X, -vec.Y);

	public static implicit operator Vec2<T>((T x, T y) val) =>
		new(val.x, val.y);

	public int CompareTo(Vec2<T> other)
	{
		var cmp = X.CompareTo(other.X);
		if (cmp != 0) return cmp;
		return Y.CompareTo(other.Y);
	}
}
