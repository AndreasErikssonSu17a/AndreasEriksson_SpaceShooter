using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed;
    public int hp;
	public int damage;
	public int score;

	protected Rigidbody2D rbody2d;
	public GameObject xpPill;

	public Sprite[] enemyShips;

	void Start()
	{
		ChangeShip();

		speed = 1;
		hp = 1;
		damage = 1;
		score = 10;

		rbody2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate ()
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
				GameObject GM = GameObject.FindGameObjectWithTag("GameController");
				GM.GetComponent<Score>().IncreaseScore(score);

				XpDrop();

				Destroy(gameObject);
            }
        }
		else if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

			Destroy(gameObject);
		}
		else if (coll.name == "Left Wall")
		{
			Destroy(gameObject);
		}
	}

	public void XpDrop()
	{
		int rand = Random.Range(0, 100 + 1);

		if (rand > 80)
		{
			GameObject clone = Instantiate(xpPill, rbody2d.position, Quaternion.identity);
			clone.GetComponent<Rigidbody2D>().velocity = xpPill.transform.up * 5;
		}
	}

	public void ChangeShip()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = enemyShips[Random.Range(0, enemyShips.Length)];
	}
}
