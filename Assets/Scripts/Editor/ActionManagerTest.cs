using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ActionManagerTest {

	private ActionManager scoreManager;
	private ActionManager.Action endTurn, tidy, reset, endGame;

	[SetUp]
	public void Setup()
	{
		scoreManager = new ActionManager();
		endTurn = ActionManager.Action.EndTurn;
		tidy = ActionManager.Action.Tidy;
		reset = ActionManager.Action.Reset;
		endGame = ActionManager.Action.EndGame;
	}

	[Test]
	public void T01_OneStrikeRetursnEndTurn() {
		Assert.AreEqual(endTurn, scoreManager.Throw(10));
	}

	[Test]
	public void T02_Throwing8ReturnsTidy()
	{
		Assert.AreEqual(tidy, scoreManager.Throw(8));
	}

	[Test]
	public void T03_ThrowingSpareReturnsEndTurn()
	{
		scoreManager.Throw(2);

		Assert.AreEqual(endTurn, scoreManager.Throw(8));
	}

	[Test]
	public void T04_ThrowingNoSpareOrStrikeOnLastFrameReturnsEndGame()
	{
		PlayNineFrames();
		scoreManager.Throw(5);

		Assert.AreEqual(endGame, scoreManager.Throw(1));
	}

	private void PlayNineFrames()
	{
		int[] rolls = { 10,  9, 1,  5, 5,  7, 2,  10,  10,  10,  9, 0,  8, 2};
		foreach (int roll in rolls)
		{
			scoreManager.Throw(roll);
		}
	}

	[Test]
	public void T05_ThrowingStrikeOnLastFrameReturnsReset()
	{
		PlayNineFrames();

		Assert.AreEqual(reset, scoreManager.Throw(10));
	}

	[Test]
	public void T06_ThrowingSpareOnLastFrameReturnsReset()
	{
		PlayNineFrames();
		scoreManager.Throw(3);

		Assert.AreEqual(reset, scoreManager.Throw(7));
	}

	[Test]
	public void T07_ThrowingOneBallAfterLastFrameSpareEndsGame()
	{
		PlayNineFrames();
		scoreManager.Throw(3);
		scoreManager.Throw(7);

		Assert.AreEqual(endGame, scoreManager.Throw(6));
	}

	[Test]
	public void T08_ThrowingStrikeBallAfterLastFrameSpareEndsGame()
	{
		PlayNineFrames();
		scoreManager.Throw(3);
		scoreManager.Throw(7);

		Assert.AreEqual(endGame, scoreManager.Throw(10));
	}

	[Test]
	public void T09_ThrowingTwoBallsAfterLastFrameStrikeEndsGame()
	{
		PlayNineFrames();
		scoreManager.Throw(10);

		scoreManager.Throw(6);
		Assert.AreEqual(endGame, scoreManager.Throw(2));
	}

	[Test]
	public void T10_ThrowingTwoStrikesAfterLastFrameStrikeEndsGame()
	{
		PlayNineFrames();

		Assert.AreEqual(reset, scoreManager.Throw(10));
		Assert.AreEqual(reset, scoreManager.Throw(10));
		Assert.AreEqual(endGame, scoreManager.Throw(10));
	}

	[Test]
	public void T11_FirstBallAfterLastFrameStrikeShouldReturnTidy()
	{
		PlayNineFrames();
		scoreManager.Throw(10);

		Assert.AreEqual(tidy, scoreManager.Throw(4));
	}

	[Test]
	public void T12_GutterBallAfterLastFrameStrikeShouldReturnTidy()
	{
		PlayNineFrames();
		scoreManager.Throw(10);

		Assert.AreEqual(tidy, scoreManager.Throw(0));
	}

	[Test]
	public void T13_ThrowingGutterBallThenSpareReturnsEndTurnAndIncrementsThrowOnce()
	{
		scoreManager.Throw(0);

		Assert.AreEqual(endTurn, scoreManager.Throw(10));
		Assert.AreEqual(3, scoreManager.GetCurrentThrowNumber());
	}

}
