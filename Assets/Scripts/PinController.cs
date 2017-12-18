using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour {

	public float standingThreshold = 80f;
	public float distanceToRaise = 40f;

	private const float PIN_MESH_ROTATION_OFFSET = 270f;
	private Rigidbody rigidBody;

	void Awake()
	{
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.solverVelocityIterations = 10;
	}

	public bool IsStanding()
	{
		Vector3 eularAngles = transform.rotation.eulerAngles;
		float xRotation = Mathf.Abs(eularAngles.x - PIN_MESH_ROTATION_OFFSET);
		float zRotation = Mathf.Abs(eularAngles.z);
		return xRotation < standingThreshold && zRotation < standingThreshold;
	}

	public void Raise()
	{
		rigidBody.useGravity = false;
		transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
	}

	public void Lower()
	{
		rigidBody.useGravity = true;
	}

	public void Straighten()
	{
		transform.rotation = Quaternion.Euler(270, 0, 0);
	}

}
