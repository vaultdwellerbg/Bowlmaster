using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarsController : MonoBehaviour {

	public enum OperationStatus {SUCCESS, FAILIURE};

	private int totalStars = 60;
	
	void Start()
	{
		UpdateStarDisplay();
	}

	public void AddStars(int amount)
	{
		totalStars += amount;
		UpdateStarDisplay();
	}
	
	public OperationStatus SpendStars(int amount)
	{		
		if (totalStars >= amount)
		{
			totalStars -= amount;
			UpdateStarDisplay();
			return OperationStatus.SUCCESS;
		}
		return OperationStatus.FAILIURE;
	}	
	
	private void UpdateStarDisplay()
	{
		GetComponent<Text>().text = totalStars.ToString();
	}
}
