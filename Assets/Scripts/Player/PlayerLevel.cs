using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
	private int playerXp;
	public int maxLevel;

	public Slider xpBar;

	public Sprite[] spaceships2;	//Eftersom jag har med att man kan välja färg på skeppet så...
	public Sprite[] spaceships3;	//... behäver jag två arrayer för färgena för båda "uppgraderingarna".

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
		if (playerXp == maxLevel/2)		//Byter till det andra skeppet vid hälften av max level.
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
