using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreManagerTest
{
	[Test]
	public void T01_Hit_2_3()
	{
		int[] rolls = { 2, 3 };
		int[] frames = { 5 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T02_Hit_2_3_4()
	{
		int[] rolls = { 2, 3,  4 };
		int[] frames = { 5 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T03_Hit_2_3_4_5()
	{
		int[] rolls = { 2, 3,  4, 5 };
		int[] frames = { 5, 9 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T04_Hit_2_3_4_5_6()
	{
		int[] rolls = { 2, 3,  4, 5,  6 };
		int[] frames = { 5, 9 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T05_Hit_2_3_4_5_6_1()
	{
		int[] rolls = { 2, 3,  4, 5,  6, 1 };
		int[] frames = { 5, 9, 7 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T06_Hit_2_3_4_5_6_1_2()
	{
		int[] rolls = { 2, 3,  4, 5,  6, 1,  2 };
		int[] frames = { 5, 9, 7 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T07_HitStrikeAnd1()
	{
		int[] rolls = { 10, 1 };
		int[] frames = { };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}
}
