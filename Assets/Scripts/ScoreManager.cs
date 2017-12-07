using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public enum Action { Tidy, Reset, EndTurn, EndGame }

	private int[] throws = new int[21];
	private int currentThrow = 1;

	public Action Throw(int pins)
	{
		if (pins < 0 || pins > 10)
		{
			throw new UnityException("Invalid pin count for throw.");
		}

		throws[currentThrow - 1] = pins;
		return GetAction();

		throw new UnityException("No specified action");
	}

	private Action GetAction()
	{
		if (IsStrike())
		{
			currentThrow += 2;
			return Action.EndTurn;
		}
		else if (IsFirstBall())
		{
			currentThrow += 1;
			return Action.Tidy;
		}
		else
		{
			currentThrow += 1;
			return Action.EndTurn;
		}
	}

	private bool IsStrike()
	{
		return throws[currentThrow - 1] == 10;
	}

	private bool IsFirstBall()
	{
		return currentThrow % 2 != 0;
	}
}
