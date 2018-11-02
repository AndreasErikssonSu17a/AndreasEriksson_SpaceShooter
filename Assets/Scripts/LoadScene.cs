using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public void LoadSceneStart(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void LoadSceneGameOver()
	{
		SceneManager.LoadScene("Game Over");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
