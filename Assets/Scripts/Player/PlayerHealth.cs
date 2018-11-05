using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	private int health;
	private int maxHealth = 5;

	public Slider healthbar;

	void Start()
	{
		health = maxHealth;

		healthbar.value = health;
	}

	public void TakeDamage(int damageValue)
	{
		GameObject GO = GameObject.FindGameObjectWithTag("Sound Source");
		GO.GetComponent<AudioSource>().Play();								//Letar reda på ett specifikt gameobject som har en AudioSource.

		health -= damageValue;

		healthbar.value = health;

		if (health <= 0)
		{
			PlayerDeath();
		}
	}

	public void PlayerDeath()
	{
		health = 0;

		Destroy(gameObject);

		healthbar.value = health;
	}

	public void OnDestroy()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
	}
}
