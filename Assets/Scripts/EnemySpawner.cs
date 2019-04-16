using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] enemies;

	public int level;

	public float spawnRate;		//Ifall jag skulle vilja ändra hur snabbt fienderna ska spawna.
	public float cooldown;

	private Rigidbody2D rbody2D;

	private void Start()
	{
		spawnRate = 60f;		//1 fiende i sekunden.

		rbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (cooldown <= 0)
		{
			GameObject enemyPrefab = enemies[Random.Range(0, level)];
			float maxSpawnPoint = enemyPrefab.GetComponent<BasicEnemy>().maxSpawnPoint;
			float minSpawnPoint = enemyPrefab.GetComponent<BasicEnemy>().minSpawnPoint;
			Instantiate(enemyPrefab, new Vector2(rbody2D.position.x, rbody2D.position.y + Random.Range(maxSpawnPoint, minSpawnPoint)), Quaternion.Euler(0,0,-90f));
			cooldown = 60f / spawnRate;		//60 / 60 = 1
		}
		else
		{
			cooldown -= Time.deltaTime;
		}
	}

	public void IncreaseLevel(int score)
	{
		if (score < 100)
		{
			level = 1;
		}
		else if (score < 200)
		{
			level = 2;
		}
		else if (score < 400)
		{
			level = 3;
		}
		else if (score < 600)
		{
			level = 4;
		}
		else if (score < 800)
		{
			level = 5;
		}
		else if (score < 1000)
		{
			level = 6;
		}
	}
}
