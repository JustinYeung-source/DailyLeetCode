using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
	class Day7 : ISolution
	{
		public int[] Shuffle(int[] nums, int n)
		{
			int[] results = new int[nums.Length];
			
			int storageIndex = 0;
			for (int i = 0; i < n; i++, storageIndex += 2)
			{
				results[storageIndex] = nums[i];
				results[storageIndex + 1] = nums[i + n];
			}

			return results;
		}

		public void Test()
		{
			int[] num = new int[] { 2, 5, 1, 3, 4, 7 };
			int n = 3;

			Assert.AreEqual(new int[] { 2, 3, 5, 4, 1, 7 }, Shuffle(num, n));

			num = new int[] { 1, 2, 3, 4, 4, 3, 2, 1 };
			n = 4;

			Assert.AreEqual(new int[] { 1, 4, 2, 3, 3, 2, 4, 1 }, Shuffle(num, n));

			num = new int[] { 1, 1, 2, 2 };
			n = 2;

			Assert.AreEqual(new int[] { 1, 2, 1, 2 }, Shuffle(num, n));
		}
	}
}
