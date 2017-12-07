using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreManagerTest {

	private ScoreManager scoreManager;
	private ScoreManager.Action endTurn;

	[SetUp]
	public void Init()
	{
		scoreManager = new ScoreManager();
		endTurn = ScoreManager.Action.EndTurn;
	}

	[Test]
	public void OneStrikeRetursnEndTurn() {
		Assert.AreEqual(endTurn, scoreManager.Throw(10));
	}
}
