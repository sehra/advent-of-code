using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2019
{
	public class Day8
	{
		private readonly string _input;

		public Day8(string input)
		{
			_input = input;
		}

		public int Part1()
		{
			var layers = new List<string>();
			var input = _input.AsSpan();

			while (!input.IsEmpty)
			{
				layers.Add(new string(input.Slice(0, 25 * 6)));
				input = input.Slice(25 * 6);
			}

			var layer = layers
				.Select(l => new { Data = l, Count = l.Count(x => x == '0') })
				.OrderBy(l => l.Count)
				.First();

			return layer.Data.Count(x => x == '1') * layer.Data.Count(x => x == '2');
		}

		public string Part2()
		{
			const int Width = 25;
			const int Height = 6;

			var picture = DecodePicture(_input, Width, Height);
			var result = new int?[Width, Height];

			for (int w = 0; w < Width; w++)
			{
				for (int h = 0; h < Height; h++)
				{
					for (int l = 0; l < picture.Count; l++)
					{
						result[w, h] = (result[w, h], picture[l][w, h]) switch
						{
							(null, 2) => null,
							(null, var value) => value,
							(var value, _) => value,
						};
					}
				}
			}

			var sb = new StringBuilder().AppendLine();

			for (int h = 0; h < Height; h++)
			{
				for (int w = 0; w < Width; w++)
				{
					sb.Append(result[w, h] switch
					{
						0 => ' ',
						1 => '*',
						_ => '?',
					});
				}

				sb.AppendLine();
			}

			return sb.ToString();
		}

		public static List<int[,]> DecodePicture(ReadOnlySpan<char> input, int width, int height)
		{
			var picture = new List<int[,]>();

			while (!input.IsEmpty)
			{
				var layer = new int[width, height];

				for (int h = 0; h < height; h++)
				{
					for (int w = 0; w < width; w++)
					{
						layer[w, h] = input[(width * h) + w] - '0';
					}
				}

				picture.Add(layer);
				input = input.Slice(width * height);
			}

			return picture;
		}
	}
}
