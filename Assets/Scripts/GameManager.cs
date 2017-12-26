using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> pinHits = new List<int>();
	private PinSetterController pinSetterController;
	private BallController ballController;
	private PinCounter pinCounter;

	void Start ()
	{
		pinSetterController = GameObject.FindObjectOfType<PinSetterController>();
		ballController = GameObject.FindObjectOfType<BallController>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}

	public void Throw(int pinsHit)
	{
		pinHits.Add(pinsHit);
		Debug.Log(pinHits);
		ActionManager.Action action = ActionManager.GetNextAction(pinHits);
		pinSetterController.Perform(action);
		ResetGameState();
	}

	private void ResetGameState()
	{
		pinCounter.Reset();
		ballController.Reset();
	}
}
