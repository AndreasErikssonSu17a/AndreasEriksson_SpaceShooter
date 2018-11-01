using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag != "Player" && gameObject.tag == "Laser")
        {
            Destroy(gameObject);
        }
		else if (coll.tag != "Enemy" && gameObject.tag == "ELaser")
		{
			if (coll.tag == "Player")
			{
				coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
			}

			Destroy(gameObject);
		}
    }
}
