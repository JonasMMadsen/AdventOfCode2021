using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace AdventOfCode2021.Day6
{
	public class SolutionDay6Segmented
	{
		private const int DAY = 6;
		private const int LANTERN_FISH_START_AGE = 8;
		private const int RESET_AGE = LANTERN_FISH_START_AGE - 2;

		private Stopwatch stopWatch;

		public SolutionDay6Segmented() { this.stopWatch = new Stopwatch(); }

		/// <summary>
		/// Calculate the total number of present lantern fish, after a given set of days has passed.
		/// Current fish population is read from Solution input file.
		/// </summary>
		/// <param name="days">The number of days the collection of lantern fish is allowed to breed.</param>
		/// <returns>The total number of found lantern fish.</returns>
		public long CalculateLanternFish(int days)
		{
			string inputFishAgeString = Util.ReadInput(DAY);
			List<int> fishSchool = inputFishAgeString.Split(',').Select(Int32.Parse).ToList<int>();

			return CalculateLanternFish(days, fishSchool);
		}

		/// <summary>
		/// Calculate the total number of present lantern fish, after a given set of days has passed.
		/// </summary>
		/// <param name="days">The number of days the collection of lantern fish is allowed to breed.</param>
		/// <param name="fishSchool">Collection of initialized <see cref="LanternFish"/> to breed.</param>
		/// <returns>The total number of found lantern fish.</returns>
		public long CalculateLanternFish(int days, List<int> fishSchool)
		{
			long[] fishSegments = SegmentLanternFish(fishSchool);

			// For debug purposes
			PrintFishSegments(0, fishSegments);

			for (int i = 0; i < days; i++)
			{
				stopWatch.Start();

				long newFish = 0;
				for (int j = 0; j < fishSegments.Length; j++)
				{
					// All lantern fish who now have achieved "spawn" age, are removed from the population, 
					// and are added again (both at rest age and new age), after all the other fish have been aged
					if (j == 0)
					{
						newFish = fishSegments[j];
						fishSegments[j] = 0;
					}
					else
						fishSegments[j - 1] = fishSegments[j];
				}

				fishSegments[RESET_AGE] += newFish;
				fishSegments[LANTERN_FISH_START_AGE] = newFish;
		
				stopWatch.Stop();

				Console.WriteLine("Fish after day {0}: {1} - Time taken {2}", i, fishSegments.Sum(), stopWatch.Elapsed);
				stopWatch.Reset();
			}

			return fishSegments.Sum();
		}

		/// <summary>
		/// Segment the entire school of lantern fish into matching age groups.
		/// </summary>
		/// <param name="fishSchool">Collection of initialized <see cref="LanternFish"/> to breed.</param>
		/// <returns>Full list of segments, where each segment value is the total number of fish with that age.</returns>
		private long[] SegmentLanternFish(List<int> fishSchool)
		{
			long[] fishSegments = Enumerable.Repeat(0L, LANTERN_FISH_START_AGE + 1).ToArray<long>();
			foreach (long fish in fishSchool)
				fishSegments[fish]++;

			return fishSegments;
		}

		private void PrintFishSegments(int day, long[] fishSegments)
		{
			Console.WriteLine(String.Format("Fish segmentation pr. age for day {0}:", day));
			for (int i = 0; i < fishSegments.Length; i++)
				Console.WriteLine(String.Format("Lantern fish age {0}: {1}", i, fishSegments[i]));
			
		}
	}
}
