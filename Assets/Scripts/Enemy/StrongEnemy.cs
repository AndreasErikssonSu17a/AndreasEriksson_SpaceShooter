using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : BasicEnemy
{
	void Start()
	{
		ChangeShip();

		speed = 2;
		hp = 3;
		damage = 2;
		score = 20;

		rbody2d = GetComponent<Rigidbody2D>();
	}
}
