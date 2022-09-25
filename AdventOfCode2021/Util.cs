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
			try
			{
				// List all current project resources (Debug only)
				//string[] resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
				
				// REMEMBER: Set "Build Action" for the added resource file to "Embedded Resource"
				Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2021.Input.Solution" + day + "-Input.txt");
				using (StreamReader reader = new StreamReader(stream))
					return reader.ReadToEnd();
			}
			catch (NullReferenceException ex)
			{
				throw new Exception("Unable to locate input resource for day: " + day, ex);
			}
			catch (Exception ex)
			{
				throw new Exception("Error while trying to get input for day: " + day, ex);
			}

		}
	}
}
