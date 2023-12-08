using System.Numerics;

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
}
