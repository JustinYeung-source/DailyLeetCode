using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. 
 * The order of the alphabet is some permutation of lowercase letters.
 * Given a sequence of words written in the alien language, and the order of the alphabet,
 * return true if and only if the given words are sorted lexicographically in this alien language.
 */

namespace Solution
{
	class Day4 : ISolution
	{
		public bool IsAlienSorted(string[] words, string order)
		{
			for (int i = 0; i < words.Length - 1; i++)
			{
				if (!IsAlienSortedHelper(words[i], words[i + 1], order, 0)) { return false; }
			}

			return true;
		}

		bool IsAlienSortedHelper(string current, string next, string order, int index)
		{
			if (current[index] == next[index])
			{
				if (current.Length == index + 1 && current.Length <= next.Length)
				{
					return true;
				}
				if (next.Length == index + 1 && current.Length > next.Length)
				{
					return false;
				}

				return IsAlienSortedHelper(current, next, order, index + 1);
			}
			
			int currentPosition = order.IndexOf(current[index]);
			int nextPosition = order.IndexOf(next[index]);

			return currentPosition < nextPosition;
		}

		public void Test()
		{
			string[] words = {"word", "world", "row" };
			string order = "worldabcefghijkmnpqstuvxyz";

			Assert.IsFalse(IsAlienSorted(words, order));
			
			words = new string[]{ "word", "wordy", "row" };
			order = "worldabcefghijkmnpqstuvxyz";

			Assert.IsTrue(IsAlienSorted(words, order));
			
			words = new string[] { "apple", "app" };
			order = "abcdefghijklmnopqrstuvwxyz";

			Assert.IsFalse(IsAlienSorted(words, order));

			words = new string[] { "hello", "hello" };
			order = "abcdefghijklmnopqrstuvwxyz";
		}
	}
}
