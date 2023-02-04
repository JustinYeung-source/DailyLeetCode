using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
 * In other words, return true if one of s1's permutations is the substring of s2.
 */
namespace Solution
{
	class Day5 : ISolution
	{
		/* 
		 * sliding window algorithm
		 * 
		 * The steps for using the Sliding window technique are as follows:
		 * 1.) Find the size of the window on which the algorithm has to be performed.
		 * 2.) Calculate the result of the first window, as we calculate in the naive approach.
		 * 3.) Maintain a pointer on the start position.
		 * 4.) Then run a loop and keep sliding the window by one step at a time and also sliding that pointer one at a time, and keep track of the results of every window.
		 * 
		 * Source: https://www.scaler.com/topics/sliding-window-algorithm/
		 */
		public bool CheckInclusion(string s1, string s2)
		{
			if (s1.Length > s2.Length) { return false; }

			// only contains lowercase english letters
			// create an array to contain all possible characters and a running tally of what is processed
			int[] alpha = new int[26];

			// create window
			for (int i = 0; i < s1.Length; i++)
			{
				alpha[s1[i] - 'a']++;
				alpha[s2[i] - 'a']--;
			}

			if (IsZero(alpha)) { return true; }

			// slide window
			for (int i = s1.Length; i < s2.Length; i++)
			{
				alpha[s2[i] - 'a']--;
				alpha[s2[i - s1.Length] - 'a']++;
				
				if (IsZero(alpha)) { return true; }
			}

			return false;
		}

		bool IsZero(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] != 0) { return false; }
			}

			return true;
		}

		/*
		 * using backtracing, but does not comply to time restrictions.
		List<string> candidatePermutations = new List<string>();
		public bool CheckInclusion(string s1, string s2)
		{
			if (s1.Length > s2.Length) { return false; }
			GeneratePermutations(s1, "");

			for (int i = 0; i < candidatePermutations.Count; i++)
			{
				if (s2.Contains(candidatePermutations[i]))
				{
					return true;
				}
			}

			return false;
		}

		void GeneratePermutations(string s1, string answer)
		{
			if (s1.Length == 0)
			{ 
				candidatePermutations.Add(answer);
				return; 
			}

			for (int i = 0; i < s1.Length; i++)
			{
				GeneratePermutations(s1.Substring(0, i) + s1.Substring(i + 1), answer + s1[i]);
			}
		}
		*/

		public void Test()
		{
			string s1 = "ab";
			string s2 = "eidbaooo";

			Assert.IsTrue(CheckInclusion(s1, s2));

			s2 = "eidboaoo";
			Assert.IsFalse(CheckInclusion(s1, s2));

			s1 = "dinitrophenylhydrazine";
			s2 = "acetylphenylhydrazine";
		}
	}
}
