using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using AdventOfCode2021.Day6;

namespace AdventOfCode2021
{
	public class SolutionDay6
	{
		private const int DAY = 6;
		private const int LANTERN_FISH_START_AGE = 8;

		private Stopwatch stopWatch;

		public SolutionDay6() { this.stopWatch = new Stopwatch(); }

		/// <summary>
		/// Calculate the total number of present lantern fish, after a given set of days has passed.
		/// Current fish population is read from Solution input file.
		/// </summary>
		/// <param name="days">The number of days the collection of lantern fish is allowed to breed.</param>
		/// <returns>The total number of found lantern fish.</returns>
		public long CalculateLanternFish(int days)
		{
			string inputFishAgeString = Util.ReadInput(DAY);
			int[] fishAges = inputFishAgeString.Split(',').Select(Int32.Parse).ToArray<int>();

			List<LanternFish> fishSchool = new List<LanternFish>();
			foreach (int age in fishAges)
				fishSchool.Add(new LanternFish(age));

			return CalculateLanternFish(days, fishSchool);
		}

		/// <summary>
		/// Calculate the total number of present lantern fish, after a given set of days has passed.
		/// </summary>
		/// <param name="days">The number of days the collection of lantern fish is allowed to breed.</param>
		/// <param name="fishSchool">Collection of initialized <see cref="LanternFish"/> to breed.</param>
		/// <returns>The total number of found lantern fish.</returns>
		public long CalculateLanternFish(int days, List<LanternFish> fishSchool)
		{
			// New fish are collected separately, because their age counter should not be incremented before next day cycle
			List<LanternFish> newFish = new List<LanternFish>();
			for (int i = 0; i < days; i++)
			{
				stopWatch.Start();
				// For debug purposes
				//PrintFishes(i, fishSchool);

				foreach (LanternFish fish in fishSchool)
				{
					if (fish.IncrementAge())
						newFish.Add(new LanternFish(LANTERN_FISH_START_AGE));
				}

				fishSchool.AddRange(newFish);
				newFish.Clear();
				stopWatch.Stop();

				Console.WriteLine("Fish after day {0}: {1} - Time taken {2}", i, fishSchool.Count, stopWatch.Elapsed);
				stopWatch.Reset();
			}

			return fishSchool.Count;
		}

		private void PrintFishes(int day, List<LanternFish> fishSchool)
		{
			Console.WriteLine("{0}: {1}", day, String.Join(",", fishSchool));
		}
	}
}
