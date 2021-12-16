namespace AdventOfCode.Year2021;

[TestClass]
public class Day16Tests
{
	[DataTestMethod]
	[DataRow(6, "D2FE28")]
	[DataRow(9, "38006F45291200")]
	[DataRow(14, "EE00D40C823060")]
	[DataRow(16, "8A004A801A8002F478")]
	[DataRow(12, "620080001611562C8802118E34")]
	[DataRow(23, "C0015000016115A2E0802F182340")]
	[DataRow(31, "A0016C880162017C3686B18A3D4780")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input).Part1());
	}

	[DataTestMethod]
	[DataRow(3, "C200B40A82")]
	[DataRow(54, "04005AC33890")]
	[DataRow(7, "880086C3E88112")]
	[DataRow(9, "CE00C43D881120")]
	[DataRow(1, "D8005AC2A8F0")]
	[DataRow(0, "F600BC2D8F")]
	[DataRow(0, "9C005AC2F8F0")]
	[DataRow(1, "9C0141080250320F1802104A08")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input).Part2());
	}
}
