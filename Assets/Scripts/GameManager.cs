using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> pinHits = new List<int>();
	private PinSetterController pinSetterController;
	private BallController ballController;
	private PinCounter pinCounter;
	private ScoreDisplay scoreDisplay;

	void Start ()
	{
		pinSetterController = GameObject.FindObjectOfType<PinSetterController>();
		ballController = GameObject.FindObjectOfType<BallController>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}

	public void Throw(int pinsHit)
	{
		try
		{
			pinHits.Add(pinsHit);
			pinSetterController.Perform(ActionManager.GetNextAction(pinHits));
			scoreDisplay.FillRollCard(pinHits);
		}
		catch (System.Exception)
		{
			Debug.LogWarning("Error with registering pins hit");
		}
		ResetGameState();
	}

	private void ResetGameState()
	{
		pinCounter.Reset();
		ballController.Reset();
	}
}
