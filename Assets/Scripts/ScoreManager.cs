﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager {

	public enum Action { Tidy, Reset, EndTurn, EndGame }

	private int[] throws = new int[21];
	private int currentThrowNumber = 1;

	public int GetCurrentThrowNumber()
	{
		return currentThrowNumber;
	}

	public Action Throw(int pins)
	{
		if (pins < 0 || pins > 10)
		{
			throw new UnityException("Invalid pin count for throw.");
		}
		Debug.Log(pins);
		throws[currentThrowNumber - 1] = pins;
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
		return IsLastFrame() && (IsStrike() || IsDoubleStrike() || IsSpare());
	}

	private bool IsLastFrame()
	{
		return currentThrowNumber > 18 && currentThrowNumber <= 20;
	}

	private bool IsStrike()
	{
		return throws[currentThrowNumber - 1] == 10 && IsFirstBall();
	}

	private bool IsDoubleStrike()
	{
		return throws[currentThrowNumber - 1] == 10 && !IsFirstBall();
	}

	private bool IsSpare()
	{
		return throws[currentThrowNumber - 1] + throws[currentThrowNumber - 2] == 10
			&& throws[currentThrowNumber - 1] != 0;
	}

	private bool ShouldEndTurn()
	{
		bool isLastFrameThrow = currentThrowNumber > 18;
		return (IsStrike() || !IsFirstBall()) && !isLastFrameThrow;
	}

	private bool IsFirstBall()
	{
		return currentThrowNumber % 2 != 0;
	}

	private bool ShouldTidy()
	{
		bool isBonusThrow = currentThrowNumber > 20;
		return (!IsStrike() && IsFirstBall() && !isBonusThrow) || IsFirstBallAfterLastFrameStrike();
	}

	private bool IsFirstBallAfterLastFrameStrike()
	{
		return IsPrevThrowSpare() && !IsFirstBall();
	}

	private bool IsPrevThrowSpare()
	{
		return throws[currentThrowNumber - 2] == 10;
	}

	private void IncrementCurrentThrow()
	{
		int increment = IsStrikeBeforeLastFrame() ? 2 : 1;
		currentThrowNumber += increment;
	}

	private bool IsStrikeBeforeLastFrame()
	{
		return IsStrike() && currentThrowNumber < 18;
	}

}
