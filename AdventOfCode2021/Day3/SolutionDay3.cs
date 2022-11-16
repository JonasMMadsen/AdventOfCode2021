using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day3
{
	class SolutionDay3
	{
		private const int day = 3;

		public SolutionDay3() {	}

		#region Part 1
		/// <summary>
		/// Perform binary diagnostic by extracting gamma rate and epsilon rate from binary input (in text form).
		/// </summary>
		/// <returns>Calculated power consumption found in binary diagnostic.</returns>
		public int BinaryDiagnosticPowerConsumption()
		{
			string inputData = Util.ReadInput(day);
			string[] lines = inputData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			string gammaBitsAsText = LocateMostCommonBitPrColumn(lines);
			int gammaRate = Convert.ToInt32(gammaBitsAsText, 2);
			string epsilonBitsAsText = InvertBits(gammaBitsAsText);
			int epsilonRate = Convert.ToInt32(epsilonBitsAsText, 2);

			return gammaRate * epsilonRate;
		}

		/// <summary>
		/// Locate the one or zero pr. column, that is most prolific.
		/// The value with most occurences pr. columen, is transferred to resulting string that makes up a new byte value in binary form.
		/// </summary>
		/// <param name="lines">The sample input containing bytes values in binary form, but written as text.</param>
		/// <returns>Byte value in binary form (still written as text), that contains the most common value pr. column in the input.</returns>
		private string LocateMostCommonBitPrColumn(string[] lines)
		{
			int[] zeroCount = Enumerable.Repeat(0, lines[0].Length).ToArray();
			int[] oneCount = Enumerable.Repeat(0, lines[0].Length).ToArray();
			foreach (string line in lines)
			{
				for (int i = 0; i < line.Length; i++)
				{
					if (line[i] == '0')
						zeroCount[i]++;
					else if (line[i] == '1')
						oneCount[i]++;
					else
						throw new Exception("A NOT bit value was found at position " + i + " in line: " + line);
				}
			}

			return GenerateByteWithMostCommonValue(zeroCount, oneCount);
		}

		/// <summary>
		/// The value with most occurences pr. columen, is transferred to resulting string that makes up a new byte value in binary form.
		/// </summary>
		/// <param name="zeroCount">Count pr. column for each found zero in the sample input.</param>
		/// <param name="oneCount">Count pr. column for each found one in the sample input.</param>
		/// <returns>Byte value in binary form (still written as text), that contains the most common value pr. column in the input.</returns>
		private string GenerateByteWithMostCommonValue(int[] zeroCount, int[] oneCount)
		{
			string result = "";
			for (int i = 0; i < zeroCount.Length; i++)
			{
				if (zeroCount[i] > oneCount[i])
					result += "0";
				else if (oneCount[i] > zeroCount[i])
					result += "1";
				else
					throw new Exception("An equal amount of zeroes and ones where found in column " + i);
			}

			return result;
		}

		private string InvertBits(string bitsAsText)
		{
			string result = "";
			foreach (char character in bitsAsText)
			{
				if (character == '0')
					result += '1';
				else
					result += '0';
			}

			return result;
		}
		#endregion

		#region Part 2
		public int BinaryDiagnosticLifeSupportRating()
		{
			string inputData = Util.ReadInput(day);
			string[] lines = inputData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			string oxygenGeneratorRatingAsText = LocateOxygenGeneratorRating(lines);
			int oxygenGeneratorRating = Convert.ToInt32(oxygenGeneratorRatingAsText, 2);

			string co2ScrubberRatingAsText = LocateCO2ScrubberRating(lines);
			int co2ScrubberRating = Convert.ToInt32(co2ScrubberRatingAsText, 2);

			Console.WriteLine("Oxygen generator rating binary: " + oxygenGeneratorRatingAsText);
			Console.WriteLine("Oxygen generator rating: " + oxygenGeneratorRating);
			Console.WriteLine("CO2 Scrubber rating binary: " + co2ScrubberRatingAsText);
			Console.WriteLine("CO2 Scrubber rating: " + co2ScrubberRating);

			return oxygenGeneratorRating * co2ScrubberRating;
		}

		private string LocateOxygenGeneratorRating(string[] lines)
		{
			List<string> valuesLeft = lines.ToList<string>();
			for (int i = 0; i < lines[i].Length; i++)
			{
				int commonBitIndicator = LocateMostCommonBitForColumn(i, valuesLeft);
				char commonBit;
				if (commonBitIndicator == 1)
					commonBit = '1';
				else if (commonBitIndicator == 0)
					commonBit = '0';
				// Equal occurences must result in 1
				else if (commonBitIndicator == -1)
					commonBit = '1';
				else
					throw new Exception("Unable to interpret commonBitIndicator:" + commonBitIndicator);

				for (int j = valuesLeft.Count - 1; j >= 0; j--)
				{
					if (commonBit != valuesLeft[j][i])
						valuesLeft.RemoveAt(j);

					if (valuesLeft.Count == 1)
						return valuesLeft[0];
				}
			}

			throw new Exception("Something has gone wrong!");
		}

		private string LocateCO2ScrubberRating(string[] lines)
		{
			List<string> valuesLeft = lines.ToList<string>();
			for (int i = 0; i < lines[i].Length; i++)
			{
				int commonBitIndicator = LocateMostCommonBitForColumn(i, valuesLeft);
				char leastCommonBit;
				if (commonBitIndicator == 1)
					leastCommonBit = '0';
				else if (commonBitIndicator == 0)
					leastCommonBit = '1';
				// Equal occurences must result in 0
				else if (commonBitIndicator == -1)
					leastCommonBit = '0';
				else
					throw new Exception("Unable to interpret commonBitIndicator:" + commonBitIndicator);

				for (int j = valuesLeft.Count - 1; j >= 0; j--)
				{
					if (leastCommonBit != valuesLeft[j][i])
						valuesLeft.RemoveAt(j);

					if (valuesLeft.Count == 1)
						return valuesLeft[0];
				}
			}

			throw new Exception("Something has gone wrong!");
		}

		/// <summary>
		/// Locate the one or zero pr. column, that is most prolific.
		/// The value with most occurences pr. columen, is transferred to resulting string that makes up a new byte value in binary form.
		/// </summary>
		/// <param name="lines">The sample input containing bytes values in binary form, but written as text.</param>
		/// <returns>Byte value in binary form (still written as text), that contains the most common value pr. column in the input.</returns>
		private int LocateMostCommonBitForColumn(int columnIndex, List<string> lines)
		{
			int zeroCount = 0;
			int oneCount = 0;
			foreach (string line in lines)
			{
				if (line[columnIndex] == '0')
					zeroCount++;
				else if (line[columnIndex] == '1')
					oneCount++;
				else
					throw new Exception("A NOT bit value was found at position " + columnIndex + " in line: " + line);
			}

			if (oneCount > zeroCount)
				return 1;
			else if (zeroCount > oneCount)
				return 0;
			else
				return -1;
		}
		#endregion
	}
}
