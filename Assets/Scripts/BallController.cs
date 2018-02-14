using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public bool IsLaunched = false;
	public Material[] modelMaterials;

	private AudioSource audioSource;
	private Rigidbody rigidBody;
	private Vector3 startPosition;

	void Start ()
	{
		InitMembers();
		ConfigureMaterial();
		rigidBody.useGravity = false;
		startPosition = transform.position;
	}

	private void InitMembers()
	{
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody>();
	}

	private void ConfigureMaterial()
	{
		int index = PlayerPrefsManager.GetBallModelIndex();
		if (index < modelMaterials.Length)
		{
			GetComponent<MeshRenderer>().material = modelMaterials[index];
		}
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

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.name == "Floor")
		{
			audioSource.Stop();
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
