using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour {

	public GameObject pinLayoutPrefab;

	private bool ballEntered = false;
	private BallController ballController;
	private PinCounter pinCounter;

	private const float SECONDS_TO_SETTLE = 3f;
	private const float RESET_HEIGHT = 40f;
	private const float PINS_OFFSET = 1829f;

	private void Start()
	{
		pinCounter = GetComponent<PinCounter>();
		ballController = GameObject.FindObjectOfType<BallController>();
	}

	private void Update()
	{
		if (ballEntered)
		{
			HandleThrow();
		}
	}

	private void HandleThrow()
	{
		pinCounter.UpdateCountIfChanged();

		if (PinsAreSettled())
		{
			FinishThrow();
		}
	}

	private bool PinsAreSettled()
	{
		return Time.time - pinCounter.lastCountChangeTime > SECONDS_TO_SETTLE;
	}

	private void FinishThrow()
	{
		pinCounter.DisplayFinalScore();
		ResetGameState();
	}

	private void ResetGameState()
	{
		ballEntered = false;
		pinCounter.ResetCount();
		ballController.Reset();
	}

	private void OnTriggerEnter(Collider collider)
	{
		var ball = collider.gameObject.GetComponent<BallController>();
		if (ball)
		{
			pinCounter.DisplayCountChanging();
			ballEntered = true;
		}
	}

	public void RaisePins()
	{
		List<PinController> standingPins = pinCounter.GetStanding();
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
