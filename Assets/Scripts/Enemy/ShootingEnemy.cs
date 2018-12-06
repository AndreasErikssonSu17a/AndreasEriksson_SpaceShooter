using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    private Rigidbody2D rbody2d;
    public GameObject projectile;
	protected GameObject clone;

	public float fireSpeed;
	protected bool canShoot;
	public float cooldown;
	private float waitTimer;

    protected float direction;

    private void Awake()
    {
        rbody2d = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        direction = 90f;
    }

    protected virtual void FixedUpdate()
	{
		Shoot();
  
        Cooldown();
	}

    protected void Cooldown()
    {
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

	public void Shoot()
	{
		if (canShoot)
		{
			canShoot = false;

			clone = (GameObject)Instantiate(projectile, rbody2d.transform.position, Quaternion.identity);
			clone.transform.Rotate(Vector3.forward * direction);
			clone.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * fireSpeed;

			clone.GetComponent<AudioSource>().Play();
		}
    }
}
