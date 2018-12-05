using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed;
    public int hp;
	public int damage;
	public int score;

	public float maxSpawnPoint;
	public float minSpawnPoint;

	protected Rigidbody2D rbody2d;		//Är protected för att den ska vara åtkommlig i arv, men vill inte ha den public i Unity.
	public GameObject xpPill;

	public Sprite[] enemyShips;

    protected void Awake()
    {
        rbody2d = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
	{
		ChangeShip();
	}

	void FixedUpdate ()
    {
		transform.Translate(0, -speed * Time.deltaTime, 0);		//Movement.
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Laser")
        {
            hp -= 1;
            
            if(hp <= 0)
            {
				GameObject GM = GameObject.FindGameObjectWithTag("GameController");
				GM.GetComponent<Score>().IncreaseScore(score);						//Ökar score.

				XpDrop();

				Destroy(gameObject);
            }
        }
		else if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

			Destroy(gameObject);
		}
		else if (coll.name == "Left Wall")		//Ifall fienden inte colliderar med något viktigt (Spelaren eller Spelarskotten).
		{
			Destroy(gameObject);
		}
	}

	public void XpDrop()
	{
		int rand = Random.Range(0, 100 + 1);

		if (rand > 80)	//20%
		{
			GameObject clone = Instantiate(xpPill, rbody2d.position, Quaternion.identity);	//Namnet clone är bara för att jag inte kommer på något annat vettigt.
			clone.GetComponent<Rigidbody2D>().velocity = xpPill.transform.up * 5;
		}
	}

	public void ChangeShip() //Byter utseendet på fienden.
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = enemyShips[Random.Range(0, enemyShips.Length)];
	}
}
