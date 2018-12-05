using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : BasicEnemy
{
	public float ySpeed;
	public float yDelta = 1;
	public float yMax;
	public float yMin;

	private int yDirection = 1;

    protected override void FixedUpdate()
    {
        MoveEnemy();
    }
    
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
