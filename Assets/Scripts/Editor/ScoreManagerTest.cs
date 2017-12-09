using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreManagerTest {

	private ScoreManager scoreManager;
	private ScoreManager.Action endTurn, tidy, reset, endGame;

	[SetUp]
	public void Setup()
	{
		scoreManager = new ScoreManager();
		endTurn = ScoreManager.Action.EndTurn;
		tidy = ScoreManager.Action.Tidy;
		reset = ScoreManager.Action.Reset;
		endGame = ScoreManager.Action.EndGame;
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
		scoreManager.Throw(10);

		scoreManager.Throw(9);
		scoreManager.Throw(1);

		scoreManager.Throw(5);
		scoreManager.Throw(5);

		scoreManager.Throw(7);
		scoreManager.Throw(2);

		scoreManager.Throw(10);

		scoreManager.Throw(10);

		scoreManager.Throw(10);

		scoreManager.Throw(9);
		scoreManager.Throw(0);

		scoreManager.Throw(8);
		scoreManager.Throw(2);
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
		scoreManager.Throw(10);

		scoreManager.Throw(10);
		Assert.AreEqual(endGame, scoreManager.Throw(10));
	}

}
