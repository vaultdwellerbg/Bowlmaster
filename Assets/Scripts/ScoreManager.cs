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
		return GetAction();

		throw new UnityException("No specified action");
	}

	private Action GetAction()
	{
		if (IsStrike())
		{
			if (IsLastFrame())
			{
				currentThrow += 2;
				return Action.Reset;
			}
			else if (IsExtraThrow() && IsPrevThrowStrike())
			{
				currentThrow += 1;
				return Action.Tidy;
			}
			else if (IsExtraThrow())
			{
				return Action.EndGame;
			}
			else
			{
				currentThrow += 2;
				return Action.EndTurn;
			}
		}
		else if (IsFirstBall())
		{
			if (IsExtraThrow() && IsPrevThrowSpare())
			{
				return Action.EndGame;
			}
			else
			{
				currentThrow += 1;
				return Action.Tidy;
			}
		}
		else if (IsLastFrame() && !IsSpare())
		{
			return Action.EndGame;
		}
		else if (IsLastFrame() && IsSpare())
		{
			currentThrow += 1;
			return Action.Reset;
		}
		else if (IsExtraThrow())
		{
			return Action.EndGame;
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

	private bool IsPrevThrowSpare()
	{
		return throws[currentThrow - 2] + throws[currentThrow - 3] == 10 && throws[currentThrow - 2] != 0;
	}

	private bool IsExtraThrow()
	{
		return currentThrow > 20;
	}

	private bool IsLastFrame()
	{
		return currentThrow > 18 && !IsExtraThrow();
	}

	private bool IsSpare()
	{
		return throws[currentThrow - 1] + throws[currentThrow - 2] == 10;
	}

	private bool IsPrevThrowStrike()
	{
		return throws[currentThrow - 2] + throws[currentThrow - 3] == 10 && throws[currentThrow - 2] == 0;
	}

}
