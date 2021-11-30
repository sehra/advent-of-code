namespace AdventOfCode.Year2020;

public class Day4
{
	private readonly string _input;

	public Day4(string input)
	{
		_input = input.Replace("\r\n", "\n");
	}

	public int Part1()
	{
		return ParsePassports().Count(IsValid1);
	}

	public int Part2()
	{
		return ParsePassports().Where(IsValid1).Count(IsValid2);
	}

	private List<Dictionary<string, string>> ParsePassports()
	{
		var passports = new List<Dictionary<string, string>>();

		foreach (var record in _input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries))
		{
			var passport = new Dictionary<string, string>();

			foreach (var field in record.Split(new[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries))
			{
				var kv = field.Split(':');
				passport.Add(kv[0], kv[1]);
			}

			passports.Add(passport);
		}

		return passports;
	}

	private bool IsValid1(Dictionary<string, string> passport)
	{
		return passport.Count == (passport.ContainsKey("cid") ? 8 : 7);
	}

	private bool IsValid2(Dictionary<string, string> passport)
	{
		foreach (var (key, value) in passport)
		{
			if (key == "cid")
			{
				continue;
			}

			var valid = key switch
			{
				"byr" => Regex.IsMatch(value, "^192[0-9]|19[3-9][0-9]|200[0-2]$"),
				"iyr" => Regex.IsMatch(value, "^201[0-9]|2020$"),
				"eyr" => Regex.IsMatch(value, "^202[0-9]|2030$"),
				"hgt" => Regex.IsMatch(value, "^(1[5-8][0-9]|19[0-3])cm|(59|6[0-9]|7[0-6])in$"),
				"hcl" => Regex.IsMatch(value, "^#[0-9a-f]{6}$"),
				"ecl" => Regex.IsMatch(value, "^(amb|blu|brn|gry|grn|hzl|oth)$"),
				"pid" => Regex.IsMatch(value, "^[0-9]{9}$"),
				_ => throw new Exception("unknown key"),
			};

			if (!valid)
			{
				return false;
			}
		}

		return true;
	}
}
