using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BallController))]
public class BallDragLaunch : MonoBehaviour {

	private BallController ballController;
	private float dragStartTime;
	private Vector3 dragStartPos;
	private float halfLaneWidth;

	void Start ()
	{
		ballController = GetComponent<BallController>();
		halfLaneWidth = GameObject.Find("Floor").GetComponent<Transform>().lossyScale.x / 2;
	}

	public void DragStart()
	{
		if (ballController.IsLaunched) return;

		dragStartTime = Time.time;
		dragStartPos = Input.mousePosition;
	}

	public void DragEnd()
	{
		if (ballController.IsLaunched) return;

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

	public void MoveLaunchPoint(float value)
	{
		if (ballController.IsLaunched) return;

		float newXPos = Mathf.Clamp(ballController.transform.position.x + value, -halfLaneWidth, halfLaneWidth);
		Vector3 currentPos = ballController.transform.position;
		ballController.transform.position = new Vector3(newXPos, currentPos.y, currentPos.z);
	}
}
