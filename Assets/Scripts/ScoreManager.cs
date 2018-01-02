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
		for (int i = 0; frameList.Count < 10; i += increment)
		{
			int? frameScore = GetFrameScore(rollsArray, i);
			if (frameScore == null) break;
			frameList.Add(frameScore.Value);
			increment = rollsArray[i] == 10 ? 1 : 2;
		}

		return frameList;
	}

	private static int? GetFrameScore(int[] rollsArray, int index)
	{
		int rollsCount = rollsArray.Length;
		if (!HasNextRoll(rollsCount, index)) return null;

		var currentRoll = rollsArray[index];
		int nextRoll = rollsArray[index + 1];

		if (IsStrikeOrSpare(currentRoll, nextRoll))
		{
			if (!HasSubsequentRoll(rollsCount, index)) return null;
			int subsquentRoll = rollsArray[index + 2];
			return currentRoll + nextRoll + subsquentRoll;
		}
		else
		{
			return currentRoll + nextRoll;
		}
	}

	private static bool HasNextRoll(int rollsCount, int i)
	{
		return i + 1 < rollsCount;
	}

	private static bool IsStrikeOrSpare(int currentRoll, int secondRoll)
	{
		return currentRoll == 10 || currentRoll + secondRoll == 10;
	}

	private static bool HasSubsequentRoll(int rollsCount, int i)
	{
		return i + 2 < rollsCount;
	}
}
