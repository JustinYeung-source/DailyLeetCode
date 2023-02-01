using NUnit.Framework;

/*
 * For two strings s and t, we say "t divides s" if and only if s = t + ... + t 
 * (i.e., t is concatenated with itself one or more times).
 * Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.
 */
namespace Solution
{
	class Day2 : ISolution
	{
		/*
		 * Original brute force
		public string GcdOfStrings(string str1, string str2)
		{
			string result = "";
			bool incompleted = false;

			for (int i = 0; i <= str2.Length - 1; i++)
			{
				incompleted = false;
				string candiateSegment = str2.Substring(0, i + 1);

				// cannot complete GCD is length does not have a remainder of 0
				if (str1.Length % candiateSegment.Length != 0) { continue; }
				if (str2.Length % candiateSegment.Length != 0) { continue; }

				for (int j = 0; j < str1.Length; j += candiateSegment.Length)
				{
					string segment = str1.Substring(j, candiateSegment.Length);

					if (segment != candiateSegment) { incompleted = true; break; }
				}

				for (int j = 0; j < str2.Length; j += candiateSegment.Length)
				{
					string segment = str2.Substring(j, candiateSegment.Length);

					if (segment != candiateSegment) { incompleted = true; break; }
				}

				if (!incompleted && result.Length < candiateSegment.Length) { result = candiateSegment; }
			}

			return result;
		}
		*/

		// using Eculidean algorithm
		public string GcdOfStrings(string str1, string str2)
		{
			// we expect this as str1 = n * gcd and str2 = m * gcd. So adding them should make them equal
			if (str1 + str2 != str2 + str1) { return ""; }

			// Reorder parameters;
			if (str1.Length > str2.Length) { return GcdOfStrings(str2, str1); }

			int length = Gcd(str1.Length, str2.Length);
			return str1.Substring(0, length);
		}

		int Gcd(int a, int b)
		{
			if (a == 0) { return b; }
			
			return Gcd(b % a, a);
		}
		
		public void Test()
		{
			string str1 = "ABCABC";
			string str2 = "ABC";

			Assert.AreEqual("ABC", GcdOfStrings(str1, str2));

			str1 = "ABABAB";
			str2 = "ABAB";
			Assert.AreEqual("AB", GcdOfStrings(str1, str2));

			str1 = "LEET";
			str2 = "CODE";
			Assert.AreEqual("", GcdOfStrings(str1, str2));

			str1 = "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX";
			str2 = "TAUXXTAUXXTAUXXTAUXXTAUXX";
			Assert.AreEqual("TAUXX", GcdOfStrings(str1, str2));

			str1 = "ABABABAB";
			str2 = "ABAB";
			Assert.AreEqual("ABAB", GcdOfStrings(str1, str2));

			str1 = "AAAAAAAAA";
			str2 = "AAACCC";
			Assert.AreEqual("", GcdOfStrings(str1, str2));
		}
	}
}
