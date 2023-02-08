using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].
 * Each element nums[i] represents the maximum length of a forward jump from index i. In other words, 
 * if you are at nums[i], you can jump to any nums[i + j] where:
 * 
 * 0 <= j <= nums[i] and
 * i + j < n
 * 
 * Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].
 */
namespace Solution
{
	class Day9 : ISolution
	{
		public int Jump(int[] nums)
		{
			if (nums.Length == 1)
			{
				return 0;
			}
			else if (nums[0] >= nums.Length - 1)
			{
				return 1;
			}

			// must start at 0
			int position = 0;
			int result = nums.Length;
			int numOfSteps = 0;

			while (position < nums.Length - 1)
			{
				int step = nums[position];

				int candidateStep = 0;
				int candidatePosition = 0;
				for (int i = position + 1; i < position + step + 1; i++)
				{
					if (i >= nums.Length - 1) { candidatePosition = nums.Length; break; }
					
					int currentCandidateStep = nums[i] + i;
					if (currentCandidateStep > candidateStep)
					{
						candidatePosition = i; 
						candidateStep = currentCandidateStep;
					}
				}

				numOfSteps++;
				position = candidatePosition;
			}

			return Math.Min(result, numOfSteps);
		}

		public void Test()
		{ 
			int[] input;
			input = new int[] { 1 };
			Assert.AreEqual(0, Jump(input));

			input = new int[] { 1, 2 };
			Assert.AreEqual(1, Jump(input));

			input = new int[] { 2, 3, 1, 1, 4 };
			Assert.AreEqual(2, Jump(input));

			input = new int[] { 1, 1, 1, 1, 1 };
			Assert.AreEqual(4, Jump(input));

			input = new int[] { 1, 2, 3 };
			Assert.AreEqual(2, Jump(input));

			input = new int[] { 3, 4, 3, 2, 5, 4, 3 };
			Assert.AreEqual(3, Jump(input));

			input = new int[] { 7, 0, 9, 6, 9, 6, 1, 7, 9, 0, 1, 2, 9, 0, 3};
			Assert.AreEqual(2, Jump(input));
		}
	}
}
