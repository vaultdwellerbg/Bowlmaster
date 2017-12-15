using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	private Text standingPinsCount;
	private int lastStandingCount = -1;

	public float lastCountChangeTime;

	void Start ()
	{
		standingPinsCount = GameObject.Find("StandingPinsCount").GetComponent<Text>();
	}
	
	void Update ()
	{
		standingPinsCount.text = CountStanding().ToString();
	}

	public int CountStanding()
	{
		return GetStanding().Count;
	}

	public List<PinController> GetStanding()
	{
		List<PinController> standingPins = new List<PinController>();
		PinController[] pins = GameObject.FindObjectsOfType<PinController>();
		for (int i = 0; i < pins.Length; i++)
		{
			if (pins[i].IsStanding())
			{
				standingPins.Add(pins[i]);
			}
		}
		return standingPins;
	}

	public void UpdateStandingCountIfChanged()
	{
		int currentStandingCount = CountStanding();
		if (currentStandingCount != lastStandingCount)
		{
			UpdateLastStandingData(currentStandingCount);
		}
	}

	private void UpdateLastStandingData(int currentStandingCount)
	{
		lastCountChangeTime = Time.time;
		lastStandingCount = currentStandingCount;
	}

	public void ResetCount()
	{
		lastStandingCount = -1;
	}

	public void DisplayCountChanging()
	{
		standingPinsCount.color = Color.red;
	}

	public void DisplayFinalScore()
	{
		standingPinsCount.color = Color.green;
	}
}
