using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
	public Sprite[] spaceships;

	public static int arrayPos;

	private void Start()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = spaceships[arrayPos];
	}

	public void ButtonNextShip(bool isRight)
	{
		if (isRight)
		{
			if (arrayPos == spaceships.Length - 1)
			{
				arrayPos = 0;
			}
			else
			{
				arrayPos++;
			}
		}
		else
		{
			if (arrayPos == 0)
			{
				arrayPos = spaceships.Length - 1;
			}
			else
			{
				arrayPos--;
			}
		}

		gameObject.GetComponent<SpriteRenderer>().sprite = spaceships[arrayPos];
	}

	public void ButtonChoose()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
