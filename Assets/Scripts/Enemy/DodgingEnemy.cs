using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : ShootingEnemy	//Ärver från SE för att DSE ska ärva egenskaper från både SE och DE.
{
	public float ySpeed;
	public float yDelta = 1;
	public float yMax;
	public float yMin;

	private int yDirection = 1;

	void Start()
	{
		ChangeShip();

		speed = 1;
		hp = 1;
		damage = 1;
		score = 50;

		rbody2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		MoveEnemy();
	}

	//Är en egen function för att det ska bli lättare i nästa class.
	public void MoveEnemy()
	{
		ySpeed += yDelta * yDirection;

		if (ySpeed > yMax)
		{
			yDirection = -1;
		}

		if (ySpeed < yMin)
		{
			yDirection = 1;
		}

		transform.Translate(ySpeed * Time.deltaTime, -speed * Time.deltaTime, 0);
	}
}
