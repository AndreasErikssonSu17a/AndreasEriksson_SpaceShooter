using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : BasicEnemy
{
    protected override void Start()
    {
        
    }

	protected override void OnTriggerEnter2D(Collider2D coll)
	{
		base.OnTriggerEnter2D(coll);

		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerHealth>().PlayerDeath();

			Destroy(gameObject);
		}
	}
}
