using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;
using System.IO;

namespace AdventOfCode2021
{
	class Util
	{
		public static string DownloadInput(Uri uri)
		{
			try
			{
				return new WebClient().DownloadString(uri);
			}
			catch (Exception ex)
			{
				throw new Exception("Error while trying to download: " + uri, ex);
			}

		}

		public static string ReadInput(int day)
		{
			return ReadInput(day, "");
		}

		/// <summary>
		/// Read input data for the given day.
		/// </summary>
		/// <param name="day">The task day to obtain for.</param>
		/// <param name="suffix">Suffix that is appended to the solution data (in case more then input exists for the day).</param>
		/// <returns>The read data in string form.</returns>
		public static string ReadInput(int day, string suffix)
		{
			string suffixText = "";
			if (!String.IsNullOrWhiteSpace(suffix))
				suffixText = "-" + suffix;

			string resourceName = "AdventOfCode2021.Input.Solution" + day + "-Input" + suffixText + ".txt";

			try
			{
				// List all current project resources (Debug only)
				//string[] resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();

				// REMEMBER: Set "Build Action" for the added resource file to "Embedded Resource"
				Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
				using (StreamReader reader = new StreamReader(stream))
					return reader.ReadToEnd();
			}
			catch (NullReferenceException ex)
			{
				throw new Exception("Unable to locate input resource for day, using resource name: " + resourceName, ex);
			}
			catch (Exception ex)
			{
				throw new Exception("Error while trying to get input for day, using resource name: " + resourceName, ex);
			}
		}
	}
}
