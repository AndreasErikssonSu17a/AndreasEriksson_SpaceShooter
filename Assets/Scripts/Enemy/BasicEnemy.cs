using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed;
    public int hp;
	public int damage;

	void Start()
	{
		speed = 1;
		hp = 1;
		damage = 1;
	}

	void Update ()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Laser")
        {
            hp -= 1;
            
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerMovement>().hp -= damage;

			Destroy(gameObject);
		}
	}
}
