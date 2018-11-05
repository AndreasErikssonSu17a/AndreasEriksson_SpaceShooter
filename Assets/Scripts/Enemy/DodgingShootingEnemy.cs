using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingShootingEnemy : DodgingEnemy
{
	void Start()
	{
		ChangeShip();

		speed = 1;
		hp = 1;
		damage = 1;
		score = 70;

		rbody2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
	{
		MoveEnemy();

		if (ySpeed > yMax || ySpeed < yMin) //Skjuter när fienden är som högst och som lägst.
		{
			Shoot();
		}
	}
}
