using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	private void Start()
	{
		for (int i = 0; i < rollTexts.Length - 1; i++)
		{
			rollTexts[i].text = "1";
		}

		for (int i = 0; i < frameTexts.Length; i++)
		{
			frameTexts[i].text = (i*2).ToString();
		}
	}

	public void FillRollCard(List<int> rolls)
	{

	}
}
