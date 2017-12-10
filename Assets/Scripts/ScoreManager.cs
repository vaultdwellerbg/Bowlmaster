using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager {

	public enum Action { Tidy, Reset, EndTurn, EndGame }

	private int[] throws = new int[22];
	private int currentThrow = 1;

	public Action Throw(int pins)
	{
		if (pins < 0 || pins > 10)
		{
			throw new UnityException("Invalid pin count for throw.");
		}

		throws[currentThrow - 1] = pins;
		Action returnAction = GetAction();
		IncrementCurrentThrow();
		return returnAction;

		throw new UnityException("No specified action");
	}

	private Action GetAction()
	{
		if (IsLastFrame() && (IsStrike() || IsSpare()))
		{
			return Action.Reset;
		}
		else if ((IsStrike() || currentThrow % 2 == 0) && currentThrow <= 18)
		{
			return Action.EndTurn;
		}
		else if ((!IsStrike() && currentThrow % 2 != 0 && currentThrow <= 20) || (currentThrow == 21 && IsPrevThrowStrike()))
		{
			return Action.Tidy;
		}
		else
		{
			return Action.EndGame;
		}
	}

	private bool IsStrike()
	{
		return throws[currentThrow - 1] == 10;
	}

	private bool IsLastFrame()
	{
		return currentThrow > 18 && currentThrow <= 20;
	}

	private bool IsSpare()
	{
		return throws[currentThrow - 1] + throws[currentThrow - 2] == 10;
	}

	private bool IsPrevThrowStrike()
	{
		return throws[currentThrow - 2] + throws[currentThrow - 3] == 10 && throws[currentThrow - 2] == 0;
	}

	private void IncrementCurrentThrow()
	{
		if (IsStrike() && currentThrow < 20)
		{
			currentThrow += 2;
		}
		else
		{
			currentThrow += 1;
		}
	}

}
