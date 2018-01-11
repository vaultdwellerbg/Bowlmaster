using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DifficultyController : MonoBehaviour {

	private static Dictionary<string, float> difficultySettings = new Dictionary<string, float>() {
		{"fox-1-secondsToShow", 30f},
		{"fox-1-finalWaveSecondsToShow", 4f},
		{"lizard-1-secondsToShow", 15f},
		{"lizard-1-finalWaveSecondsToShow", 2f},
		{"fox-2-secondsToShow", 30f},
		{"fox-2-finalWaveSecondsToShow", 3f},
		{"lizard-2-secondsToShow", 15f},
		{"lizard-2-finalWaveSecondsToShow", 1f},
		{"fox-3-secondsToShow", 25f},
		{"fox-3-finalWaveSecondsToShow", 3f},
		{"lizard-3-secondsToShow", 10f},
		{"lizard-3-finalWaveSecondsToShow", 1f}
	};

	public static Dictionary<string, float> GetValues(string attackerName)
	{
		int difficulty = PlayerPrefsManager.GetDifficulty();
		var values = new Dictionary<string, float>();	
		string prefix = attackerName + "-" + difficulty + "-";
		string key = "secondsToShow";
		values.Add(key, difficultySettings[prefix + key]);
		key = "finalWaveSecondsToShow";
		values.Add(key, difficultySettings[prefix + key]);
		return values;
	}
}
