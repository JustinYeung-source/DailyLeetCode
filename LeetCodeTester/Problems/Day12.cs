using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * You are given an integer n, the number of nodes in a directed graph where the nodes
 * are labeled from 0 to n - 1. Each edge is red or blue in this graph, 
 * and there could be self-edges and parallel edges.
 * You are given two arrays redEdges and blueEdges where:
 * redEdges[i] = [ai, bi] indicates that there is a directed red edge 
 * from node ai to node bi in the graph, and
 * blueEdges[j] = [uj, vj] indicates that there is a directed blue edge
 * from node uj to node vj in the graph.
 * Return an array answer of length n, 
 * where each answer[x] is the length of the shortest path from node 0 to node x
 * such that the edge colors alternate along the path, or -1 if such a path does not exist.
 */

namespace Solution
{
	class Day12 : ISolution
	{
		public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
		{
			int[] answer = new int[n];
			for (int i = 0; i < n; i++)
			{
				answer[i] = -1;
			}

			Dictionary<int, List<List<int>>> allEdges = new Dictionary<int, List<List<int>>>();
			// node, color
			bool[,] visited = new bool[n, 2];
			Queue<int[]> queue = new Queue<int[]>();

			foreach (int[] edges in redEdges)
			{
				if (!allEdges.ContainsKey(edges[0]))
				{
					allEdges.Add(edges[0], new List<List<int>>());
				}

				allEdges[edges[0]].Add(new List<int>() { edges[1], 0 });
			}

			foreach (int[] edges in blueEdges)
			{
				if (!allEdges.ContainsKey(edges[0]))
				{
					allEdges.Add(edges[0], new List<List<int>>());
				}

				allEdges[edges[0]].Add(new List<int>() {edges[1] , 1});
			}

			queue.Enqueue(new int[] { 0, 0, -1 });
			visited[0, 0] = true;
			visited[0, 1] = true;
			int[] element;
			while (queue.Count != 0)
			{
				element = queue.Dequeue();
				int node = element[0];
				int steps = element[1];
				int prevColor = element[2];

				List<List<int>> neighbours;

				if (!allEdges.TryGetValue(node, out neighbours))
				{
					continue;
				}

				foreach (List<int> neighbour in neighbours)
				{
					if (neighbour[1] != prevColor && visited[neighbour[0], neighbour[1]] == false)
					{
						queue.Enqueue(new int[] { neighbour[0], steps + 1, neighbour[1]});
						if (answer[neighbour[0]] == -1) { answer[neighbour[0]] = steps + 1; } 
					}
				}
			}

			answer[0] = 0;
			return answer;
		}

		public void Test()
		{
			int n = 3;
			int[][] redInput = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } };
		}
	}
}
