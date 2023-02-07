using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You are visiting a farm that has a single row of fruit trees arranged from left to right. 
 * The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.
 * You want to collect as much fruit as possible. However, the owner has some strict rules that you must follow:
 * You only have two baskets, and each basket can only hold a single type of fruit. There is no limit on the amount of fruit each basket can hold.
 * Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right.
 * The picked fruits must fit in one of your baskets.
 * Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
 * Given the integer array fruits, return the maximum number of fruits you can pick
 */
namespace Solution
{
	class Day8 : ISolution
	{
		public int TotalFruit(int[] fruits)
		{
			Dictionary<int, int> buckets = new Dictionary<int, int>();
			int result = 0;
			int offset = 0;

			for (int i = 0; i < fruits.Length; i++)
			{
				if (!buckets.ContainsKey(fruits[i]))
				{
					buckets[fruits[i]] = 0;
				}
				
				buckets[fruits[i]]++;

				while (buckets.Count > 2)
				{
					buckets[fruits[offset]]--;
					if (buckets[fruits[offset]] == 0) { buckets.Remove(fruits[offset]); }
					offset++;
				}

				int count = 0;
				foreach (int item in buckets.Values)
				{
					count += item;
				}

				result = Math.Max(result, count);
			}

			return result;
		}

		public void Test()
		{
			int[] input = new int[] { 1, 2, 1 };

			Assert.AreEqual(3, TotalFruit(input));
		}
	}
}
