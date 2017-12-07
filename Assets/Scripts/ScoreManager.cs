using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public enum Action { Tidy, Reset, EndTurn, EndGame }

	public Action Throw(int pins)
	{
		if (pins < 0 || pins > 10)
		{
			throw new UnityException("Invalid pin count for throw.");
		}

		Action action = Action.Tidy;
		if (pins == 10)
		{
			action = Action.EndTurn;
		}
		return action;
	}
}
