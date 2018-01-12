using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallModelChooser : MonoBehaviour {

	public Texture[] modelSprites;

	private int selectedModelIndex = 0;

	public void ChangeSelectedModel()
	{
		selectedModelIndex++;
		if (selectedModelIndex >= modelSprites.Length)
		{
			selectedModelIndex = 0;
		}
		GetComponent<RawImage>().texture = modelSprites[selectedModelIndex];
	}
}
