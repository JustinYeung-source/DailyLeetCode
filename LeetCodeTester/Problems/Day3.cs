/*
 * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
	P   A   H   N
	A P L S I I G
	Y   I   R
	And then read line by line: "PAHNAPLSIIGYIR"
*/
using NUnit.Framework;

namespace Solution
{
	class Day3 : ISolution
	{
		public string Convert(string s, int numRows)
		{

			if (numRows == 1)
			{
				return s;
			}

			string[] stringArr = new string[numRows];
			int listIndex = 0;
			bool isRising = true;

			for (int i = 0; i < s.Length; i++)
			{
				if (listIndex == numRows - 1 // looks for before it is the out of range row
				|| (listIndex == 0 && i != 0)) { isRising = !isRising; }

				stringArr[listIndex] += s[i];

				if (isRising)
				{
					listIndex++;
				}
				else
				{
					listIndex--;
				}
			}

			string final = "";
			for (int i = 0; i < numRows; i++)
			{
				final += stringArr[i];
			}

			return final;
		}

		public void Test()
		{
			string input = "PAYPALISHIRING";
			int rows = 3;

			Assert.AreEqual("PAHNAPLSIIGYIR", Convert(input, rows));

			input = "PAYPALISHIRING";
			rows = 4;

			Assert.AreEqual("PINALSIGYAHRPI", Convert(input, rows));

			input = "A";
			rows = 1;

			Assert.AreEqual("A", Convert(input, rows));
		}
	}
}
