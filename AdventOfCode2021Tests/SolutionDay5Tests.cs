using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day5;

namespace AdventOfCode2021.Tests
{
	/// <summary>
	/// Testing private methods
	/// https://stackoverflow.com/questions/9122708/unit-testing-private-methods-in-c-sharp
	/// </summary>
	[TestClass()]
	public class SolutionDay5Tests
	{
		private List<Line> lines;

		[TestInitialize]
		public void Setup()
		{
			this.lines = new List<Line>();
			lines.Add(new Line("0,9 -> 5,9"));
			lines.Add(new Line("8,0 -> 0,8"));
			lines.Add(new Line("9,4 -> 3,4"));
			lines.Add(new Line("2,2 -> 2,1"));
			lines.Add(new Line("7,0 -> 7,4"));
			lines.Add(new Line("6,4 -> 2,0"));
			lines.Add(new Line("0,9 -> 2,9"));
			lines.Add(new Line("3,4 -> 1,4"));
			lines.Add(new Line("0,0 -> 8,8"));
			lines.Add(new Line("5,5 -> 8,2"));
		}

		[TestMethod()]
		public void InitializeMapTest()
		{
			SolutionDay5 day = new SolutionDay5();
			PrivateObject obj = new PrivateObject(day);
			int[,] map = (int[,])obj.Invoke("InitializeMap", lines);

			int actualHeight = map.GetLength(0);
			int expectedHeight = 9;
			Assert.AreEqual(expectedHeight, actualHeight, "Height did not match!");

			int actualWidth = map.GetLength(1);
			int expectedWidth = 9;
			Assert.AreEqual(expectedWidth, actualWidth, "Width did not match!");
		}

		[TestMethod()]
		public void LocateMultiLineIntersectTest()
		{
			SolutionDay5 day = new SolutionDay5();
			int actualIntersects = day.LocateMultiLineIntersect();

			// TODO: Invoke full LocateMultiLineIntersect but with test data

			int expectedIntersects = 5;
			Assert.AreEqual(expectedIntersects, actualIntersects, "Number of total lines intersects did not match!!");
		}
	}
}