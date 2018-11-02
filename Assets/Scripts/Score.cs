using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Sprite[] numeral;
	public GameObject[] places;

	private int score;

	private void Start()
	{
		score = 0;

		ParseScore(score, 0);
	}

	public void IncreaseScore(int incScore)
	{
		score += incScore;
		
		gameObject.GetComponentInChildren<EnemySpawner>().increaseLevel(score);

		ParseScore(score, 0);
	}

	private void ParseScore (int number, int level)
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
