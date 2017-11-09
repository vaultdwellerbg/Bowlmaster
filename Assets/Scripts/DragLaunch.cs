using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLaunch : MonoBehaviour {

	private BallController ballController;
	private float dragStartTime;
	private Vector3 dragStartPos;

	void Start ()
	{
		ballController = GetComponent<BallController>();
	}

	public void DragStart()
	{
		dragStartTime = Time.time;
		dragStartPos = Input.mousePosition;
	}

	public void DragEnd()
	{
		Vector3 dragVector = Input.mousePosition - dragStartPos;
		float dragTime = Time.time - dragStartTime;
		float launchSpeed = GetLaunchSpeed(dragVector, dragTime);

		ballController.Launch(new Vector3(dragVector.x, 0, launchSpeed));
	}

	private float GetLaunchSpeed(Vector3 vector, float time)
	{
		float length = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
		return length / time;
	}
}
