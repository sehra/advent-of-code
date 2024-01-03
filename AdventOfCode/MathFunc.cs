namespace AdventOfCode;

public static class MathFunc
{
	public static T Lcm<T>(T a, T b)
		where T : INumber<T>
	{
		return a / Gcd(a, b) * b;
	}

	public static T Gcd<T>(T a, T b)
		where T : INumber<T>
	{
		while (b != T.Zero)
		{
			(a, b) = (b, a % b);
		}

		return a;
	}

	public static T Mod<T>(T n, T m)
		where T : INumber<T>
	{
		var r = n % m;

		return r < T.Zero ? r + m : r;
	}

	public static T Fac<T>(T n)
		where T : INumber<T>
	{
		ArgumentOutOfRangeException.ThrowIfNegative(n);

		var a = T.One;

		for (var f = T.One; f <= n; f++)
		{
			a *= f;
		}

		return a;
	}
}
