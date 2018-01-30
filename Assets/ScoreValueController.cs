using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreValueController : MonoBehaviour {

	void Start ()
	{
		GetComponent<Text>().text = ScoreManager.finalScore.ToString();
	}
}
