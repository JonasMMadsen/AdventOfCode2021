using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AdventOfCode2021.Day5
{
	public class Line
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="lineData">Data to parse, that describes both the beginning and ending point of this line. 
		/// Eg. 365,809 -> 365,271</param>
		public Line(string lineData)
		{
			string[] points = lineData.Split(new string[] { "->" }, StringSplitOptions.None);
			this.Start = ParsePoint(points[0].Trim());
			this.End = ParsePoint(points[1].Trim());

			if (Start.X == End.X)
				this.Direction = LineDirection.Vertical;
			else if(Start.Y == End.Y)
				this.Direction = LineDirection.Horizontal;
			else
				this.Direction = LineDirection.Diagonal;
		}

		/// <summary>
		/// The beginning point that makes up this line.
		/// </summary>
		public Point Start { get; private set; }
		
		/// <summary>
		/// The ending point that makes up this line.
		/// </summary>
		public Point End { get; private set; }

		/// <summary>
		/// What does this line go in?
		/// </summary>
		public LineDirection Direction { get; private set; }

		/// <summary>
		/// Parse a data for a single Point in string form.
		/// Eg. 971,362
		/// </summary>
		/// <param name="pointData">Point data to parse.</param>
		/// <returns>New <see cref="Point"/> instance based on the parsed data.</returns>
		private Point ParsePoint(string pointData)
		{
			string[] positions = pointData.Split(',');
			return new Point(Convert.ToInt32(positions[0]), Convert.ToInt32(positions[1]));
		}
	}

	
}
