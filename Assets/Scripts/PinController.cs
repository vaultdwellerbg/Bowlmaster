using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour {

	public float standingThreshold = 80f;

	private const float PIN_MESH_ROTATION_OFFSET = 270f;

	void Awake()
	{
		this.GetComponent<Rigidbody>().solverVelocityIterations = 10;
	}

	public bool IsStanding()
	{
		Vector3 eularAngles = transform.rotation.eulerAngles;
		float xRotation = Mathf.Abs(eularAngles.x - PIN_MESH_ROTATION_OFFSET);
		float zRotation = Mathf.Abs(eularAngles.z);

		return xRotation < standingThreshold && zRotation < standingThreshold;
	}
}
