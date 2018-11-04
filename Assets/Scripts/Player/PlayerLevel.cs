using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
	public AudioClip sLevelUp;

	private int playerXp;
	public int maxLevel;

	public Slider xpBar;

	public Sprite[] spaceships2;
	public Sprite[] spaceships3;

	void Start()
	{
		playerXp = 0;

		xpBar.value = playerXp;
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "XP")
		{
			IncreaseXp(1);

			Destroy(coll.gameObject);
		}
	}

	public void IncreaseXp(int incXP)
	{
		playerXp += incXP;

		xpBar.value = playerXp;

		UpgradeShip();
	}

	private void UpgradeShip()
	{
		if (playerXp == maxLevel/2)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = spaceships2[CharacterSelect.arrayPos];

			gameObject.GetComponent<AudioSource>().Play();
		}
		else if (playerXp == maxLevel)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = spaceships3[CharacterSelect.arrayPos];

			gameObject.GetComponent<AudioSource>().Play();
		}
	}
}
