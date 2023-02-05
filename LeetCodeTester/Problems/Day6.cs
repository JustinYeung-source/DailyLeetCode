using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given two strings s and p, return an array of all the start indices of p's anagrams in s.
 * You may return the answer in any order.
 * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, 
 * typically using all the original letters exactly once.
 */

namespace Solution
{
	class Day6 : ISolution
	{
		// using Sliding window
		public IList<int> FindAnagrams(string s, string p)
		{
			List<int> results = new List<int>();
			
			if (s.Length < p.Length)
			{
				return results;
			}

			int[] alpha = new int[26];

			for (int i = 0; i < p.Length; i++)
			{
				alpha[p[i] - 'a']++;
				alpha[s[i] - 'a']--;
			}

			if (IsZero(alpha)) { results.Add(0); }

			for (int i = p.Length; i < s.Length; i++)
			{
				alpha[s[i] - 'a']--;
				alpha[s[i - p.Length] - 'a']++;

				if (IsZero(alpha)) { results.Add(i - (p.Length - 1)); }
			}
	
			return results;
		}

		bool IsZero(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] != 0) { return false; }
			}

			return true;
		}

		public void Test()
		{
			string s = "cbaebabacd";
			string p = "abc";

			Assert.AreEqual(new int[] { 0, 6 }, FindAnagrams(s, p));
			
			s = "abab";
			p = "ab";

			Assert.AreEqual(new int[] { 0, 1, 2 }, FindAnagrams(s, p));
		}
	}
}
