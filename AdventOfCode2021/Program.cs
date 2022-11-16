using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventOfCode2021.Day1;
using AdventOfCode2021.Day2;
using AdventOfCode2021.Day3;
using AdventOfCode2021.Day4;
using AdventOfCode2021.Day5;
using AdventOfCode2021.Day6;
using AdventOfCode2021.Day7;

namespace AdventOfCode2021
{
	/// <summary>
	/// https://adventofcode.com/2021
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			int day = 7;
			int part = 2;
			Console.WriteLine(String.Format("Output for solution day {0} - part {1}: {2}", day, part, PickSolution(day, part)));
		}

		private static long PickSolution(int day, int part)
		{
			switch (day)
			{
				case 1:
					if(part == 1)
						return new SolutionDay1().CountIncreasesInDepth();
					else
						return new SolutionDay1().CountIncreasesInSlidingDepthWindow();
				case 2:
					if (part == 1)
						return new SolutionDay2().NavigateSubmarine();
					else
						return new SolutionDay2().NavigateSubmarineWithAim();
				case 3:
					if (part == 1)
						return new SolutionDay3().BinaryDiagnosticPowerConsumption();
					else
						return new SolutionDay3().BinaryDiagnosticLifeSupportRating();
				case 4:
					if (part == 1)
						return new SolutionDay4().LocateScoreOfWinningBoard();
					else
						return new SolutionDay4().LocateScoreOfLastWinningBoard();
				case 5:
					if (part == 1)
						return new SolutionDay5().LocateMultiLineIntersect();
					else
						throw new NotImplementedException();
				case 6:
					if (part == 1)
						return new SolutionDay6Segmented().CalculateLanternFish(80);
					else
						return new SolutionDay6Segmented().CalculateLanternFish(256);
				case 7:
					if (part == 1)
						return new SolutionDay7().DetermineOptimalCrabFuelCost(FuelConsumptionType.Linear);
					else
						return new SolutionDay7().DetermineOptimalCrabFuelCost(FuelConsumptionType.Exponential);
				default:
					throw new Exception("No solution exists for day: " + day);
			}
			
		}
	}
}
