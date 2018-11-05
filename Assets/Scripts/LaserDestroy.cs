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
		if (coll.tag != "XP")		//Lasern kan inte träffa XP.
		{
			if (coll.tag != "Player" && gameObject.tag == "Laser")		//Om det är spalarens laser kan den inte träffa spelaren.
			{
				if (coll.tag == "Enemy")
				{
					Explosion(coll.gameObject);
				}

				Destroy(gameObject);
			}
			else if (coll.tag != "Enemy" && gameObject.tag == "ELaser")	//Om det är fiendens laser kan den inte träffa fiender.
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

		clone.GetComponent<AudioSource>().Play();

		float spd = enemy.gameObject.GetComponent<BasicEnemy>().speed;
		clone.gameObject.GetComponent<Explosion>().speed = spd;			//Ändrar hastigheten till explosionen till att matcha fienden.

		clone.GetComponent<SpriteRenderer>().sprite = hit1[CharacterSelect.arrayPos];

		Destroy(clone, 1f);
	}
}
