using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

	private void Start()
	{
		gameObject.SetActive(PlayerPrefsManager.GetShowTutorial());
	}

	public void Hide()
	{
		if (PlayerPrefsManager.GetShowTutorial())
		{
			PlayerPrefsManager.SetShowTutorial(false);
		}
		Toggle();
	}

	public void Toggle()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}
}
