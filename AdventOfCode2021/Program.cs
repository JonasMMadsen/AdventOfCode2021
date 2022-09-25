using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
	class Program
	{
		static void Main(string[] args)
		{
			int day = 4;
			int part = 1;
			Console.WriteLine(String.Format("Output for solution day {0} - part {1}: {2}", day, part, PickSolution(day, part)));
		}

		private static string PickSolution(int day, int part)
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
						return new SolutionDay2().NavigateSubmarine().ToString();
					else
						return new SolutionDay2().NavigateSubmarineWithAim().ToString();
				case 3:
					if (part == 1)
						return new SolutionDay3().BinaryDiagnosticPowerConsumption().ToString();
					else
						return new SolutionDay3().BinaryDiagnosticLifeSupportRating().ToString();
				case 4:
					if (part == 1)
						return new SolutionDay4().LocateScoreOfWinningBoard().ToString();
					else
						return null;
				default:
					throw new Exception("No solution exists for day: " + day);
			}
			
		}
	}
}
