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
}
