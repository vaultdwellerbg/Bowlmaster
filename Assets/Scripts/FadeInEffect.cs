using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInEffect : MonoBehaviour {

	public int fadeInTimeout = 5;

	private float alphaFadeValue = 1;
	
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTimeout)
		{
			alphaFadeValue -= Mathf.Clamp01(Time.deltaTime / fadeInTimeout);
			GetComponent<CanvasGroup>().alpha = alphaFadeValue;			
		}
		else
		{
			gameObject.SetActive(false);
		}

	}
}
