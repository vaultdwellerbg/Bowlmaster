using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour {

	public GameObject pinLayoutPrefab;

	private Text standingPinsCount;
	private bool ballEntered = false;
	private int lastStandingCount = -1;
	private float lastChangeTime;
	private BallController ballController;

	private const string PIN_COLLIDER_NAME = "Pin_Collider";
	private const float SECONDS_TO_SETTLE = 3f;
	private const float RESET_HEIGHT = 40f;
	private const float PINS_OFFSET = 1829f;

	private void Start()
	{
		standingPinsCount = GameObject.Find("StandingPinsCount").GetComponent<Text>();
		ballController = GameObject.FindObjectOfType<BallController>();
	}

	private void Update()
	{
		standingPinsCount.text = CountStanding().ToString();

		if (ballEntered)
		{
			HandleThrow();
		}
	}

	public int CountStanding()
	{
		return GetStanding().Count;
	}

	private List<PinController> GetStanding()
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

	private void HandleThrow()
	{
		int currentStandingCount = CountStanding();
		if (currentStandingCount != lastStandingCount)
		{
			UpdateLastStandingData(currentStandingCount);
			return;
		}

		if (PinsAreSettled())
		{
			FinishThrow();
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

	private void FinishThrow()
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

	public void RaisePins()
	{
		List<PinController> standingPins = GetStanding();
		foreach (var pin in standingPins)
		{
			pin.Raise();
		}
	}

	public void LowerPins()
	{
		PinController[] pins = GameObject.FindObjectsOfType<PinController>();
		for (int i = 0; i < pins.Length; i++)
		{
			pins[i].Lower();
		}
	}

	public void RenewPins()
	{
		GameObject oldPinsLayout = GameObject.Find("PinLayout");
		Destroy(oldPinsLayout);
		Instantiate(pinLayoutPrefab, new Vector3(0, RESET_HEIGHT, PINS_OFFSET), Quaternion.identity);
	}
}
