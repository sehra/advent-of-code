namespace AdventOfCode.Year2020;

[TestClass]
public class Day4Tests
{
	[DataTestMethod]
	[DataRow(2,
		"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\n" +
		"byr:1937 iyr:2017 cid:147 hgt:183cm\n" +
		"\n" +
		"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\n" +
		"hcl:#cfa07d byr:1929\n" +
		"\n" +
		"hcl:#ae17e1 iyr:2013\n" +
		"eyr:2024\n" +
		"ecl:brn pid:760753108 byr:1931\n" +
		"hgt:179cm\n" +
		"\n" +
		"hcl:#cfa07d eyr:2025 pid:166559648\n" +
		"iyr:2011 ecl:brn hgt:59in\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input).Part1());
	}

	[DataTestMethod]
	[DataRow(0,
		"eyr:1972 cid:100\n" +
		"hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926\n" +
		"\n" +
		"iyr:2019\n" +
		"hcl:#602927 eyr:1967 hgt:170cm\n" +
		"ecl:grn pid:012533040 byr:1946\n" +
		"\n" +
		"hcl:dab227 iyr:2012\n" +
		"ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277\n" +
		"\n" +
		"hgt:59cm ecl:zzz\n" +
		"eyr:2038 hcl:74454a iyr:2023\n" +
		"pid:3556412378 byr:2007\n")]
	[DataRow(4,
		"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\n" +
		"hcl:#623a2f\n" +
		"\n" +
		"eyr:2029 ecl:blu cid:129 byr:1989\n" +
		"iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm\n" +
		"\n" +
		"hcl:#888785\n" +
		"hgt:164cm byr:2001 iyr:2015 cid:88\n" +
		"pid:545766238 ecl:hzl\n" +
		"eyr:2022\n" +
		"\n" +
		"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input).Part2());
	}
}
