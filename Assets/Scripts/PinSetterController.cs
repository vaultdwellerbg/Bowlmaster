using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour {

	private PinController[] pins;
	private Text standingPinsCount;

	private void Start()
	{
		pins = GameObject.FindObjectsOfType<PinController>();
		standingPinsCount = GameObject.Find("StandingPinsCount").GetComponent<Text>();
	}

	public int CountStanding()
	{
		int standingCount = 0;
		for (int i = 0; i < pins.Length; i++)
		{
			if (pins[i].IsStanding())
			{
				standingCount++;
			}
		}

		return standingCount;
	}

	private void Update()
	{
		standingPinsCount.text = CountStanding().ToString();
	}
}
