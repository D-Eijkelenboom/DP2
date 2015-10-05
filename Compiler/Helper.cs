using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
	public class Helper
	{
		public Helper()
		{

		}

		public static string GetProjectFolder(string path)
		{
			string[] split = path.Split('\\');
			string projectpath = "";

			for (int i = 0; i < split.Length-2; i++)
			{
				projectpath += split[i] + "\\";
			}

			return projectpath;
		}
	}
}
