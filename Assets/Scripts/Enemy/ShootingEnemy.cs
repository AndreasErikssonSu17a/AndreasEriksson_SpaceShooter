using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BasicEnemy
{
	public GameObject projectile;
	private Rigidbody2D rbody2d;
	private GameObject clone;

	public float fireSpeed;
	private bool canShoot;
	public float cooldown;
	private float waitTimer;

	void Start()
	{
		speed = 1;
		hp = 1;
		damage = 1;
		score = 30;

		rbody2d = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		transform.Translate(0, -speed * Time.deltaTime, 0);

		if (canShoot)
		{
			Shoot();
			canShoot = false;
		}

		if (canShoot == false)
		{
			waitTimer += Time.deltaTime;

			if (waitTimer >= cooldown)
			{
				canShoot = true;
				waitTimer = 0f;
			}
		}
	}

	private void Shoot()
	{
		clone = (GameObject)Instantiate(projectile, rbody2d.transform.position, Quaternion.identity);
		clone.transform.Rotate(Vector3.forward * 90f);
		clone.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * fireSpeed;
	}
}
