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
				catch (Exception e)
				{
					Console.WriteLine(problem + " Fail: " + e.ToString());
				}
			}

			Console.ReadKey();
		}

		static void Initialize()
		{
			Day1 day1 = new Day1();
			Day2 day2 = new Day2();
			Day3 day3 = new Day3();
			Day4 day4 = new Day4();
			Day5 day5 = new Day5();
			Day6 day6 = new Day6();
			Day7 day7 = new Day7();

			problems.Add(day1);
			problems.Add(day2);
			problems.Add(day3);
			problems.Add(day4);
			problems.Add(day5);
			problems.Add(day6);
			problems.Add(day7);
		}
	}
}
