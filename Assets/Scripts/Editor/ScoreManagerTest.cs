﻿using System;
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

	[Test]
	public void T08_Hit_1_9()
	{
		int[] rolls = { 1, 9 };
		int[] frames = { };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T09_Hit_1_2_3_4_5_5()
	{
		int[] rolls = { 1, 2,  3, 4,  5, 5 };
		int[] frames = { 3, 7 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T10_SpareBonus()
	{
		int[] rolls = { 1, 2,  3, 5,  5, 5,  3, 3 };
		int[] frames = { 3, 8, 13, 6 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T11_SpareBonus2()
	{
		int[] rolls = { 1, 2,  3, 5,  5, 5,  3, 3,  7, 1,  9, 1,  6 };
		int[] frames = { 3, 8, 13, 6, 8, 16 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T12_StrikeBonus()
	{
		int[] rolls = { 10,  3, 4 };
		int[] frames = { 17, 7 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T13_StrikeBonus2()
	{
		int[] rolls = { 1, 2,  3, 4,  5, 4,  3, 2,  10,  1, 3,  3, 4 };
		int[] frames = { 3, 7, 9, 5, 14, 4, 7 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T14_MultiStrikes()
	{
		int[] rolls = { 10,  10,  2, 3 };
		int[] frames = { 22, 15, 5 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T15_MultiStrikes2()
	{
		int[] rolls = { 10,  10,  2, 3,  10,  5, 3 };
		int[] frames = { 22, 15, 5, 18, 8 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T16_TestGutterGame()
	{
		int[] rolls = { 0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0 };
		int[] totalS = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Test]
	public void T17_TestAllOnes()
	{
		int[] rolls = { 1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1 };
		int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Test]
	public void T18_TestAllStrikes()
	{
		int[] rolls = { 10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10,  10 };
		int[] totalS = { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Test]
	public void T19_TestImmediateStrikeBonus()
	{
		int[] rolls = { 5, 5,  3 };
		int[] frames = { 13 };
		Assert.AreEqual(frames.ToList(), ScoreManager.ScoreFrames(rolls.ToList()));
	}

	[Test]
	public void T20_SpareInLastFrame()
	{
		int[] rolls = { 1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 9,  7 };
		int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 35 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Test]
	public void T21_StrikeInLastFrame()
	{
		int[] rolls = { 1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  10,  2, 3 };
		int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 33 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	// http://slocums.homestead.com/gamescore.html
	[Test]
	[Category("Verification")]
	public void T22_GoldenCopyA()
	{
		int[] rolls = { 10,  7, 3,  9, 0,  10,  0, 8,  8, 2,  0, 6,  10,  10,  10,  8, 1 };
		int[] totalS = { 20, 39, 48, 66, 74, 84, 90, 120, 148, 167 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Category("Verification")]
	[Test]
	public void T23_GoldenCopyB1of3()
	{
		int[] rolls = { 10,  9, 1,  9, 1,  9, 1,  9, 1,  7, 0,  9, 0,  10,  8, 2,  8, 2,  10 };
		int[] totalS = { 20, 39, 58, 77, 94, 101, 110, 130, 148, 168 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Category("Verification")]
	[Test]
	public void T24_GoldenCopyB2of3()
	{
		int[] rolls = { 8, 2,  8, 1,  9, 1,  7, 1,  8, 2,  9, 1,  9, 1,  10,  10,  7, 1 };
		int[] totalS = { 18, 27, 44, 52, 71, 90, 110, 137, 155, 163 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Category("Verification")]
	[Test]
	public void T25_GoldenCopyB3of3()
	{
		int[] rolls = { 10,  10,  9, 0,  10,  7, 3,  10,  8, 1,  6, 3,  6, 2,  9, 1,  10 };
		int[] totalS = { 29, 48, 57, 77, 97, 116, 125, 134, 142, 162 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Category("Verification")]
	[Test]
	public void T26_GoldenCopyC1of3()
	{
		int[] rolls = { 7, 2,  10,  10,  10,  10,  7, 3,  10,  10,  9, 1,  10,  10,  9 };
		int[] totalS = { 9, 39, 69, 96, 116, 136, 165, 185, 205, 234 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}

	[Category("Verification")]
	[Test]
	public void T27_GoldenCopyC2of3()
	{
		int[] rolls = { 10,  10,  10,  10,  9, 0,  10,  10,  10,  10,  10,  9, 1 };
		int[] totalS = { 30, 60, 89, 108, 117, 147, 177, 207, 236, 256 };
		Assert.AreEqual(totalS.ToList(), ScoreManager.ScoreCumulative(rolls.ToList()));
	}
}
