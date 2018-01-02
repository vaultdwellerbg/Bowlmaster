using System.Collections;
using System.Collections.Generic;

public class ScoreManager {

	public static List<int> ScoreCumulative(List<int> rolls)
	{
		var scoreCardFields = new List<int>();
		int currentScore = 0;
		List<int> frameList = ScoreFrames(rolls);
		foreach (int frameScore in frameList)
		{
			currentScore += frameScore;
			scoreCardFields.Add(currentScore);
		}
		return scoreCardFields;
	}

	public static List<int> ScoreFrames(List<int> rolls)
	{
		var frameList = new List<int>();
		int[] rollsArray = rolls.ToArray();
		int rollsCount = rollsArray.Length;
		int increment;
		for (int i = 0; i < 19; i += increment)
		{
			if (!HasSecondRoll(rollsCount, i)) break;

			var currentRoll = rollsArray[i];
			int secondRoll = rollsArray[i + 1];
			int frameScore = 0;
			if (currentRoll == 10 || currentRoll + secondRoll == 10)
			{
				if (HasThirdRoll(rollsCount, i)) break;
				frameScore = currentRoll + secondRoll + rollsArray[i + 2];
			}
			else
			{
				frameScore = currentRoll + secondRoll;
			}
			frameList.Add(frameScore);
			increment = currentRoll == 10 ? 1 : 2;
		}

		return frameList;
	}

	private static bool HasSecondRoll(int rollsCount, int i)
	{
		return i + 1 < rollsCount;
	}

	private static bool HasThirdRoll(int rollsCount, int i)
	{
		return i + 2 >= rollsCount;
	}
}
