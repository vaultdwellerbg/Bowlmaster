﻿using System.Collections;
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
		int prevRoll = 0;
		foreach (int roll in rolls)
		{
			if (prevRoll == 0)
			{
				prevRoll = roll;
			}
			else
			{
				int frameScore = roll + prevRoll;
				frameList.Add(frameScore);
				prevRoll = 0;
			}
		}

		return frameList;
	}

}
