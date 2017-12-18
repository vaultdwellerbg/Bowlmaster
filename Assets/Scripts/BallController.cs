using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public bool IsLaunched = false;

	private AudioSource audioSource;
	private Rigidbody rigidBody;
	private Vector3 startPosition;

	void Start ()
	{
		InitMembers();
		rigidBody.useGravity = false;
		startPosition = transform.position;
	}

	private void InitMembers()
	{
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody>();
	}

	public void Launch(Vector3 velocity)
	{
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
		IsLaunched = true;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!audioSource.isPlaying)
		{
			audioSource.Play();
		}
	}

	public void Reset()
	{
		rigidBody.velocity = rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
		transform.position = startPosition;	
		IsLaunched = false;
		audioSource.Stop();
		transform.rotation = Quaternion.identity;
	}
}
