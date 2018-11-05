using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Sprite[] numeral;
	public GameObject[] places;

	public static int score;

	public bool gameStart;	//Scriptet förekommer också i Gameover scenen så scriptet måste veta om den ska nollställa score.

	private void Start()
	{
		if (gameStart)
		{
			score = 0;
		}

		ParseScore(score, 0);

		GameObject.FindGameObjectWithTag("Music").GetComponent<MenuMusicLoop>().StopMusic();	//Stoppar meny musiken (detta behövdes bara i ett random script i spel scenen.
	}

	public void IncreaseScore(int incScore)
	{
		score += incScore;
		
		gameObject.GetComponentInChildren<EnemySpawner>().IncreaseLevel(score);		//Kollar om svårigheten ska ökas för spelet.

		ParseScore(score, 0);
	}

	private void ParseScore (int number, int level)		//number är siffran, level är positionen i talet.
	{
		int iDigit = number % 10;

		Output(iDigit, level);

		int nextNumber = number / 10;

		if (nextNumber > 0)
		{
			ParseScore(nextNumber, level + 1);
		}
	}

	private void Output (int digit, int level)
	{
		places[level].GetComponent<SpriteRenderer>().sprite = numeral[digit];
	}
}
