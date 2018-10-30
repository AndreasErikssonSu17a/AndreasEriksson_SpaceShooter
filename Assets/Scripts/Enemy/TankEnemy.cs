using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : BasicEnemy
{
	void Start()
	{
		speed = 0.5f;
		hp = 5;
	}

	void Update()
	{
		transform.Translate(-speed * Time.deltaTime, 0, 0);
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			Destroy(coll.gameObject);

			Destroy(gameObject);
		}
	}
}
