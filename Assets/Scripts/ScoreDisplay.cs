using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	private const string GUTTERBALL_SYMBOL = "-";
	private const string STRIKE_SYMBOL = "X";
	private const string EMPTY_ROLL_SYMBOL = " ";
	private const string SPARE_SYMBOL = "/";

	public void FillRolls(List<int> rolls)
	{
		string formattedRolls = ScoreDisplay.FormatRolls(rolls);
		for (int i = 0; i < formattedRolls.Length; i++)
		{
			rollTexts[i].text = formattedRolls[i].ToString();
		}
	}

	public void FillFrames(List<int> frames)
	{
		for (int i = 0; i < frames.Count; i++)
		{
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls(List<int> rolls)
	{
		var formatedRollsBuilder = new StringBuilder();
		for (int i = 0; i < rolls.Count; i++)
		{
			int roll = rolls[i];
			int numberOfRollsSoFar = formatedRollsBuilder.Length;
			if (IsGutterBall(roll))
			{
				formatedRollsBuilder.Append(GUTTERBALL_SYMBOL);
			}
			else if (IsStrike(roll, numberOfRollsSoFar))
			{
				formatedRollsBuilder.Append(STRIKE_SYMBOL);
				if (!IsLastFrame(numberOfRollsSoFar))
				{
					formatedRollsBuilder.Append(EMPTY_ROLL_SYMBOL);
				}
			}
			else if (IsSpare(rolls, i, roll, numberOfRollsSoFar))
			{
				formatedRollsBuilder.Append(SPARE_SYMBOL);
			}
			else
			{
				formatedRollsBuilder.Append(roll);
			}

		}
		return formatedRollsBuilder.ToString();
	}

	private static bool IsGutterBall(int roll)
	{
		return roll == 0;
	}

	private static bool IsStrike(int roll, int numberOfRollsSoFar)
	{
		return roll == 10 && (numberOfRollsSoFar % 2 == 0 || numberOfRollsSoFar >= 18);
	}

	private static bool IsLastFrame(int numberOfRollsSoFar)
	{
		return numberOfRollsSoFar >= 18;
	}

	private static bool IsSpare(List<int> rolls, int i, int roll, int numberOfRollsSoFar)
	{
		return (numberOfRollsSoFar % 2 != 0 || numberOfRollsSoFar >= 19) && roll + rolls[i - 1] == 10;
	}
}
