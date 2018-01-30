using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int>();
	private PinSetterController pinSetterController;
	private BallController ballController;
	private PinCounter pinCounter;
	private ScoreDisplay scoreDisplay;
	private LevelManager levelManager;

	void Start ()
	{
		pinSetterController = GameObject.FindObjectOfType<PinSetterController>();
		ballController = GameObject.FindObjectOfType<BallController>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
		levelManager = GameManager.FindObjectOfType<LevelManager>();
	}

	public void Throw(int pinsHit)
	{
		try
		{
			rolls.Add(pinsHit);
			var nextAction = ActionManager.GetNextAction(rolls);
			pinSetterController.Perform(nextAction);
			FillScoreCard();
			if (nextAction == ActionManager.Action.EndGame)
			{
				EndGame();
			}
		}
		catch (System.Exception)
		{
			Debug.LogWarning("Error with registering pins hit");
		}
		ResetGameState();
	}

	private void FillScoreCard()
	{
		scoreDisplay.FillRolls(rolls);
		scoreDisplay.FillFrames(ScoreManager.ScoreCumulative(rolls));
	}

	private void EndGame()
	{
		SaveFinalScore();
		levelManager.LoadNextLevel();
	}

	private void SaveFinalScore()
	{
		List<int> cumulativeScore = ScoreManager.ScoreCumulative(rolls);
		ScoreManager.finalScore = cumulativeScore[cumulativeScore.Count - 1];
	}

	private void ResetGameState()
	{
		pinCounter.Reset();
		ballController.Reset();
	}
}
