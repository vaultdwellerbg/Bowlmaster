using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private AudioSource audioSource;
	private Rigidbody rigidBody;

	void Start ()
	{
		InitMembers();
		rigidBody.useGravity = false;
	}

	private void InitMembers()
	{
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody>();
	}

	public void Launch(Vector3 velocity)
	{
		rigidBody.useGravity = true;
		GetComponent<Rigidbody>().velocity = velocity;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!audioSource.isPlaying)
		{
			audioSource.Play();
		}
	}
}
