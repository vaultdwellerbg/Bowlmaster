using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBeforePins : MonoBehaviour {

	private PinSetterController pinSetterController;
	private PinCounter pinCounter;

	private void Start()
	{
		pinSetterController = GameObject.FindObjectOfType<PinSetterController>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}

	private void OnTriggerExit(Collider collider)
	{
		var ball = collider.gameObject.GetComponent<BallController>();
		if (ball)
		{
			pinCounter.DisplayCountChanging();
			pinSetterController.ballLeftSpaceBeforePins = true;
		}
	}
}
