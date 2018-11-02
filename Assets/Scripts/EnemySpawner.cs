using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject[] enemies;

	public int level;

	public float spawnRate;
	public float cooldown;

	private Rigidbody2D rbody2D;

	private void Start()
	{
		spawnRate = 60f;

		rbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (cooldown <= 0)
		{
			Instantiate(enemies[Random.Range(0, level)], new Vector2(rbody2D.position.x, rbody2D.position.y + Random.Range(3f, -2f)), Quaternion.Euler(0,0,-90f));
			cooldown = 60f / spawnRate;
		}
		else
		{
			cooldown -= Time.deltaTime;
		}
	}

	public void increaseLevel(int score)
	{
		if (score < 100)
		{
			level = 1;
		}
		else if (score < 200)
		{
			level = 2;
		}
		else if (score < 300)
		{
			level = 3;
		}
		else if (score < 400)
		{
			level = 4;
		}
		else if (score < 500)
		{
			level = 5;
		}
		else if (score < 600)
		{
			level = 6;
		}
	}
}
