using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day6
{
	public class LanternFish
	{
		private const int RESET_AGE = 6;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="startAge">The age counter to start this lantern fish at.</param>
		public LanternFish(int startAge)
		{
			this.Age = startAge;
		}

		public int Age { get; private set; }

		/// <summary>
		/// Increment the age counter of this lantern fish.
		/// If the counter reaches zero, it is reset.
		/// </summary>
		/// <returns>True if the age counter has reached zero, requesting the spawn of a new lantern fish. Otherwise false.</returns>
		public bool IncrementAge()
		{
			this.Age--;

			if (this.Age < 0)
			{
				this.Age = RESET_AGE;
				return true;
			}

			return false;
		}

		public override string ToString()
		{
			return this.Age.ToString();
		}
	}
}
