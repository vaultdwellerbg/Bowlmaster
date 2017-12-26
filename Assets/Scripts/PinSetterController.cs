using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetterController : MonoBehaviour {

	public GameObject pinLayoutPrefab;

	private PinCounter pinCounter;
	private Animator animator;

	private const float RESET_HEIGHT = 0f;
	private const float PINS_OFFSET = 1829f;

	private void Start()
	{
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		animator = GetComponent<Animator>();
	}

	public void Perform(ActionManager.Action action)
	{
		if (action == ActionManager.Action.Tidy)
		{
			animator.SetTrigger("tidyTrigger");
		}
		else
		{
			animator.SetTrigger("resetTrigger");
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
