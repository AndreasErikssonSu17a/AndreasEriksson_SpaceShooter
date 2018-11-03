using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed;
    public int hp;
	public int damage;
	public int score;

	public Sprite[] enemyShips;

	void Start()
	{
		ChangeShip();

		speed = 1;
		hp = 1;
		damage = 1;
		score = 10;
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

	public void ChangeShip()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = enemyShips[Random.Range(0, enemyShips.Length)];
	}
}
