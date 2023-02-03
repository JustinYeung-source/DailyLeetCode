using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution;

namespace LeetCodeTester
{
	class Program
	{
		public static List<ISolution> problems = new List<ISolution>(); 

		static void Main(string[] args)
		{
			Initialize();

			foreach (ISolution problem in problems)
			{
				try
				{
					problem.Test();
					Console.WriteLine(problem + " Pass");
				}
				catch
				{
					Console.WriteLine(problem + " Fail");
				}
			}

			Console.ReadKey();
		}

		static void Initialize()
		{
			Day1 day1 = new Day1();
			Day2 day2 = new Day2();
			Day3 day3 = new Day3();

			problems.Add(day1);
			problems.Add(day2);
			problems.Add(day3);
		}
	}
}
