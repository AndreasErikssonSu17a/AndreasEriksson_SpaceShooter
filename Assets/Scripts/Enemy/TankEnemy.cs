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

		rbody2d = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Laser")
		{
			hp -= 1;

			if (hp <= 0)
			{
				GameObject GM = GameObject.FindGameObjectWithTag("GameController");
				GM.GetComponent<Score>().IncreaseScore(score);

				Destroy(gameObject);
			}
		}
		else if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerHealth>().PlayerDeath();

			Destroy(gameObject);
		}
		else if (coll.name == "Left Wall")
		{
			Destroy(gameObject);
		}
	}
}
