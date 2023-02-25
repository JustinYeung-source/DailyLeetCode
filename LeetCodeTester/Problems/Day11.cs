using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *
 * Given an n x n grid containing only values 0 and 1, 
 * where 0 represents water and 1 represents land, find a water cell
 * such that its distance to the nearest land cell is maximized, and return the distance.
 * If no land or water exists in the grid, return -1.
 * The distance used in this problem is the Manhattan distance:
 * the distance between two cells (x0, y0) and (x1, y1) is |x0 - x1| + |y0 - y1|.
 */
namespace Solution
{
	class Day11 : ISolution
	{
		List<(int, int)> landPoints = new List<(int, int)>();
		int[][] visted;
		public int MaxDistance(int[][] grid)
		{
			int distance = -1;
			
			visted = (int[][])grid.Clone();
			
			// Add all land
			for (int i = 0; i < visted.Length; i++)
			{
				for (int j = 0; j < visted.Length; j++)
				{
					if (visted[i][j] == 1)
					{
						landPoints.Add((i, j));
					}
				}
			}

			if (landPoints.Count == visted.Length * visted.Length) { return distance; }

			while (landPoints.Count != 0)
			{
				int currentPoints = landPoints.Count;
				for (int i = 0; i < currentPoints; i++)
				{
					GridValdiator((landPoints[i].Item1 - 1, landPoints[i].Item2), visted.Length);
					GridValdiator((landPoints[i].Item1 + 1, landPoints[i].Item2), visted.Length);
					GridValdiator((landPoints[i].Item1, landPoints[i].Item2 - 1), visted.Length);
					GridValdiator((landPoints[i].Item1, landPoints[i].Item2 + 1), visted.Length);
				}

				landPoints.RemoveRange(0, currentPoints);
				distance++;
			}

			return distance;
		}

		void GridValdiator((int, int) candidate, int maxWidth)
		{
			if (candidate.Item1 < 0 || candidate.Item1 >= maxWidth
				|| candidate.Item2 < 0 || candidate.Item2 >= maxWidth)
			{
				return;
			}

			if (visted[candidate.Item1][candidate.Item2] == 0)
			{
				visted[candidate.Item1][candidate.Item2] = 1;
				landPoints.Add(candidate);
			}
		}

		public void Test()
		{
			int[][] gridInput = new int[][] { new int[] { 1, 0, 1 }, new int[] { 0, 0, 0 }, new int[] { 1, 0, 1 } };
		
			Assert.AreEqual(2, MaxDistance(gridInput));
		}
	}
}
