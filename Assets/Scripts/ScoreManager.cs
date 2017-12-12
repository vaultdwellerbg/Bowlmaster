using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager {

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
		Action returnAction = GetAction();
		IncrementCurrentThrow();
		return returnAction;

		throw new UnityException("No specified action");
	}

	private Action GetAction()
	{
		if (ShouldReset())
		{
			return Action.Reset;
		}
		else if (ShouldEndTurn())
		{
			return Action.EndTurn;
		}
		else if (ShouldTidy())
		{
			return Action.Tidy;
		}
		else
		{
			return Action.EndGame;
		}
	}

	private bool ShouldReset()
	{
		return IsLastFrame() && (IsStrike() || IsSpare());
	}

	private bool IsLastFrame()
	{
		return currentThrow > 18 && currentThrow <= 20;
	}

	private bool IsStrike()
	{
		return throws[currentThrow - 1] == 10;
	}

	private bool IsSpare()
	{
		return throws[currentThrow - 1] + throws[currentThrow - 2] == 10;
	}

	private bool ShouldEndTurn()
	{
		bool isLastFrameThrow = currentThrow > 18;
		return (IsStrike() || !IsFirstBall()) && !isLastFrameThrow;
	}

	private bool IsFirstBall()
	{
		return currentThrow % 2 != 0;
	}

	private bool ShouldTidy()
	{
		bool isBonusThrow = currentThrow > 20;
		return !IsStrike() && IsFirstBall() && !isBonusThrow;
	}

	private void IncrementCurrentThrow()
	{
		int increment = IsStrikeBeforeLastFrame() ? 2 : 1;
		currentThrow += increment;
	}

	private bool IsStrikeBeforeLastFrame()
	{
		return IsStrike() && currentThrow < 18;
	}

}
