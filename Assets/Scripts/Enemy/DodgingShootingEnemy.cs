using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingShootingEnemy : DodgingEnemy
{
	private bool canShoot;
	private GameObject clone;

	void Start()
	{
		speed = 1;
		hp = 1;
		damage = 1;
		score = 70;

		rbody2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
	{
		MoveEnemy();

		if (ySpeed > yMax || ySpeed < yMin)
		{
			Shoot();
		}
	}
}
