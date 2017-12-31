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
		int frameScore = 0;
		int ballsToHitForScore = 2;
		foreach (int roll in rolls)
		{
			if (IsStrike(roll))
			{
				ballsToHitForScore = 3;
			}
			frameScore += roll;
			ballsToHitForScore--;
			if (IsEndOfFrameScore(ballsToHitForScore))
			{
				frameList.Add(frameScore);
				frameScore = 0;
				ballsToHitForScore = 2;
			}
		}

		return frameList;
	}

	private static bool IsStrike(int roll)
	{
		return roll == 10;
	}

	private static bool IsEndOfFrameScore(int ballsToHitForScore)
	{
		return ballsToHitForScore == 0;
	}
}
