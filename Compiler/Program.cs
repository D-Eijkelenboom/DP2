using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Tokenizer;

namespace Compiler
{
	class Program
	{
		static void Main(string[] args)
		{
			int minRage = 1, maxRange = 2;
			Console.WindowWidth = 100;

			Console.WriteLine("Give sample filename, options: " + minRage + " to " + maxRange);
			string sample = Console.ReadLine();
			int fileNumber = 1;
			try
			{
				fileNumber = Convert.ToInt32(sample);
				if (fileNumber < minRage || fileNumber > maxRange)
					fileNumber = 1;
			}
			catch (Exception e)
			{
				Console.WriteLine("Chould not convert to number");
				fileNumber = minRage;
			}

			Tokenizer.Tokenizer t = new Tokenizer.Tokenizer();
			t.createTokenList(fileNumber.ToString());			
			t.PrintPartnerStack();
			t.PrintTokenList();

			Console.ReadLine();
		}
	}
}
