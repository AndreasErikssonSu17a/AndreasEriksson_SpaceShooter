using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDestroy : MonoBehaviour
{
	public Sprite[] hit1;
	public GameObject explosionMark;
	private Rigidbody2D rbody2D;

	private void Start()
	{
		rbody2D = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.tag != "XP")
		{
			if (coll.tag != "Player" && gameObject.tag == "Laser")
			{
				if (coll.tag == "Enemy")
				{
					Explosion(coll.gameObject);
				}

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

	private void Explosion(GameObject enemy)
	{
		GameObject clone = Instantiate(explosionMark, rbody2D.position, Quaternion.identity);

		float spd = enemy.gameObject.GetComponent<BasicEnemy>().speed;
		clone.gameObject.GetComponent<Explosion>().speed = spd;

		clone.GetComponent<SpriteRenderer>().sprite = hit1[CharacterSelect.arrayPos];

		Destroy(clone, 0.5f);
	}
}
