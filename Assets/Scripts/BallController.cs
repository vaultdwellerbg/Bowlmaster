using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float launchSpeed = 200f;

	private AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		Throw();
	}

	private void Throw()
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0, -10f, launchSpeed);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!audioSource.isPlaying)
		{
			audioSource.Play();
		}
	}
}
