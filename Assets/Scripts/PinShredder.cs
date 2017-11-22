using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinShredder : MonoBehaviour {

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
