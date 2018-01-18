using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionManager {

	public enum Action { Tidy, Reset, EndTurn, EndGame, Undefined };

	public static Action GetNextAction(List<int> rolls)
	{
		Action nextAction = Action.Undefined;

		for (int i = 0; i < rolls.Count; i++)
		{
			int currentRoll = rolls[i];
			if (i == 20)
			{
				nextAction = Action.EndGame;
			}
			else if (StrikeInLastFrame(i, currentRoll))
			{
				nextAction = Action.Reset;
			}
			else if (i == 19)
			{
				if (rolls[18] == 10 && rolls[19] == 0)
				{
					nextAction = Action.Tidy;
				}
				else if (rolls[18] + rolls[19] == 10)
				{
					nextAction = Action.Reset;
				}
				else if (ShouldThrow21thBall(rolls[18], rolls[19]))
				{
					nextAction = Action.Tidy;
				}
				else
				{
					nextAction = Action.EndGame;
				}
			}
			else if (IsFirstBallOfFrame(i))
			{
				if (currentRoll == 10)
				{
					AddEmptyRoll(rolls, i);
					nextAction = Action.EndTurn;
				}
				else
				{
					nextAction = Action.Tidy;
				}
			}
			else
			{
				nextAction = Action.EndTurn;
			}
		}

		RemoveAllEmptyRolls(rolls);
		return nextAction;
	}

	private static bool StrikeInLastFrame(int i, int currentRoll)
	{
		return i >= 18 && currentRoll == 10;
	}

	private static bool ShouldThrow21thBall(int firstRoll, int secondRoll)
	{
		return firstRoll + secondRoll >= 10;
	}

	private static bool IsFirstBallOfFrame(int i)
	{
		return i % 2 == 0;
	}

	private static void AddEmptyRoll(List<int> rolls, int i)
	{
		rolls.Insert(i, -1);
	}

	private static void RemoveAllEmptyRolls(List<int> rolls)
	{
		rolls.RemoveAll(num => num == -1);
	}
}
