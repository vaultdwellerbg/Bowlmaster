using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class ActionManagerTest
{
	private List<int> throws;
	private ActionManager.Action endTurn, tidy, reset, endGame;

	[SetUp]
	public void Setup()
	{
		throws = new List<int>();
		endTurn = ActionManager.Action.EndTurn;
		tidy = ActionManager.Action.Tidy;
		reset = ActionManager.Action.Reset;
		endGame = ActionManager.Action.EndGame;
	}

	[Test]
	public void T01_OneStrikeRetursnEndTurn() {
		throws.Add(10);

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(endTurn, nextAction);
	}

	[Test]
	public void T02_Throwing8ReturnsTidy()
	{
		throws.Add(8);

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(tidy, nextAction);
	}

	[Test]
	public void T03_ThrowingSpareReturnsEndTurn()
	{
		throws.AddRange(new List<int>() { 2, 8 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(endTurn, nextAction);
	}

	[Test]
	public void T04_ThrowingNoSpareOrStrikeOnLastFrameReturnsEndGame()
	{
		AddNineFrames(throws);
		throws.AddRange(new List<int>() { 5, 1 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(endGame, nextAction);
	}

	private void AddNineFrames(List<int> throws)
	{
		throws.AddRange(new List<int> () { 10,  9, 1,  5, 5,  7, 2,  10,  10,  10,  9, 0,  8, 2});
	}

	[Test]
	public void T05_ThrowingStrikeOnLastFrameReturnsReset()
	{
		AddNineFrames(throws);
		throws.Add(10);

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(reset, nextAction);
	}

	[Test]
	public void T06_ThrowingSpareOnLastFrameReturnsReset()
	{
		AddNineFrames(throws);
		throws.AddRange(new List<int>() { 3, 7 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(reset, nextAction);
	}

	[Test]
	public void T07_ThrowingOneBallAfterLastFrameSpareEndsGame()
	{
		AddNineFrames(throws);
		throws.AddRange(new List<int>() { 3, 7, 6 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(endGame, nextAction);
	}

	[Test]
	public void T08_ThrowingStrikeBallAfterLastFrameSpareEndsGame()
	{
		AddNineFrames(throws);
		throws.AddRange(new List<int>() { 3, 7, 10 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(endGame, nextAction);
	}

	[Test]
	public void T09_ThrowingTwoBallsAfterLastFrameStrikeEndsGame()
	{
		AddNineFrames(throws);
		throws.AddRange(new List<int>() { 10, 6, 2 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(endGame, nextAction);
	}

	[Test]
	public void T10_ThrowingTwoStrikesAfterLastFrameStrikeEndsGame()
	{
		AddNineFrames(throws);
		throws.Add(10);

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(reset, nextAction);
		throws.Add(10);
		Assert.AreEqual(reset, ActionManager.GetNextAction(throws));
		throws.Add(10);
		Assert.AreEqual(endGame, ActionManager.GetNextAction(throws));
	}

	[Test]
	public void T11_FirstBallAfterLastFrameStrikeShouldReturnTidy()
	{
		AddNineFrames(throws);
		throws.AddRange(new List<int>() { 10, 4 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(tidy, nextAction);
	}

	[Test]
	public void T12_GutterBallAfterLastFrameStrikeShouldReturnTidy()
	{
		AddNineFrames(throws);
		throws.AddRange(new List<int>() { 10, 0 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(tidy, nextAction);
	}

	[Test]
	public void T13_ThrowingGutterBallThenSpareReturnsEndTurnAndIncrementsThrowOnce()
	{
		throws.AddRange(new List<int>() { 0, 10 });

		ActionManager.Action nextAction = ActionManager.GetNextAction(throws);

		Assert.AreEqual(endTurn, nextAction);
		//Assert.AreEqual(3, scoreManager.GetCurrentThrowNumber());
	}

}
