using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) 
	{
		SceneManager.LoadScene(name);
	}
	
	public void LoadLevel(int index)
	{
		SceneManager.LoadScene(index);
	}
	
	public void QuitRequest() 
	{
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
