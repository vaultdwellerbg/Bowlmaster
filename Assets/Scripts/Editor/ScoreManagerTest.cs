using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreManagerTest {

	private ScoreManager scoreManager;
	private ScoreManager.Action endTurn, tidy, reset;

	[SetUp]
	public void Setup()
	{
		scoreManager = new ScoreManager();
		endTurn = ScoreManager.Action.EndTurn;
		tidy = ScoreManager.Action.Tidy;
		reset = ScoreManager.Action.Reset;
	}

	[Test]
	public void OneStrikeRetursnEndTurn() {
		Assert.AreEqual(endTurn, scoreManager.Throw(10));
	}

	[Test]
	public void Throwing8ReturnsTidy()
	{
		Assert.AreEqual(tidy, scoreManager.Throw(8));
	}

	[Test]
	public void ThrowingSpareReturnsEndTurn()
	{
		scoreManager.Throw(2);
		Assert.AreEqual(endTurn, scoreManager.Throw(8));
	}
}
