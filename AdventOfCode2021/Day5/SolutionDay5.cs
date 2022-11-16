using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2021.Day5
{
	public class SolutionDay5
	{
		private const int day = 5;

		public SolutionDay5() {	}

		#region Part 1
		/// <summary>
		/// Read line data and creating a 2-dimensional map containing a conter, that indicates how many lines cross it.
		/// </summary>
		/// <returns></returns>
		public int LocateMultiLineIntersect()
		{
			// This can be done more efficiently, by expanding the map as each line is examined...

			List<Line> lines = ReadLineData();
			int[,] map = InitializeMap(lines);

			ProcessLines(lines, map);

			// For debug purposes only
			PrintMap(map, @"D:\map.txt");

			return CountLineIntersect(map);
		}

		/// <summary>
		/// Setup a 2-dimensional map that will be big enough to contain all lines found in the input data.
		/// All positions in the map contains a counter set to zero.
		/// </summary>
		/// <param name="lines">The list of <see cref="Line"/> instances created from the input data.</param>
		/// <returns>Full 2-dimensional map</returns>
		private int[,] InitializeMap(List<Line> lines)
		{
			int width = 1;
			int height = 1;
			foreach (Line line in lines)
			{
				// Check if either start or end of the line, is beyond the current outside border width
				if (line.Start.X > width)
					width = line.Start.X;
				if (line.End.X > width)
					width = line.End.X;

				// Check if either start or end of the line, is beyond the current outside border height
				if (line.Start.Y > height)
					height = line.Start.Y;
				if (line.End.Y > height)
					height = line.End.Y;
			}

			Console.WriteLine("Map size: Height " + height + " - width " + width);

			// Setup map with all zero counters
			int[,] map = new int[height, width];
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
					map[i, j] = 0;
			}

			return map;
		}


		/// <summary>
		/// Process all found lines, marking them on the map, and counting their direction type.
		/// </summary>
		/// <param name="lines">The list of <see cref="Line"/> instances created from the input data.</param>
		/// <param name="map">The map to update.</param>
		private void ProcessLines(List<Line> lines, int[,] map)
		{
			int verticalLines = 0;
			int horizontalLines = 0;
			int diagonalLines = 0;
			foreach (Line line in lines)
			{
				MarkMap(line, map);

				switch (line.Direction)
				{
					case LineDirection.Diagonal:
						diagonalLines++;
						break;
					case LineDirection.Horizontal:
						horizontalLines++;
						break;
					case LineDirection.Vertical:
						verticalLines++;
						break;
					default:
						throw new Exception("Unknown line direction found: " + line.Direction);
				}
			}

			Console.WriteLine("");
			Console.WriteLine("Types of lines found...");
			Console.WriteLine(String.Format("{0,-19} {1}", "Vertical lines:", verticalLines));
			Console.WriteLine(String.Format("{0,-19} {1}", "Horizontal lines:", horizontalLines));
			Console.WriteLine(String.Format("{0,-19} {1}", "Diagonal lines:", diagonalLines));
			Console.WriteLine(String.Format("{0,-19} {1}", "Total lines:", lines.Count));
			Console.WriteLine("");
		}

		/// <summary>
		/// Increment all spaces on the map, where the given line is situated.
		/// </summary>
		/// <param name="line">The line to plot.</param>
		/// <param name="map">The map to update.</param>
		private void MarkMap(Line line, int[,] map)
		{
			if(line.Direction == LineDirection.Horizontal)
			{
				for (int i = line.Start.X; i <= line.End.X; i++)
					map[line.Start.Y, i]++;
			}
			else if(line.Direction == LineDirection.Vertical)
			{
				for (int i = line.Start.Y; i <= line.End.Y; i++)
					map[i, line.Start.X]++;
			}
			// Ignoring all lines that are not vertical or horizontal
		}

		/// <summary>
		/// Count all occurences on the map, where 2 or more lines intersect/overlap.
		/// </summary>
		/// <param name="map">The map to examine.</param>
		/// <returns></returns>
		private int CountLineIntersect(int[,] map)
		{
			int counter = 0;
			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					if (map[i, j] > 1)
						counter++;
				}
			}

			return counter;
		}
		#endregion

		#region Part 2

		#endregion

		private List<Line> ReadLineData()
		{
			string inputData = Util.ReadInput(day);
			string[] lineData = inputData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			List<Line> result = new List<Line>();
			foreach (string data in lineData)
				result.Add(new Line(data));

			return result;
		}

		/// <summary>
		/// Write the entire contents of the map to a text file.
		/// </summary>
		/// <param name="map">The map to print.</param>
		/// <param name="outputPath">Full path of the destination file, where the map should be written to.</param>
		private void PrintMap(int[,] map, string outputPath)
		{
			Console.WriteLine("Printing map to file: " + outputPath);

			using (FileStream stream = new FileStream(outputPath, FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(stream, Encoding.Default))
				{
					for (int i = 0; i < map.GetLength(0); i++)
					{
						StringBuilder lineBuilder = new StringBuilder();
						for (int j = 0; j < map.GetLength(1); j++)
							lineBuilder.Append(map[i, j]);
						writer.WriteLine(lineBuilder.ToString());
					}
				}
			}
		}
	}
}
