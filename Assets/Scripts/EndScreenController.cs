using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenController : MonoBehaviour {

	public Text scoreValue, highScoreValue;

	void Start ()
	{
		int finalScore = ScoreManager.finalScore;
		int highScore = PlayerPrefsManager.GetTopScore();

		if (finalScore > highScore)
		{
			PlayerPrefsManager.SetTopScore(finalScore);
		}

		scoreValue.text = ScoreManager.finalScore.ToString();
		highScoreValue.text = PlayerPrefsManager.GetTopScore().ToString();
	}
}
