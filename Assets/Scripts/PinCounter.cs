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

	private void OnTriggerExit(Collider collider)
	{
		var ball = collider.gameObject.GetComponent<BallController>();
		if (ball)
		{
			ShowStandingCountIsChanging();
			ballLeftSpaceBeforePins = true;
		}
	}

	public void ShowStandingCountIsChanging()
	{
		standingPinsCount.color = Color.red;
	}

	void Update()
	{
		UpdateStandingPinsDisplay();

		if (ballLeftSpaceBeforePins)
		{
			StoreInitialPinCount();
			HandleThrow();
		}
	}

	private void UpdateStandingPinsDisplay()
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
			ShowStandingCountIsSet();
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

	public void ShowStandingCountIsSet()
	{
		standingPinsCount.color = Color.green;
	}

	//private void AddThrowToScore()
	//{
	//	int currentPinCount = CountStanding();
	//	int throwScore = initialPinCount - currentPinCount;
	//}

	public void Reset()
	{
		ballLeftSpaceBeforePins = false;
		initialPinCountStored = false;
		lastStandingCount = -1;
	}
}
