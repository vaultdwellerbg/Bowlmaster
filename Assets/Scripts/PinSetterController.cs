using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour {

	public GameObject pinLayoutPrefab;
	public bool ballLeftSpaceBeforePins = false;

	private bool initialPinCountStored = false;
	private BallController ballController;
	private PinCounter pinCounter;
	private ScoreManager scoreManager;
	private int initialPinCount;
	private Animator animator;

	private const float SECONDS_TO_SETTLE = 5f;
	private const float RESET_HEIGHT = 0f;
	private const float PINS_OFFSET = 1829f;

	private void Start()
	{
		pinCounter = GetComponent<PinCounter>();
		ballController = GameObject.FindObjectOfType<BallController>();
		scoreManager = new ScoreManager();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (ballLeftSpaceBeforePins)
		{
			StoreInitialPinCount();
			HandleThrow();
		}
	}

	private void StoreInitialPinCount()
	{
		if (initialPinCountStored) return;

		initialPinCount = pinCounter.CountStanding();
		initialPinCountStored = true;
	}

	private void HandleThrow()
	{
		pinCounter.UpdateStandingCountIfChanged();

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
		ScoreManager.Action action = AddThrowToScoreAndGetAction();
		PerformAction(action);
		pinCounter.DisplayFinalScore();
		ResetGameState();
	}

	private ScoreManager.Action AddThrowToScoreAndGetAction()
	{
		int currentPinCount = pinCounter.CountStanding();
		int throwScore = initialPinCount - currentPinCount;
		return scoreManager.Throw(throwScore);
	}

	private void PerformAction(ScoreManager.Action action)
	{
		if (action == ScoreManager.Action.Tidy)
		{
			animator.SetTrigger("tidyTrigger");
		}
		else
		{
			animator.SetTrigger("resetTrigger");
		}
	}

	private void ResetGameState()
	{
		ballLeftSpaceBeforePins = false;
		initialPinCountStored = false;
		pinCounter.ResetCount();
		ballController.Reset();
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
