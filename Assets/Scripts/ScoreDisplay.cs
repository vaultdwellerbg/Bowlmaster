using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

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

	private static string FormatRolls(List<int> rolls)
	{
		return string.Empty;
	}
}
