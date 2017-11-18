using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour {

	private Text standingPinsCount;
	private bool ballEntered = false;
	private int lastStandingCount = -1;
	private float lastChangeTime;
	private BallController ballController;

	private const string PIN_COLLIDER_NAME = "Pin_Collider";
	private const float SECONDS_TO_SETTLE = 3f;

	private void Start()
	{
		standingPinsCount = GameObject.Find("StandingPinsCount").GetComponent<Text>();
		ballController = GameObject.FindObjectOfType<BallController>();
	}

	public int CountStanding()
	{
		int standingCount = 0;
		PinController[] pins = GameObject.FindObjectsOfType<PinController>();
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

		if (ballEntered)
		{
			CheckStanding();
		}
	}

	private void CheckStanding()
	{
		int currentStandingCount = CountStanding();
		if (currentStandingCount != lastStandingCount)
		{
			UpdateLastStandingData(currentStandingCount);
			return;
		}

		if (PinsAreSettled())
		{
			PinsHaveSettled();
		}
	}

	private void UpdateLastStandingData(int currentStandingCount)
	{
		lastChangeTime = Time.time;
		lastStandingCount = currentStandingCount;
	}

	private bool PinsAreSettled()
	{
		return Time.time - lastChangeTime > SECONDS_TO_SETTLE;
	}

	private void PinsHaveSettled()
	{
		standingPinsCount.color = Color.green;
		ResetGameState();
	}

	private void ResetGameState()
	{
		ballEntered = false;
		lastStandingCount = -1;
		ballController.Reset();

	}

	private void OnTriggerEnter(Collider collider)
	{
		var ball = collider.gameObject.GetComponent<BallController>();
		if (ball)
		{
			standingPinsCount.color = Color.red;
			ballEntered = true;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		var exitedGameObject = collider.gameObject;
		var pinController = exitedGameObject.GetComponent<PinController>();
		if (pinController)
		{
			Destroy(exitedGameObject);
		}
	}
}
