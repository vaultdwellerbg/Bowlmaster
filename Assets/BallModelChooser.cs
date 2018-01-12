using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallModelChooser : MonoBehaviour {

	public Texture[] modelSprites;
	public int selectedModelIndex = 0;

	private void Start()
	{
		SetSelectedModel();
	}

	private void SetSelectedModel()
	{
		GetComponent<RawImage>().texture = modelSprites[selectedModelIndex];
	}

	public void ChangeSelectedModel()
	{
		selectedModelIndex++;
		if (selectedModelIndex >= modelSprites.Length)
		{
			selectedModelIndex = 0;
		}
		SetSelectedModel();
	}
}
