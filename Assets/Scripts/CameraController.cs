using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public BallController ballController;

	private Vector3 offset;

	void Start () {
		offset = transform.position - ballController.transform.position;
	}
	
	void Update ()
	{
		if (BallBeforeFrontPin())
		{
			MoveCamera();
		}
	}

	private bool BallBeforeFrontPin()
	{
		return ballController.transform.position.z < 1829f;
	}

	private void MoveCamera()
	{
		transform.position = ballController.transform.position + offset;
	}
}
