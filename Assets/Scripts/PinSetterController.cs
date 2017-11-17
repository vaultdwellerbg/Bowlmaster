using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour {

	private Text standingPinsCount;
	private bool ballEntered = false;
	private const string PIN_COLLIDER_NAME = "Pin_Collider";

	private void Start()
	{
		standingPinsCount = GameObject.Find("StandingPinsCount").GetComponent<Text>();
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
		var gameObject = collider.gameObject;
		var objectName = gameObject.name;
		if (objectName == PIN_COLLIDER_NAME)
		{
			var pinMainObject = gameObject.transform.parent.gameObject;
			Destroy(pinMainObject);
		}
	}
}
