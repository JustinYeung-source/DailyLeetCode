using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Leetcode 1626 (Best Team With No Conflicts)
 * You are the manager of a basketball team. For the upcoming tournament, you want to choose the team with the highest overall score.
 * The score of the team is the sum of scores of all the players in the team.
 * However, the basketball team is not allowed to have conflicts.
 * A conflict exists if a younger player has a strictly higher score than an older player. 
 * A conflict does not occur between players of the same age.
 * Given two lists, scores and ages, where each scores[i] and ages[i] represents the score and age of the ith player, 
 * respectively, return the highest overall score of all possible basketball teams.
 */

namespace Solution
{
	class Day1 : ISolution
	{
		public class Player
		{
			public int score;
			public int age;

			public Player(int score, int age)
			{
				this.score = score;
				this.age = age;
			}
		}

		public int BestTeamScore(int[] scores, int[] ages)
		{
			List<Player> team = new List<Player>();
			int result = 0;

			for (int i = 0; i < scores.Length; i++)
			{
				team.Add(new Player(scores[i], ages[i]));
			}

			team = team.OrderBy(teamMemembers=>teamMemembers.age).ThenBy(teamMemembers=>teamMemembers.score).ToList();

			int[] dp = new int[team.Count];

			for (int i = 0; i < team.Count; i++)
			{
				dp[i] = team[i].score;

				for (int j = 0; j < i; j++)
				{
					if (team[j].age == team[i].age)
					{
						dp[i] = Math.Max(dp[i], team[i].score + dp[j]);
					}
					else if (team[j].age < team[i].age && team[j].score <= team[i].score)
					{
						dp[i] = Math.Max(dp[i], team[i].score + dp[j]);
					}
				}

				result = Math.Max(result, dp[i]);
			}

			return result;
		}

		public void Test()
		{
			int[] scores = new int[] { 1, 3, 5, 10, 15 };
			int[] ages = new int[] { 1, 2, 3, 4, 5 };

			int result;

			result = BestTeamScore(scores, ages);
			
			Assert.AreEqual(34, result);
		}
	}
}
