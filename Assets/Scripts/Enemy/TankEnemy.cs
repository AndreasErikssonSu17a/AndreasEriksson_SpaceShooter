using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : BasicEnemy
{
	void Start()
	{
		speed = 0.5f;
		hp = 5;

		score = 50;
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerHealth>().PlayerDeath();

			Destroy(gameObject);
		}
	}
}
