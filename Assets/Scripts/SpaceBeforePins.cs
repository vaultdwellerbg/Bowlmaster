using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBeforePins : MonoBehaviour {

	private PinCounter pinCounter;

	private void Start()
	{
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}

	private void OnTriggerExit(Collider collider)
	{
		var ball = collider.gameObject.GetComponent<BallController>();
		if (ball)
		{
			pinCounter.DisplayCountChanging();
			pinCounter.ballLeftSpaceBeforePins = true;
		}
	}
}
