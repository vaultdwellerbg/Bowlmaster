using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public bool ballLeftSpaceBeforePins = false;
	public float lastCountChangeTime;

	private Text standingPinsCount;
	private int lastStandingCount = -1;
	private bool initialPinCountStored = false;
	private int initialPinCount;
	private PinSetterController pinSetterController;

	private const float SECONDS_TO_SETTLE = 5f;

	void Start ()
	{
		standingPinsCount = GameObject.Find("StandingPinsCount").GetComponent<Text>();
		pinSetterController = GameObject.FindObjectOfType<PinSetterController>();
	}
	
	void Update ()
	{
		standingPinsCount.text = CountStanding().ToString();

		if (ballLeftSpaceBeforePins)
		{
			StoreInitialPinCount();
			HandleThrow();
		}
	}


	private void StoreInitialPinCount()
	{
		if (initialPinCountStored) return;

		initialPinCount = CountStanding();
		initialPinCountStored = true;
	}

	private void HandleThrow()
	{
		UpdateStandingCountIfChanged();

		if (PinsAreSettled())
		{
			DisplayFinalScore();
			pinSetterController.FinishThrow();
		}
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

	private bool PinsAreSettled()
	{
		return Time.time - lastCountChangeTime > SECONDS_TO_SETTLE;
	}

	//private void AddThrowToScore()
	//{
	//	int currentPinCount = CountStanding();
	//	int throwScore = initialPinCount - currentPinCount;
	//}

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

	public void ResetCounter()
	{
		ballLeftSpaceBeforePins = false;
		initialPinCountStored = false;
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
