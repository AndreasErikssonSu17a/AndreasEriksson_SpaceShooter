using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : BasicEnemy
{
    protected override void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll) //OnTriggerEnter2D skrivs över så det är mycket som är likt här.
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
			coll.gameObject.GetComponent<PlayerHealth>().PlayerDeath();		//Skillnad.

			Destroy(gameObject);
		}
		else if (coll.name == "Left Wall")
		{
			Destroy(gameObject);
		}
	}
}
