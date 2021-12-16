using System.Text;

namespace AdventOfCode.Year2021;

public class Day16
{
	private readonly string _input;

	public Day16(string input)
	{
		_input = input;
	}

	public int Part1()
	{
		var bits = GetBits();
		var packet = Packet.Parse(bits);

		return SumVersion(packet);

		static int SumVersion(Packet packet) =>
			packet.Version + packet.SubPackets.Sum(p => SumVersion(p));
	}

	public long Part2()
	{
		var bits = GetBits();
		var packet = Packet.Parse(bits);

		return packet.Value;
	}

	private abstract class Packet
	{
		protected Packet(int version)
		{
			Version = version;
		}

		public abstract long Value { get; }
		public int Version { get; }
		public List<Packet> SubPackets { get; } = new();

		public static Packet Parse(ReadOnlySpan<char> bits) =>
			ReadPacket(bits, out _);

		private static Packet ReadPacket(ReadOnlySpan<char> bits, out int used)
		{
			var version = ReadInt(bits[0..3]);
			var type = ReadInt(bits[3..6]);
			used = 6;

			if (type is 4)
			{
				var value = ReadVarInt(bits[6..], out var read);
				used += read;

				return new LitPacket(version, value);
			}
			else
			{
				var packet = MakePacket(version, type);
				used += 1;

				if (bits[6] is '0')
				{
					var length = ReadInt(bits.Slice(7, 15));
					used += 15;

					while (length > 0)
					{
						var subpacket = ReadPacket(bits[used..], out var read);
						used += read;
						length -= read;
						packet.SubPackets.Add(subpacket);
					}
				}
				else
				{
					var count = ReadInt(bits.Slice(7, 11));
					used += 11;

					for (int i = 0; i < count; i++)
					{
						var subpacket = ReadPacket(bits[used..], out var read);
						used += read;
						packet.SubPackets.Add(subpacket);
					}
				}

				return packet;
			}
		}

		private static Packet MakePacket(int version, int type) => type switch
		{
			0 => new SumPacket(version),
			1 => new MulPacket(version),
			2 => new MinPacket(version),
			3 => new MaxPacket(version),
			5 => new BinPacket(version, BinOp.Gt),
			6 => new BinPacket(version, BinOp.Lt),
			7 => new BinPacket(version, BinOp.Eq),
			_ => throw new Exception("type?"),
		};

		private static int ReadInt(ReadOnlySpan<char> bits)
		{
			var value = 0;

			foreach (var bit in bits)
			{
				value = value << 1 | (bit - '0');
			}

			return value;
		}

		private static long ReadVarInt(ReadOnlySpan<char> bits, out int used)
		{
			var more = true;
			var value = 0L;
			used = 0;

			while (more)
			{
				more = bits[0] is '1';
				value = value << 4 | (long)ReadInt(bits[1..5]);
				bits = bits[5..];
				used += 5;
			}

			return value;
		}
	}

	private class LitPacket : Packet
	{
		public LitPacket(int version, long value)
			: base(version)
		{
			Value = value;
		}

		public override long Value { get; }
	}

	private class SumPacket : Packet
	{
		public SumPacket(int version)
			: base(version)
		{
		}

		public override long Value => SubPackets.Sum(p => p.Value);
	}

	private class MulPacket : Packet
	{
		public MulPacket(int version)
			: base(version)
		{
		}

		public override long Value => SubPackets.Aggregate(1L, (acc, p) => acc * p.Value);
	}

	private class MinPacket : Packet
	{
		public MinPacket(int version)
			: base(version)
		{
		}

		public override long Value => SubPackets.Min(p => p.Value);
	}

	private class MaxPacket : Packet
	{
		public MaxPacket(int version) 
			: base(version)
		{
		}

		public override long Value => SubPackets.Max(p => p.Value);
	}

	private class BinPacket : Packet
	{
		private readonly BinOp _op;

		public BinPacket(int version, BinOp op)
			: base(version)
		{
			_op = op;
		}

		public override long Value
		{
			get
			{
				var p0 = SubPackets[0].Value;
				var p1 = SubPackets[1].Value;

				return _op switch
				{
					BinOp.Eq => p0 == p1,
					BinOp.Lt => p0 < p1,
					BinOp.Gt => p0 > p1,
					_ => throw new Exception("op?"),
				} ? 1 : 0;
			}
		}
	}

	private enum BinOp { Eq, Lt, Gt };

	private string GetBits() =>
		String.Create(_input.Length * 4, _input, (span, input) =>
		{
			for (int i = 0; i < input.Length; i++)
			{
				var bits = input[i] switch
				{
					'0' => "0000",
					'1' => "0001",
					'2' => "0010",
					'3' => "0011",
					'4' => "0100",
					'5' => "0101",
					'6' => "0110",
					'7' => "0111",
					'8' => "1000",
					'9' => "1001",
					'A' => "1010",
					'B' => "1011",
					'C' => "1100",
					'D' => "1101",
					'E' => "1110",
					'F' => "1111",
					_ => throw new Exception("nibble?"),
				};
				bits.CopyTo(span[(i * 4)..]);
			}
		});
}
