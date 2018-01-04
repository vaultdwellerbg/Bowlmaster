using NUnit.Framework;
using System.Linq;

public class ScoreDisplayTest
{

	[Test]
	public void T01_OneRoll() {
		int[] rolls = { 6 };
		string formattedRolls = "6";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T02_SeveralRolls()
	{
		int[] rolls = { 6, 2,  4, 1,  5, 3,  1, 1 };
		string formattedRolls = "62415311";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T03_RollsWithGutterBall()
	{
		int[] rolls = { 6, 2,  0, 5 };
		string formattedRolls = "62-5";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04_RollsWithSpare()
	{
		int[] rolls = { 6, 2,  1, 9,  2, 1,  5, 5 };
		string formattedRolls = "621/215/";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05_RollsWithStrike()
	{
		int[] rolls = { 2, 7,  10,  10,  5, 4 };
		string formattedRolls = "27X X 54";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T06_RollsWithStrikesSparesAndGutterBalls()
	{
		int[] rolls = { 0, 10,  4, 3,  2, 8,  1, 1,  10 };
		string formattedRolls = "-/432/11X ";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07_RollsWithSpareInLastFrame()
	{
		int[] rolls = { 1, 2,  4, 5,  10,  2, 8,  10,  10,  1, 1,  4, 5,  1, 9,  4, 6, 1 };
		string formattedRolls = "1245X 2/X X 11451/4/1";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T08_RollsWithStrikeInLastFrame()
	{
		int[] rolls = { 1, 2,  4, 5,  10,  2, 8,  10,  10,  1, 1,  4, 5,  1, 9,  10, 5, 5 };
		string formattedRolls = "1245X 2/X X 11451/X5/";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T09_RollsWithStrikesInLastFrame()
	{
		int[] rolls = { 1, 2,  4, 5,  10,  2, 8,  10,  10,  1, 1,  4, 5,  1, 9,  10, 10, 10 };
		string formattedRolls = "1245X 2/X X 11451/XXX";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T10_RealGameScoreboard()
	{
		int[] rolls = { 8, 2,  5, 4,  9, 0,  10,  10,  5, 5,  5, 3,  6, 3,  9, 1,  9, 1, 10 };
		string formattedRolls = "8/549-X X 5/53639/9/X";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T11_RealGameScoreboard2()
	{
		int[] rolls = { 9, 1,  7, 3,  7, 3,  10,  9, 1,  10,  9, 1,  8, 2,  10,  10, 9, 1 };
		string formattedRolls = "9/7/7/X 9/X 9/8/X X9/";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T12_RealGameScoreboard3()
	{
		int[] rolls = { 10,  5, 1,  9, 1,  7, 3,  10,  10,  9, 1,  10,  10,  10, 10, 9 };
		string formattedRolls = "X 519/7/X X 9/X X XX9";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T13_RealGameScoreboard4()
	{
		int[] rolls = { 9, 0,  5, 3,  10,  7, 3,  0, 0,  0, 0,  4, 4,  6, 0,  5, 3,  8, 0 };
		string formattedRolls = "9-53X 7/----446-538-";
		Assert.AreEqual(formattedRolls, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T14_GoldenCopyB1of3()
	{
		int[] rolls = { 10, 9, 1, 9, 1, 9, 1, 9, 1, 7, 0, 9, 0, 10, 8, 2, 8, 2, 10 };
		string rollsString = "X 9/9/9/9/7-9-X 8/8/X";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T15_GoldenCopyB2of3()
	{
		int[] rolls = { 8, 2, 8, 1, 9, 1, 7, 1, 8, 2, 9, 1, 9, 1, 10, 10, 7, 1 };
		string rollsString = "8/819/718/9/9/X X 71";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T16_GoldenCopyB3of3()
	{
		int[] rolls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
		string rollsString = "X X 9-X 7/X 8163629/X";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T17_GoldenCopyC1of3()
	{
		int[] rolls = { 7, 2, 10, 10, 10, 10, 7, 3, 10, 10, 9, 1, 10, 10, 9 };
		string rollsString = "72X X X X 7/X X 9/XX9";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T18_GoldenCopyC2of3()
	{
		int[] rolls = { 10, 10, 10, 10, 9, 0, 10, 10, 10, 10, 10, 9, 1 };
		string rollsString = "X X X X 9-X X X X X9/";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}
